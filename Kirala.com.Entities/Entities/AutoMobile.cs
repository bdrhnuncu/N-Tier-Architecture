using Kirala.com.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Kirala.com.Entities.Entities
{
    public class AutoMobile : Advert, IEntity
    {
        public string Year { get; set; }
        public string Mile { get; set; }
        public double Price { get; set; }
        public DateTime Created { get; set; }
        public int MakeId { get; set; }
        public Make Make { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int VariationId { get; set; }
        public Variation Variation { get; set; }
        public int BodyTypeId { get; set; }
        public BodyType BodyType { get; set; }
        public int TransmissionId { get; set; }
        public Transmission Transmission { get; set; }
        public int FuelId { get; set; }
        public Fuel Fuel { get; set; }
        public int ColourId { get; set; }
        public Colour Colour { get; set; }
        public int WheelDriveId { get; set; }
        public WheelDrive WheelDrive { get; set; }

    }
}
