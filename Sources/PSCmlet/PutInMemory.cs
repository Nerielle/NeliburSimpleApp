using System.Management.Automation;
using Client;

namespace PSCmlet
{
     [Cmdlet(VerbsCommon.Add, "PutInMemory")]
    public class PutInMemory: Cmdlet
    {
         [Parameter(Mandatory = true, Position = 1)]
         public int Value { get; set; }
         protected override void ProcessRecord()
         {
             var client = new ClientService(Constants.ConnectionString);
             client.Plus(Value);
         }
    }
}