using Kirala.com.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Entities.Entities
{
    public class Transmission : IEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public ICollection<AutoMobile> AutoMobiles { get; set; }
    }
}
