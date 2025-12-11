using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.DTOs.Auth
{
    public class LoginResultDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
