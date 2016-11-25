using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift.Transport;
using Thrift.Protocol;
using Thrift.Server;
using Common;

namespace ThriftServer
{
    public class Server
    {
        /// <summary>
        /// 服务端启动并监控
        /// </summary>
        public void Start()
        {
            var serverTransport = new TServerSocket(7911, 0, false);//端口、过期时间、是否缓冲
            var processor = new ThriftCase.Processor(new BusinessImpl());//具体的方法实现（服务端）
            TServer server = new TSimpleServer(processor, serverTransport);
            Console.WriteLine("Starting server on port 7911 ...");
            server.Serve();
        }
    }
}
