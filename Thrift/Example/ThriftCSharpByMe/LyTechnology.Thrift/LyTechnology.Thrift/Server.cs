using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Server;
using Thrift.Transport;

namespace LyTechnology.Server
{
    public class Server
    {
        public void Start()
        {
            var serverTransport = new TServerSocket(7911, 0, false); //端口、过期时间、是否缓冲

            var processor = new ThriftCase.Processor(new UserInfoImpl()); //具体的方法实现（服务端）
            TServer server = new TSimpleServer(processor, serverTransport);

            Console.WriteLine("Starting server on port 7911 ...");
            server.Serve();
        }
    }
}
