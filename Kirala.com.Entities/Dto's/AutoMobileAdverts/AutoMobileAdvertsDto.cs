using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Entities.Dto_s.AutoMobileAdverts
{
    public class AutoMobileAdvertsDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public string Year { get; set; }
        public string Mile { get; set; }
        public double Price { get; set; }
        public int VariationId { get; set; }
        public int BodyTypeId { get; set; }
        public int TransmissionId { get; set; }
        public int FuelId { get; set; }
        public int ColourId { get; set; }
        public int WheelDriveId { get; set; }
        public DateTime Created { get; set; }
    }
}
