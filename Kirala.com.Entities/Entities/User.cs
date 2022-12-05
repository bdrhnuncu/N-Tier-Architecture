using Kirala.com.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Entities.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public ICollection<Advert> Adverts { get; set; }
    }
}
