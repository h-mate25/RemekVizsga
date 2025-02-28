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

        public void CreateProcess(string type)
        {
            var Process = new Process
            {
                id = 0,
                type = type,
                date = DateTime.Now
            };


            dbContext.Processes.Add(Process);
            dbContext.SaveChanges();


        public List<Process> ReadProcess()
        {
            return dbContext.Processes.ToList();
        }



    }
}
