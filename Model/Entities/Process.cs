namespace Model.Entities
{
    public class Process
    {
        public int id { get; set; }

        public string type { get; set; }

        public DateTime date { get; set; }


        public List<Pallets> Pallets { get; set; } = new List<Pallets>();

        public List<Products> Products { get; set; } = new List<Products>();

        public List<int?> worker_id { get; set; }

        public List<int?> incomingCargo_id { get; set; }

        public List<int?> outgoingCargo_id { get; set; }
    }
}
