using System;
using System.Collections.Generic;
using System.Text;

namespace TLP2
{
    public class MyLanguage
    {
        private static int registerCount = 26;
        public const int NumberAbstractRegister = 27;
        private CommandsStruct[] commandsStructs;
        public MyLanguage() 
        {
            InitializationComStr();
        }       
        public static int RegisterCount { get => registerCount;}
        public CommandsStruct[] CommandsStructs { get => commandsStructs;private set => commandsStructs = value; }

        public bool IsWord(string word) 
        {
            for (int i = 0; i < commandsStructs.Length; i++)
                if (word == commandsStructs[i].Word)
                    return true;
            return false;
        }
        public bool IsLetter(string letter) 
        {
            if (letter.Length == 1)
                return letter[0] > 64 && letter[0] < 91;
            else
                return false;

        }
        public CommandsStruct WordToCommandsStruct(string word) 
        {
            for (int i = 0; i < commandsStructs.Length; i++)
                if (word == commandsStructs[i].Word)
                    return commandsStructs[i];
            return new CommandsStruct();
        }
        private void InitializationComStr() 
        {
            commandsStructs = new CommandsStruct[13];
            commandsStructs[0] =  new CommandsStruct("ADD",  CommandsEnum.ADD,  CommandsTypeEnum.TwoRegister);
            commandsStructs[1] =  new CommandsStruct("AND",  CommandsEnum.AND,  CommandsTypeEnum.TwoRegister);
            commandsStructs[2] =  new CommandsStruct("DIV",  CommandsEnum.DIV,  CommandsTypeEnum.TwoRegister);
            commandsStructs[3] =  new CommandsStruct("JMP",  CommandsEnum.JMP,  CommandsTypeEnum.OneRegister);
            commandsStructs[4] =  new CommandsStruct("JNEG", CommandsEnum.JNEG, CommandsTypeEnum.TwoRegister);
            commandsStructs[5] =  new CommandsStruct("JNZ",  CommandsEnum.JNZ,  CommandsTypeEnum.TwoRegister);
            commandsStructs[6] =  new CommandsStruct("MOV",  CommandsEnum.MOV,  CommandsTypeEnum.TwoRegister);
            commandsStructs[7] =  new CommandsStruct("MUL",  CommandsEnum.MUL,  CommandsTypeEnum.TwoRegister);
            commandsStructs[8] =  new CommandsStruct("NOT",  CommandsEnum.NOT,  CommandsTypeEnum.OneRegister);
            commandsStructs[9] =  new CommandsStruct("OR",   CommandsEnum.OR,   CommandsTypeEnum.TwoRegister);
            commandsStructs[10] = new CommandsStruct("STOP", CommandsEnum.STOP, CommandsTypeEnum.ZeroRegistor);
            commandsStructs[11] = new CommandsStruct("SUB",  CommandsEnum.SUB,  CommandsTypeEnum.TwoRegister);
            commandsStructs[12] = new CommandsStruct("XOR",  CommandsEnum.XOR,  CommandsTypeEnum.TwoRegister);


        }
    }
}