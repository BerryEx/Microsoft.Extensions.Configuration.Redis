using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Microsoft.Extensions.Configuration.Redis
{
    internal class JsonConfigurationStringParser
    {
        private JsonConfigurationStringParser()
        {
        }

        private readonly Dictionary<string, string> _data =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        private readonly Stack<string> _paths = new Stack<string>();

        public static IDictionary<string, string> Parse(string json)
            => new JsonConfigurationStringParser().ParseJsonString(json);

        private IDictionary<string, string> ParseJsonString(string json)
        {
            var jsonDocumentOptions = new JsonDocumentOptions
            {
                CommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true,
            };

            using (var reader = new StringReader(json))
            using (JsonDocument doc = JsonDocument.Parse(reader.ReadToEnd() ?? "{}", jsonDocumentOptions))
            {
                if (doc.RootElement.ValueKind != JsonValueKind.Object)
                {
                    throw new FormatException();
                }

                VisitElement(doc.RootElement);
            }

            return _data;
        }

        private void VisitElement(JsonElement element)
        {
            var isEmpty = true;

            foreach (JsonProperty property in element.EnumerateObject())
            {
                isEmpty = false;
                EnterContext(property.Name);
                VisitValue(property.Value);
                ExitContext();
            }

            if (isEmpty && _paths.Count > 0)
            {
                _data[_paths.Peek()] = null;
            }
        }

        private void VisitValue(JsonElement value)
        {
            switch (value.ValueKind)
            {
                case JsonValueKind.Object:
                    VisitElement(value);
                    break;

                case JsonValueKind.Array:
                    int index = 0;
                    foreach (JsonElement arrayElement in value.EnumerateArray())
                    {
                        EnterContext(index.ToString());
                        VisitValue(arrayElement);
                        ExitContext();
                        index++;
                    }

                    break;

                case JsonValueKind.Number:
                case JsonValueKind.String:
                case JsonValueKind.True:
                case JsonValueKind.False:
                case JsonValueKind.Null:
                    string key = _paths.Peek();
                    if (_data.ContainsKey(key))
                    {
                        throw new FormatException();
                    }

                    _data[key] = value.ToString();
                    break;

                default:
                    throw new FormatException();
            }
        }

        private void EnterContext(string context) =>
            _paths.Push(_paths.Count > 0 ? _paths.Peek() + ConfigurationPath.KeyDelimiter + context : context);

        private void ExitContext() => _paths.Pop();
    }
}