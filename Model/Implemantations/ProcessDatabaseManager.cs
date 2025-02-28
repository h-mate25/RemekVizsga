using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Implemantations
{
    public class ProcessDatabaseManager : ProcessManagerInterface
    {
        private readonly WarehouseDbContext dbContext;

        public ProcessDatabaseManager(WarehouseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateProcess(string type, List<Products> products, List<Pallets> pallets, List<int?> workerIds, List<int?> incomingCargoIds, List<int?> outgoingCargoIds)
        {
            // Létrehozunk egy új Process entitást
            var process = new Process
            {
                type = type,  // Az átadott típus
                date = DateTime.Now,  // A jelenlegi dátum és idő
                Pallets = pallets ?? new List<Pallets>(),  // Ha nincs raklap, akkor üres lista
                Products = products ?? new List<Products>(),  // Ha nincs termék, akkor üres lista
                worker_id = workerIds ?? new List<int?>(),  // Ha nincs dolgozó, akkor üres lista
                incomingCargo_id = incomingCargoIds ?? new List<int?>(),  // Ha nincs bejövő áru, akkor üres lista
                outgoingCargo_id = outgoingCargoIds ?? new List<int?>()  // Ha nincs kimenő áru, akkor üres lista
            };

            // A Process entitás hozzáadása a DbContexthez
            dbContext.Processes.Add(process);

            // Mentsük el az új folyamatot az adatbázisba
            dbContext.SaveChanges();
        }

    

    public List<Process> ReadProcess()
        {
            return dbContext.Processes.ToList();
        }
        



    }
}
