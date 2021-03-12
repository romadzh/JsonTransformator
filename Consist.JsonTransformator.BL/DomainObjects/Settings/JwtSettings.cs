using System;
using System.Collections.Generic;
using System.Text;

namespace Consist.JsonTransformator.BL.DomainObjects.Settings
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public double ExpirationInMinutes { get; set; }
    }
}
