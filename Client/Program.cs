﻿using System;
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
            for (;;)
            {
                Console.WriteLine("Enter 2 integer values separated by comma..");
                string[] values = Console.ReadLine().Split(',');
               
                if (!CheckValues(values))
                {
                    continue;
                }
                Calculate(client, values);
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
    }
}