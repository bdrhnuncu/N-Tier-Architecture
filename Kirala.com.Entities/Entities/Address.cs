using Kirala.com.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Entities.Entities
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string District { get; set; }
        public City City { get; set; }
        public ICollection<Advert> Adverts { get; set; }
    }
}
