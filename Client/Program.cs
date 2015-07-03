using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Nelibur.ServiceModel.Clients;

namespace Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new SoapServiceClient("SimpleSoapService");
            var readMemoryCommand = Console.ReadLine();
            BaseRequest request=ParseCommand(readMemoryCommand);
            //for (;;)
            //{
            //    Console.WriteLine("Enter 2 integer values separated by comma..");
            //    string[] values = Console.ReadLine().Split(',');

            //    if (!CheckValues(values))
            //    {
            //        continue;
            //    }
            //    Calculate(client, values);
            //}
        }


        private static BaseRequest ParseCommand(string commandFromConsole)
        {
            string[] values = commandFromConsole.Split(':');
            if (!values.Any())
            {
                throw new ArgumentException("Wrong command");
            }
            if (MemoryCommands.CommandsArray.All(x => string.CompareOrdinal(x, values[0].Trim()) != 0))
            {
                throw new ArgumentException("Wrong command");
            }
            switch (values[0].Trim())
            {
                case MemoryCommands.Mc:
                    {
                        return new CleanMemoryRequest();
                    }
                case MemoryCommands.Mr:
                    {
                        return new ReadFromMemoryRequest();
                    }
                case MemoryCommands.Ms:
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
                        return new SaveInMemoryRequest(){Value = val};
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
            
        }

        private static void Calculate(SoapServiceClient client, IList<string> values)
        {
            var sumValuesRequest = new GetSummRequest(int.Parse(values[0]), int.Parse(values[1]));
            var response = client.Get<SummResponse>(sumValuesRequest);
            Console.WriteLine("Sum: {0}", response.Result);
        }

        private static bool CheckValues(IList<string> values)
        {
            if (values.Count() != 2)
            {
                return false;
            }
            int result;
            return values.All(x => int.TryParse(x, out result));
        }

       static class  MemoryCommands
       {
           public const string Ms = "MS";
           public const string Mp = "M+";
           public const string Mm = "M-";
           public const string Mc = "MC";
           public const string Mr = "MR";
           public static string[] CommandsArray=new string[]{Ms,Mp,Mm,Mc,Mr};
       }

    }
}