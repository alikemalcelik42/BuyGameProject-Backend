﻿using Core.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Gamer : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NationalNumber { get; set; }
    }
}
