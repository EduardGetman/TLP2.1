using System;
using System.Collections.Generic;
using System.Text;

namespace TLP2
{
    public interface IExecutor
    {
        int Carriage { get;}
        int[] Registers { get;}

        void ExecuteOperation();
        void StartExeсute(List<Operation> operations);
    }
}