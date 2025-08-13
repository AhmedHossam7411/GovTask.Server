using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.Dtos
{
    internal class AuthResponseDto
    {
        public string UserName { get; set; }
        public string token { get; set; }
    }
}
