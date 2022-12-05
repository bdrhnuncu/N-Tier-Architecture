using Kirala.com.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Entities.Entities
{
    public class Advert : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
