using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAST_CHRISTMAS.Models
{
    public class MemberViewModel
    {
        public string MemberTitle { get; set; }
        public string GivenAnswer { get; set; }
        public string Answer { get; internal set; }
        public string PageIdentity { get; internal set; }

        public bool IsError { get; set; }
        public bool IsSuccess { get; internal set; }
        public string Letter { get; internal set; }
    }
}