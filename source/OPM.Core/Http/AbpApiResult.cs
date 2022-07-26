using System;
using System.Collections.Generic;
using System.Text;

namespace OPM.Core.Http
{
    public class AbpApiResult<T>
    {
        public T result { get; set; }

        public string targetUrl { get; set; }

        public bool success { get; set; }

        public AbpApiResultError error { get; set; }

        public bool unAuthorizedRequest { get; set; }

        public bool __abp { get; set; }
    }

    public class AbpApiResultError
    {
        public int code { get; set; }

        public string message { get; set; }

        public string details { get; set; }

        public string validationErrors { get; set; }
    }

    public class AbpApiResultDynamic : AbpApiResult<dynamic>
    {

    }
}
