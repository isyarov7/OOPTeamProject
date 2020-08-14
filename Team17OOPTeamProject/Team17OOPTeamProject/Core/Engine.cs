using System;
using System.Text;
using T17.Models.Core.Contracts;

namespace T17.Models.Core
{
    public class Engine : IEngine
    {
        private static Engine instance;
        public static IEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                }

                return instance;
            }
        }

        private readonly ICommandManager commandManager;

        private Engine()
        {
            this.commandManager = new CommandManager();
        }

        public void Run()
        {
            Console.WriteLine("Split your parameters with ;");
            while (true)
            {
                // Read -> Process -> Print -> Repeat
                string input = this.Read();

                if (input == "exit")
                    break;

                string result = this.Process(input);

                this.Print(result);
            }
        }

        private string Read()
        {
            string input = Console.ReadLine();
            return input;
        }

        private string Process(string commandLine)
        {
            try
            {
                var command = this.commandManager.ParseCommand(commandLine);
                string result = command.Execute();

                return result.Trim();
            }
            catch (Exception e)
            {
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }

                return $"ERROR: {e.Message}";
            }
        }

        private void Print(string commandResult)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(commandResult);
            sb.AppendLine("####################");
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
