using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;

namespace LyTechnology.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //TTransport transport = new TSocket("localhost", 7911);
            //TProtocol protocol = new TBinaryProtocol(transport);
            //var client = new ThriftCase.Client(protocol); //调用ThriftCase
            //transport.Open();

            //Console.WriteLine("Client calls .....");

            //client.GetUserInfo(1);

            //transport.Close();
            //Console.ReadKey();

            TTransport transport = new TSocket("localhost", 7911);
            TProtocol protocol = new TBinaryProtocol(transport);
            var client = new ThriftCase.Client(protocol); //调用ThriftCase
            transport.Open();

            Console.WriteLine("Client calls .....");

            client.InsertUserInfo2(new UserInfo() { UserId = 1 });

            transport.Close();
            Console.ReadKey();
        }
    }
}
