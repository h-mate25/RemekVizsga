using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Pallet
    {   
        //PF
        public int id { get; set; }

        public int qrcode { get; set; }

        public double weight { get; set; }

        //FK
        public int place_id { get; set; }

        public bool isOrdered { get; set; }

        public List<Product> Product { get; set; } = new List<Product>();

        public List<Pallets> Pallets { get; set; } = new List<Pallets>();
    }
}
