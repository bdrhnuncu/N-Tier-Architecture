using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Entities.Dto_s.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }    
        public string Email { get; set; }   
        public string Phone { get; set; }
        public string Role { get; set; }
        public DateTime Created { get; set; }
    }
}
