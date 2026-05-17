using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class EmailSettings
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool EnableSSL { get; set; }
    }
}
