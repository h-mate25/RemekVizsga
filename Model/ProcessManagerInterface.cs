﻿using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface ProcessManagerInterface
    {
        List<Process> ReadProcess();
        void CreateProcess(string type, List<Products> products, List<Pallets> pallets, List<int?> workerIds, List<int?> incomingCargoIds, List<int?> outgoingCargoIds);
    }
}
