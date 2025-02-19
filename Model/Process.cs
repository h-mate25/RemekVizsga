namespace Model
{
    public class Process
    {
        public int id { get; set; }

        public string type { get; set; }

        public DateTime date { get; set; }

        public List<int> pallet_id { get; set; }

        public List<int> product_id { get; set; }

        public List<int> worker_id { get; set; }

        public List<int> incomingCargo_id { get; set; }

        public List<int> outgoingCargo_id { get; set; }
    }
}
