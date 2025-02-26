using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Products
    {
        //PK
        public int id { get; set; }

        //FK
        public int process_id { get; set; }
        public Process Process { get; set; }

        //FK
        public int product_id { get; set; }
        public Product Product { get; set; }
    }
}