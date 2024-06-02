using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "https://localhost:44381/";
        public const string ValidIssuer = "https://localhost:44381/";
        public const string Key = "57D4FE37-E18E-4D9B-AA60-6687183ADC80>";
        public const int Expire = 5;
    }
}
