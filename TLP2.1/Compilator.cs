using System;
using System.Collections.Generic;
using System.Text;

namespace TLP2
{
    public class Compilator
    {
        private MyLanguage language;

        public Compilator()
        {
            language = new MyLanguage();
        }
        public List<Operation> Compilate(string userCode )
        {
            List<Operation> operations = new List<Operation>();
            string [] lines = userCode.Split(';');
            for (int i = 0; i < lines.Length; i++)
                operations.Add(StringToOperation(lines[i]));
            return operations;
        }

        private Operation StringToOperation(string line)
        {
            string[] words = line.Split(' ');
            CommandsStruct comStr = language.WordToCommandsStruct(words[0]);
            if (comStr.TypeEnum == CommandsTypeEnum.TwoRegister)
            {
                int ferstRegistr = (language.IsLetter(words[1]))? words[1].ToCharArray()[0]-64:0;
                int secondRegistr;
                int abstractRegistr;
                if (language.IsLetter(words[2]))
                {
                    secondRegistr = words[2].ToCharArray()[0] - 64;
                    abstractRegistr = 0;
                }
                else
                {
                    secondRegistr = MyLanguage.NumberAbstractRegister;
                    abstractRegistr = Convert.ToInt32(words[2]);
                }
                return new Operation(comStr.CommandEnum,
                    ferstRegistr, secondRegistr, abstractRegistr);
            }
            throw new NotImplementedException();
        }
    }
}