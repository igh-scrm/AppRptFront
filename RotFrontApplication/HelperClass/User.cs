using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotFrontApplication.HelperClass
{
    public class User
    {
        [JsonProperty("id")]
        public int UserId { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("role_id")]
        public int UserRole { get; set; }
    }
}
