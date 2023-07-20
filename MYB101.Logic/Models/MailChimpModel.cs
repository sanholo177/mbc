using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MYB101.Logic.Models
{
    public class MailChimpModel
    {
        public string Email { get; set; }
        public Dictionary<string, string> MergeVars { get; set; } 
    }
}