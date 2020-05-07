using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper.Configuration.Annotations;

namespace BLL.DTO.Identity
{
    public class CreateUserDto
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string GitHub { get; set; }
        [Ignore]
        public string Password { get; set; }
    }
}
