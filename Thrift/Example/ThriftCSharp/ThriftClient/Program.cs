using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift.Transport;
using Thrift.Protocol;
using Common;

namespace ThriftClient
{
    class Program
    {
        static readonly Dictionary<String, String> Map = new Dictionary<String, String>();
        static readonly List<Blog> Blogs = new List<Blog>();

        static void Main(string[] args)
        {
			TTransport transport = new TSocket("localhost", 7911);
            TProtocol protocol = new TBinaryProtocol(transport);
            var client = new ThriftCase.Client(protocol); //调用ThriftCase
			transport.Open();

            //=============业务===========
			Console.WriteLine("Client calls .....");
			Map.Add("blog", "http://www.javabloger.com");

			client.TestCase1(10, 21, "3");
			client.TestCase2(Map);
			client.TestCase3();

			Blog blog = new Blog();
			//blog.setContent("this is blog content".getBytes());
            blog.CreatedTime = DateTime.Now.Ticks;
			blog.Id = "123456";
			blog.IpAddress = "127.0.0.1";
			blog.Topic = "this is blog topic";
			Blogs.Add(blog);
			
			client.TestCase4(Blogs);
			
			transport.Close();

            Console.ReadKey();
        }
    }
}
