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
        public int[] Registers { get => getRegisters(); private set => registers = value; }

        private int[] getRegisters()
        {
            int[] result = new int[registers.Length];
            for (int i = 0; i < registers.Length; i++)
                result[i] = registers[i];
            return result;
        }
        public void ExecuteOperation() 
        {
            if (operationList == null)
                return;
            int ferstValue, secondValue;

            ferstValue = (operationList[carriage].FerstRegistr < registers.Length) ?
            registers[operationList[carriage].FerstRegistr] : operationList[carriage].AbstractRegister;

            secondValue = (operationList[carriage].SecondRegistr < registers.Length) ?
            registers[operationList[carriage].SecondRegistr] : operationList[carriage].AbstractRegister;
            EexecuteComand(ferstValue, secondValue);
            carriage++;
        }

        private void EexecuteComand(int ferstValue, int secondValue)
        {
            switch (operationList[carriage].Command)
            {
                case CommandsEnum.ADD:
                    ferstValue = ADD(ferstValue, secondValue);
                    registers[operationList[carriage].FerstRegistr] = ferstValue;
                    break;
                case CommandsEnum.SUB:
                    ferstValue = SUB(ferstValue, secondValue);
                    registers[operationList[carriage].FerstRegistr] = ferstValue;
                    break;
                case CommandsEnum.MUL:
                    ferstValue = MUL(ferstValue, secondValue);
                    registers[operationList[carriage].FerstRegistr] = ferstValue;
                    break;
                case CommandsEnum.DIV:
                    ferstValue = DIV(ferstValue, secondValue);
                    registers[operationList[carriage].FerstRegistr] = ferstValue;
                    break;
                case CommandsEnum.AND:
                    ferstValue = AND(ferstValue, secondValue);
                    registers[operationList[carriage].FerstRegistr] = ferstValue;
                    break;
                case CommandsEnum.OR:
                    ferstValue = OR(ferstValue, secondValue);
                    registers[operationList[carriage].FerstRegistr] = ferstValue;
                    break;
                case CommandsEnum.XOR:
                    ferstValue = XOR(ferstValue, secondValue);
                    registers[operationList[carriage].FerstRegistr] = ferstValue;
                    break;
                case CommandsEnum.MOV:
                    ferstValue = secondValue;
                    registers[operationList[carriage].FerstRegistr] = ferstValue;
                    break;
                case CommandsEnum.JNZ:
                    carriage = (secondValue == 0) ? ferstValue -1 : carriage;
                    break;
                case CommandsEnum.JNEG:
                    carriage = (secondValue < 0) ? ferstValue -1 : carriage;
                    break;
                case CommandsEnum.NOT:
                    ferstValue = NOT(ferstValue);
                    registers[operationList[carriage].FerstRegistr] = ferstValue;
                    break;
                case CommandsEnum.JMP:
                    carriage = ferstValue-1;
                    break;
                case CommandsEnum.STOP:
                    carriage = operationList.Count - 1;
                    break;
                    throw new System.NotImplementedException();
                default:

                    break;
            }
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