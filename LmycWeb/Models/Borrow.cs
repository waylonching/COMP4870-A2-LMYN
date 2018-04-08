﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmycWeb.Models
{
    public class Borrow
    {
        public int BorrowId { get; set; }
        public string BorrowerName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public int BoatId { get; set; }
        public Boat Boat { get; set; }
    }
}
