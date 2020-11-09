using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace TLP2
{
    public struct CommandsStruct
    {
        string word;
        CommandsEnum commandEnum;
        CommandsTypeEnum typeEnum;
        public CommandsStruct(string word, CommandsEnum commandEnum, CommandsTypeEnum typeEnum) 
        {
            this.commandEnum = commandEnum;
            this.word = word;
            this.typeEnum = typeEnum;
        }

        public CommandsEnum CommandEnum { get => commandEnum; private set => commandEnum = value; }
        public CommandsTypeEnum TypeEnum { get => typeEnum; private set => typeEnum = value; }
        public string Word { get => word; private set => word = value; }
    }
}