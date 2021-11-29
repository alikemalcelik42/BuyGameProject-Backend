using Core.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Sale : IEntity
    {
        public int Id { get; set; }
        public int GamerId { get; set; }
        public int GameId { get; set; }
        public decimal Amount { get; set; }
    }
}
