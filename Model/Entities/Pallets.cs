using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Pallets
    {
        //PK
        public int id { get; set; }

        //FK
        public int process_id { get; set; }
        public Process Process { get; set; }

        //FK
        public int pallet_id { get; set; }
        public Pallet pallet { get; set; }
    }
}
