using System;
using System.Linq;
using Contracts;
using Nelibur.ServiceModel.Clients;

namespace Client
{
    internal static class Program
    {
        private static SoapServiceClient client;

        private static void Main(string[] args)
        {
            client = new SoapServiceClient("SimpleSoapService");


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
                        var request = new CleanMemoryRequest();
                        client.Delete(request);
                        Console.WriteLine("The memory is cleared..");
                        break;
                    }
                case MemoryCommands.Mr:
                    {
                        var request = new ReadFromMemoryRequest();
                        var response = client.Get<IntResponse>(request);
                        Console.WriteLine("Value from memory: {0}", response.Result);
                        break;
                    }
                case MemoryCommands.Ms:
                    {
                        int val = GetIntValueFromCommand(values);

                        var request = new SaveInMemoryRequest {Value = val};
                        client.Post(request);
                        Console.WriteLine("Value saved in memory.");
                        break;
                    }
                case MemoryCommands.Mp:
                    {
                        int val = GetIntValueFromCommand(values);
                        client.Put(new AddToValueInMemoryRequest {Value = val});
                        Console.WriteLine("{0} was added to the value in memory.", val);
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