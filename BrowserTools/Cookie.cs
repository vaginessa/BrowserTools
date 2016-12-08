using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTools
{
    public class Cookie
    {
        public string HostKey { get; set; }
        
        public string Name { get; set; }
        public string Value { get; set; }
        public string Path { get; set; }

        public string ExpiresUtc { get; set; }
        public string LastAccessUtc { get; set; }

        public bool Secure { get; set; }
        public bool HttpOnly { get; set; }
        public bool Expired { get; set; }
        public bool Persistent { get; set; }
        public bool Priority { get; set; }

        public BrowserName Browser { get; set; }
    }
}
