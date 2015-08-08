using System;
using System.Configuration;
using Contracts;
using Nelibur.ServiceModel.Clients;

namespace Client
{
    public class ClientService
    {
        private readonly JsonServiceClient client;

        internal ClientService():this(ConfigurationManager.ConnectionStrings["host"].ConnectionString)
        {
        }

        public ClientService(string connectionString)
        {
            client = new JsonServiceClient(connectionString);
        }

        public void Clean()
        {
            var request = new CleanMemoryRequest();
            client.Delete(request);
            Console.WriteLine("The memory is cleared..");
        }

        public void Read()
        {
            var request = new ReadFromMemoryRequest();
            var response = client.Get<IntResponse>(request);
            Console.WriteLine("Value from memory: {0}", response.Result);
        }

        public void Save(int val)
        {
            var request = new SaveInMemoryRequest { Value = val };
            client.Post(request);
            Console.WriteLine("Value saved in memory.");
        }

        public void Plus(int val)
        {
            client.Put(new AddToValueInMemoryRequest { Value = val });
            Console.WriteLine("{0} was added to the value in memory.", val);
        }
    }
}