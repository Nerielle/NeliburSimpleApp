﻿using System;
using System.ServiceModel;
using Contracts;
using Nelibur.ServiceModel.Services;
using Nelibur.ServiceModel.Services.Default;

namespace Nelibur
{
    internal class Program
    {
        public Program()
        {
            NeliburSoapService.Configure(x => x.Bind<GetSummRequest, Calculator>());
        }

        private static void Main(string[] args)
        {
            var service = new ServiceHost(typeof (SoapServicePerCall));
            service.Open();

            Console.WriteLine("Service is running");
            Console.WriteLine("Press any key to exit\n");

            Console.ReadLine();
            service.Close();
        }
    }
}