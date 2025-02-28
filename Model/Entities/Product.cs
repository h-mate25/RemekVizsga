using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Product
    {
        public int id { get; set; }

        public int barcode { get; set; }

        public string type { get; set; }

        public string name { get; set; }

        public double weight { get; set; }

        public double price { get; set; }

        public bool onPallet { get; set; }

        public int? pallet_id { get; set; }
        public Pallet pallet { get; set; }

        public List<Products> Products { get; set; } = new List<Products>();

    }
}
