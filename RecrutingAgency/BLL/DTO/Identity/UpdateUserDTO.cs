using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO.Identity
{
    public class UpdateUserDto
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string GitHub { get; set; }
    }
}
