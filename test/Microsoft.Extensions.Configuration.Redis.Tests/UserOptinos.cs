using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.Configuration.Redis.Tests
{
    /// <summary>
    /// 功能描述    ：UserOptinos
    /// 创 建 者    ：大師兄丶
    /// 创建日期    ：2021年07月15日 星期四 15:57 
    /// 最后修改者  ：大師兄丶
    /// 最后修改日期：2021年07月15日 星期四 15:57 
    /// </summary>
    public class Useroptions
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Companylist> CompanyList { get; set; }
        public Group Group { get; set; }
    }

    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEnable { get; set; }
    }

    public class Companylist
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}