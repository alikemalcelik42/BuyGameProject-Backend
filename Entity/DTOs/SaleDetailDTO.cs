using Core.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class SaleDetailDTO : IDto
    {
        public string GamerNationalNumber { get; set; }
        public string GamerFirstName { get; set; }
        public string GamerLastName { get; set; }
        public string GamerEmail { get; set; }
        public bool GamerStatus { get; set; }
        public string GameName { get; set; }
        public decimal GameUnitPrice { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
