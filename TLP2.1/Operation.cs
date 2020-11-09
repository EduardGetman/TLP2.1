namespace TLP2
{
    public class Operation
    { 
        private CommandsEnum command;
        private int ferstRegistr;
        private int secondRegistr;
        private int abstractRegister; // в случае если вторым параметром является число, а не номер регистра

        public Operation(CommandsEnum command, int ferstRegistr = 0, int secondRegistr = 0, int abstractRegister = 0)
        {
            this.command = command;
            this.ferstRegistr = ferstRegistr;
            this.secondRegistr = secondRegistr;
            this.abstractRegister = abstractRegister;
        }

        // хранит его значение

        public int FerstRegistr { get => ferstRegistr; set => ferstRegistr = value; }
        public CommandsEnum Command { get => command; set => command = value; }
        public int SecondRegistr { get => secondRegistr; set => secondRegistr = value; }
        public int AbstractRegister { get => abstractRegister; set => abstractRegister = value; }
    }

}