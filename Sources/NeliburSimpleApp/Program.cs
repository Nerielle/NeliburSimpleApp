﻿using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using Contracts;
using Nelibur.ServiceModel.Services;
using Nelibur.ServiceModel.Services.Default;

namespace Nelibur
{
    internal class Program
    {
        static Program()
        {
            NeliburSoapService.Configure(x =>
                {
                    x.Bind<GetSummRequest, Calculator>();
                    x.Bind<SaveInMemoryRequest, Calculator>();
                    x.Bind<ReadFromMemoryRequest, Calculator>();
                    x.Bind<CleanMemoryRequest, Calculator>();
                    x.Bind<AddToValueInMemoryRequest, Calculator>();
                });
        }

        private static void Main(string[] args)
        {
            var service = new WebServiceHost(typeof(JsonServicePerCall));
            service.Open();

            Console.WriteLine("Service is running");
            Console.WriteLine("Press any key to exit\n");

            Console.ReadLine();
            service.Close();
        }
    }
}