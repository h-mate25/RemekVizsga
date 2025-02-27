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
        private WarehouseDbContext dbContext;

        public ProcessDatabaseManager(WarehouseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateProcess(Process process)
        {
            process.id = 0;
            dbContext.Processes.Add(process);
            dbContext.SaveChanges();
        }

        public List<Process> ReadProcess()
        {
            return dbContext.Processes.ToList();
        }



    }
}
