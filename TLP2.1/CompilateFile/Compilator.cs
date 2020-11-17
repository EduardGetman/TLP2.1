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
            string [] lines = userCode.Split(';','\n','\r');
            lines = DeletEmptyString(lines);
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
                int ferstRegistr = (char.IsLetter(words[1][0])) ? words[1].ToCharArray()[0] - 65 : 0;
                int secondRegistr;
                int abstractRegistr;
                if (char.IsLetter(words[2][0]) && words[2].Length < 2)
                {
                    secondRegistr = words[2].ToCharArray()[0] - 65;
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
            else if (comStr.TypeEnum == CommandsTypeEnum.OneRegister)
            {
                int ferstRegistr = (char.IsLetter(words[1][0])) ? words[1].ToCharArray()[0] - 65 : 0;

                return new Operation(comStr.CommandEnum,
                       ferstRegistr);
            }
            else return new Operation(comStr.CommandEnum);
        }
        private string[] DeletEmptyString(string[] strings) 
        {
            List<string> result = new List<string>();
            for (int i = 0; i < strings.Length; i++)
                if (strings[i].Length != 0)
                    result.Add(strings[i]);
            return result.ToArray();
        }
    }
}