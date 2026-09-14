namespace TheTankGame.Core
{
    using System;
    using System.Linq;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader,
            IWriter writer,
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;
            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string inputLine = this.reader.ReadLine();
                var inputParameters = inputLine
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string command = inputParameters[0];
                string result = this.commandInterpreter.ProcessInput(inputParameters);

                this.writer.WriteLine(result);

                if (command == "Terminate")
                {
                    this.isRunning = false;
                }
            }
        }
    }
}
