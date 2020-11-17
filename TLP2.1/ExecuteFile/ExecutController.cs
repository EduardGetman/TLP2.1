using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TLP2
{
    public class ExecutController
    {
        private IExecutor executor;

        public ExecutController(IExecutor executor)
        {
            this.executor = executor;
        }

        public int[,] DebugExecute(List<Operation> operations)
        {
            List<int[]> listRegisters = new List<int[]>();
            executor.StartExeсute(operations);
            while (executor.Carriage < operations.Count)
            {
                executor.ExecuteOperation();
                listRegisters.Add(executor.Registers);
            }
            return JaggedArrayToMatrix(listRegisters.ToArray());
        }

        private int[,] JaggedArrayToMatrix(int[][] jaggedArray) 
        {            
            int[,] result = new int[jaggedArray.Length, jaggedArray[0].Length];
            for (int i = 0; i < jaggedArray.Length; i++)
                for (int j = 0; j < jaggedArray[i].Length; j++)
                    result[i, j] = jaggedArray[i][j];
            return result;
                    
               
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