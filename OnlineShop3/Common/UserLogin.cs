using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop3.Common
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { get; set; }
        public string UserName { set; get; }
        public string UserGroupID { set; get; }
    }
}