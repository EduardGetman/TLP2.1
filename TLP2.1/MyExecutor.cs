using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TLP2
{
    public class MyExecutor : IExecutor
    {
        private int carriage;
        private int[] registers;
        private List<Operation> operationList;

        public MyExecutor()
        {
            carriage = 0;
            registers = new int[MyLanguage.RegisterCount];
            ResetRegisters();
        }
        public int Carriage { get => carriage; private set => carriage = value; }
        public int[] Registers { get => registers;private set => registers = value; }
        

        public void ExecuteOperation() 
        {
            int ferstValue, secondValue;
            ferstValue = Registers[operationList[carriage].FerstRegistr];
            secondValue = (operationList[carriage].SecondRegistr < registers.Length) ?
            Registers[operationList[carriage].SecondRegistr] : operationList[carriage].AbstractRegister;
            switch (operationList[carriage].Command)
            {
                case CommandsEnum.ADD:
                    ferstValue = ADD(ferstValue, secondValue);
                    break;
                case CommandsEnum.SUB:
                    ferstValue = SUB(ferstValue, secondValue);
                    break;
                case CommandsEnum.MUL:
                    ferstValue = MUL(ferstValue, secondValue);
                    break;
                case CommandsEnum.DIV:
                    ferstValue = DIV(ferstValue, secondValue);
                    break;
                case CommandsEnum.AND:
                    ferstValue = AND(ferstValue, secondValue);
                    break;
                case CommandsEnum.OR:
                    ferstValue = OR(ferstValue, secondValue);
                    break;
                case CommandsEnum.XOR:
                    ferstValue = XOR(ferstValue, secondValue);
                    break;
                case CommandsEnum.MOV:
                    Registers[operationList[carriage].FerstRegistr] = secondValue;
                    break;
                case CommandsEnum.JNZ:
                    carriage = (ferstValue == 0) ? ferstValue : carriage;
                    break;
                case CommandsEnum.JNEG:
                    carriage = (ferstValue >= 0) ? ferstValue : carriage;
                    break;
                case CommandsEnum.NOT:
                    ferstValue = NOT(ferstValue);
                    break;
                case CommandsEnum.JMP:
                    carriage = ferstValue;
                    break;
                case CommandsEnum.STOP:
                    carriage = operationList.Count-1;
                    break;
                    throw new System.NotImplementedException();
                default:

                    break;
            }
            Registers[operationList[carriage].FerstRegistr] = ferstValue;
            carriage++;
        }

        public void StartExeсute(List<Operation> operations)
        {
            operationList = operations;
            ResetRegisters();
            carriage = 0;
            
        }

        private void ResetRegisters()
        {
            for (int i = 0; i < registers.Length; i++)            
                registers[i] = 0;
        }
        private int ADD(int ferstValue, int secondValue)
        {
            return ferstValue + secondValue;
            throw new System.NotImplementedException();
        }

        private int SUB(int ferstValue, int secondValue)
        {
            return ferstValue - secondValue;
            throw new System.NotImplementedException();
        }

        private int MUL(int ferstValue, int secondValue)
        {
            return ferstValue * secondValue;
            throw new System.NotImplementedException();
        }

        private int DIV(int ferstValue, int secondValue)
        {
            return ferstValue / secondValue;
            throw new System.NotImplementedException();
        }

        private int AND(int ferstValue, int secondValue)
        {
            return ferstValue & secondValue;
            throw new System.NotImplementedException();
        }

        private int OR(int ferstValue, int secondValue)
        {
            return ferstValue | secondValue;
            throw new System.NotImplementedException();
        }

        private int XOR(int ferstValue, int secondValue)
        {
            return ferstValue ^ secondValue;
            throw new System.NotImplementedException();
        }

        private int NOT(int value)
        {
            return ~value;
            throw new System.NotImplementedException();
        }
    }
}