using System;
using System.Management.Automation;
using Client;
using Contracts;
using Nelibur.ServiceModel.Clients;

namespace PSCmlet
{
    [Cmdlet(VerbsCommon.Get, "ReadFromMemory")]
    public class GetFromMemory : Cmdlet
    {
        protected override void ProcessRecord()
        {
            var client = new ClientService(Constants.ConnectionString);
            client.Read();
        }
    }
}