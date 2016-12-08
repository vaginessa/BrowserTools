using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTools
{
    public class LoginData
    {
        public string Url { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public BrowserName Browser { get; set; }

        public override string ToString()
        {
            return String.Format(
                "Browser={0};Url={1};Username={2};Password={3}",
                this.Browser, this.Url, this.Username, this.Password
                );
        }
    }
}
