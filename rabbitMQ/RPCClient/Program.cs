using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPCClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var rpcClient = new RpcClient();

            Console.WriteLine(" [x] Requesting Fib(29)");
            var response = rpcClient.Call("29");

            Console.WriteLine(" Get '{0}'", response);

            
            rpcClient.Close();

            Console.WriteLine(response);
        }
    }
}
