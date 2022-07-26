using System;
using System.Collections.Generic;
using System.Text;

namespace OPM
{
    public class AccessTokenSingleton
    {
        public string access_token { set; get; }
        public int expires_in { set; get; }
        public string errcode { set; get; }
        public string errmsg { set; get; }
    }
}
