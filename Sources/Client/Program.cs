using System;
using System.Linq;
using Contracts;
using Nelibur.ServiceModel.Clients;

namespace Client
{
    internal static class Program
    {
        private static ClientService client;

        private static void Main(string[] args)
        {
            client = new ClientService();


            while (true)
            {
                Console.WriteLine("Enter command..");
                string readMemoryCommand = Console.ReadLine();
                try
                {
                    string[] values = ParseCommand(readMemoryCommand);
                    ProcessRequest(values);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        private static void ProcessRequest(string[] values)
        {
            switch (values[0].Trim())
            {
                case MemoryCommands.Mc:
                    {
                        client.Clean();
                        break;
                    }
                case MemoryCommands.Mr:
                    {
                        client.Read();
                        break;
                    }
                case MemoryCommands.Ms:
                    {
                        int val = GetIntValueFromCommand(values);
                        client.Save(val);
                        break;
                    }
                case MemoryCommands.Mp:
                    {
                        int val = GetIntValueFromCommand(values);
                        client.Plus(val);
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        private static int GetIntValueFromCommand(string[] values)
        {
            int val;
            if (values.Count() == 1)
            {
                throw new ArgumentException("Value");
            }
            if (!int.TryParse(values[1], out val))
            {
                throw new ArgumentException("Not integer");
            }
            return val;
        }

        private static string[] ParseCommand(string commandFromConsole)
        {
            string[] values = commandFromConsole.Split(' ');
            if (!values.Any())
            {
                throw new ArgumentException("Wrong command");
            }
            if (
                MemoryCommands.CommandsArray.All(
                    x => string.Compare(x, values[0], StringComparison.InvariantCultureIgnoreCase) != 0))
            {
                throw new ArgumentException("Wrong command");
            }
            return values;
        }
    }
}