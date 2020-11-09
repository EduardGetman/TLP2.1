using System;
using System.Collections.Generic;
using System.Text;

namespace TLP2
{
    public class ExecutController
    {
        private IExecutor executor;

        public int[][] DebugExecute(List<Operation> operations)
        {
            List<int[]> listRegisters = new List<int[]>();
            while (executor.Carriage < operations.Count)
            {
                executor.ExecuteOperation();
                listRegisters.Add(executor.Registers);
            }
            return listRegisters.ToArray();
        }

        public int[] RunExecute(List<Operation> operations)
        {
            executor.StartExeсute(operations);
            while (executor.Carriage < operations.Count)
                executor.ExecuteOperation();
            return executor.Registers;
        }
    }
}