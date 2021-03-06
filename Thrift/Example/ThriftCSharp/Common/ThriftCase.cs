/**
 * Autogenerated by Thrift Compiler (0.7.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using Thrift.Protocol;
using Thrift.Transport;

namespace Common
{
    public class ThriftCase
    {
        public interface IFace
        {
            int TestCase1(int num1, int num2, string num3);
            List<string> TestCase2(Dictionary<string, string> num1);
            void TestCase3();
            void TestCase4(List<Blog> blog);
        }

        #region Client

        public class Client : IFace
        {
            protected TProtocol Iprot;
            protected TProtocol Oprot;
            protected int Seqid;

            public Client(TProtocol prot)
                : this(prot, prot)
            {
            }

            public Client(TProtocol iprot, TProtocol oprot)
            {
                Iprot = iprot;
                Oprot = oprot;
            }

            public TProtocol InputProtocol
            {
                get { return Iprot; }
            }

            public TProtocol OutputProtocol
            {
                get { return Oprot; }
            }

            public int TestCase1(int num1, int num2, string num3)
            {
                send_testCase1(num1, num2, num3);
                return recv_testCase1();
            }

            /// <summary>
            /// 发送消息
            /// </summary>
            /// <param name="num1"></param>
            /// <param name="num2"></param>
            /// <param name="num3"></param>
            public void send_testCase1(int num1, int num2, string num3)
            {
                Oprot.WriteMessageBegin(new TMessage("testCase1", TMessageType.Call, Seqid));
                TestCase1Args args = new TestCase1Args();
                args.Num1 = num1;
                args.Num2 = num2;
                args.Num3 = num3;
                args.Write(Oprot);

                Oprot.WriteMessageEnd();
                Oprot.Transport.Flush();
            }
            /// <summary>
            /// 接受消息
            /// </summary>
            /// <returns></returns>
            public int recv_testCase1()
            {
                TMessage msg = Iprot.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    TApplicationException x = TApplicationException.Read(Iprot);
                    Iprot.ReadMessageEnd();
                    throw x;
                }
                TestCase1Result result = new TestCase1Result();
                result.Read(Iprot);
                Iprot.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult,
                    "testCase1 failed: unknown result");
            }

            #region TestCase 2 3 4

            public List<string> TestCase2(Dictionary<string, string> num1)
            {
                send_testCase2(num1);
                return recv_testCase2();
            }

            public void send_testCase2(Dictionary<string, string> num1)
            {
                Oprot.WriteMessageBegin(new TMessage("testCase2", TMessageType.Call, Seqid));
                testCase2_args args = new testCase2_args();
                args.Num1 = num1;
                args.Write(Oprot);
                Oprot.WriteMessageEnd();
                Oprot.Transport.Flush();
            }

            public List<string> recv_testCase2()
            {
                TMessage msg = Iprot.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    TApplicationException x = TApplicationException.Read(Iprot);
                    Iprot.ReadMessageEnd();
                    throw x;
                }
                testCase2_result result = new testCase2_result();
                result.Read(Iprot);
                Iprot.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult,
                    "testCase2 failed: unknown result");
            }

            public void TestCase3()
            {
                send_testCase3();
                recv_testCase3();
            }

            public void send_testCase3()
            {
                Oprot.WriteMessageBegin(new TMessage("testCase3", TMessageType.Call, Seqid));
                testCase3_args args = new testCase3_args();
                args.Write(Oprot);
                Oprot.WriteMessageEnd();
                Oprot.Transport.Flush();
            }

            public void recv_testCase3()
            {
                TMessage msg = Iprot.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    TApplicationException x = TApplicationException.Read(Iprot);
                    Iprot.ReadMessageEnd();
                    throw x;
                }
                testCase3_result result = new testCase3_result();
                result.Read(Iprot);
                Iprot.ReadMessageEnd();
                return;
            }

            public void TestCase4(List<Blog> blog)
            {
                send_testCase4(blog);
                recv_testCase4();
            }

            public void send_testCase4(List<Blog> blog)
            {
                Oprot.WriteMessageBegin(new TMessage("testCase4", TMessageType.Call, Seqid));
                testCase4_args args = new testCase4_args();
                args.Blog = blog;
                args.Write(Oprot);
                Oprot.WriteMessageEnd();
                Oprot.Transport.Flush();
            }

            public void recv_testCase4()
            {
                TMessage msg = Iprot.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    TApplicationException x = TApplicationException.Read(Iprot);
                    Iprot.ReadMessageEnd();
                    throw x;
                }
                testCase4_result result = new testCase4_result();
                result.Read(Iprot);
                Iprot.ReadMessageEnd();
                return;
            }

            #endregion

        }

        #endregion

        #region Processor

        /// <summary>
        /// 创建TProcessor
        /// </summary>
        public class Processor : TProcessor
        {
            private IFace iface_;
            protected Dictionary<string, ProcessFunction> ProcessMap = new Dictionary<string, ProcessFunction>();

            public Processor(IFace iface)
            {
                iface_ = iface;

                ProcessMap["testCase1"] = testCase1_Process;
                ProcessMap["testCase2"] = testCase2_Process;
                ProcessMap["testCase3"] = testCase3_Process;
                ProcessMap["testCase4"] = testCase4_Process;
            }

            protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);

            public bool Process(TProtocol iprot, TProtocol oprot)
            {
                try
                {
                    TMessage msg = iprot.ReadMessageBegin();
                    ProcessFunction fn;
                    ProcessMap.TryGetValue(msg.Name, out fn);
                    if (fn == null)
                    {
                        TProtocolUtil.Skip(iprot, TType.Struct);
                        iprot.ReadMessageEnd();
                        TApplicationException x =
                            new TApplicationException(TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
                        oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
                        x.Write(oprot);
                        oprot.WriteMessageEnd();
                        oprot.Transport.Flush();
                        return true;
                    }
                    fn(msg.SeqID, iprot, oprot);
                }
                catch (IOException)
                {
                    return false;
                }
                return true;
            }

            public void testCase1_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                TestCase1Args args = new TestCase1Args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                TestCase1Result result = new TestCase1Result();
                result.Success = iface_.TestCase1(args.Num1, args.Num2, args.Num3);
                oprot.WriteMessageBegin(new TMessage("testCase1", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            #region testCase*_Process

            public void testCase2_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                testCase2_args args = new testCase2_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                testCase2_result result = new testCase2_result();
                result.Success = iface_.TestCase2(args.Num1);
                oprot.WriteMessageBegin(new TMessage("testCase2", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void testCase3_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                testCase3_args args = new testCase3_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                testCase3_result result = new testCase3_result();
                iface_.TestCase3();
                oprot.WriteMessageBegin(new TMessage("testCase3", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void testCase4_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                testCase4_args args = new testCase4_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                testCase4_result result = new testCase4_result();
                iface_.TestCase4(args.Blog);
                oprot.WriteMessageBegin(new TMessage("testCase4", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            #endregion

        }

        #endregion

        #region testCase1_args

        [Serializable]
        public partial class TestCase1Args : TBase
        {
            public TestCase1Args() { }

            public Isset __isset;

            [Serializable]
            public struct Isset
            {
                public bool num1;
                public bool num2;
                public bool num3;
            }

            #region 属性（参数）

            private int _num1;
            private int _num2;
            private string _num3;

            public int Num1
            {
                get { return _num1; }
                set
                {
                    __isset.num1 = true;
                    this._num1 = value;
                }
            }

            public int Num2
            {
                get { return _num2; }
                set
                {
                    __isset.num2 = true;
                    this._num2 = value;
                }
            }

            public string Num3
            {
                get { return _num3; }
                set
                {
                    __isset.num3 = true;
                    this._num3 = value;
                }
            }

            #endregion

            #region Read

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.I32)
                            {
                                Num1 = iprot.ReadI32();
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        case 2:
                            if (field.Type == TType.I32)
                            {
                                Num2 = iprot.ReadI32();
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        case 3:
                            if (field.Type == TType.String)
                            {
                                Num3 = iprot.ReadString();
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            #endregion

            #region Write

            public void Write(TProtocol oprot)
            {
                TStruct struc = new TStruct("testCase1_args");
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (__isset.num1)
                {
                    field.Name = "num1";
                    field.Type = TType.I32;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI32(Num1);
                    oprot.WriteFieldEnd();
                }
                if (__isset.num2)
                {
                    field.Name = "num2";
                    field.Type = TType.I32;
                    field.ID = 2;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI32(Num2);
                    oprot.WriteFieldEnd();
                }
                if (Num3 != null && __isset.num3)
                {
                    field.Name = "num3";
                    field.Type = TType.String;
                    field.ID = 3;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteString(Num3);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            #endregion

            #region ToString

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder("testCase1_args(");
                sb.Append("Num1: ");
                sb.Append(Num1);
                sb.Append(",Num2: ");
                sb.Append(Num2);
                sb.Append(",Num3: ");
                sb.Append(Num3);
                sb.Append(")");
                return sb.ToString();
            }

            #endregion
        }

        #endregion

        #region testCase1_result

        [Serializable]
        public partial class TestCase1Result : TBase
        {
            public TestCase1Result()
            {
            }

            private int _success;

            public int Success
            {
                get { return _success; }
                set
                {
                    __isset.success = true;
                    this._success = value;
                }
            }

            public Isset __isset;

            [Serializable]
            public struct Isset
            {
                public bool success;
            }

            #region Read

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.I32)
                            {
                                Success = iprot.ReadI32();
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            #endregion

            #region Write

            public void Write(TProtocol oprot)
            {
                TStruct struc = new TStruct("testCase1_result");
                oprot.WriteStructBegin(struc);
                TField field = new TField();

                if (this.__isset.success)
                {
                    field.Name = "Success";
                    field.Type = TType.I32;
                    field.ID = 0;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI32(Success);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            #endregion

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder("testCase1_result(");
                sb.Append("Success: ");
                sb.Append(Success);
                sb.Append(")");
                return sb.ToString();
            }
        }

        #endregion




        #region testCase2_args

        [Serializable]
        public partial class testCase2_args : TBase
        {
            private Dictionary<string, string> _num1;

            public Dictionary<string, string> Num1
            {
                get { return _num1; }
                set
                {
                    __isset.num1 = true;
                    this._num1 = value;
                }
            }


            public Isset __isset;

            [Serializable]
            public struct Isset
            {
                public bool num1;
            }

            public testCase2_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Map)
                            {
                                {
                                    Num1 = new Dictionary<string, string>();
                                    TMap _map5 = iprot.ReadMapBegin();
                                    for (int _i6 = 0; _i6 < _map5.Count; ++_i6)
                                    {
                                        string _key7;
                                        string _val8;
                                        _key7 = iprot.ReadString();
                                        _val8 = iprot.ReadString();
                                        Num1[_key7] = _val8;
                                    }
                                    iprot.ReadMapEnd();
                                }
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                TStruct struc = new TStruct("testCase2_args");
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (Num1 != null && __isset.num1)
                {
                    field.Name = "num1";
                    field.Type = TType.Map;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    {
                        oprot.WriteMapBegin(new TMap(TType.String, TType.String, Num1.Count));
                        foreach (string _iter9 in Num1.Keys)
                        {
                            oprot.WriteString(_iter9);
                            oprot.WriteString(Num1[_iter9]);
                        }
                        oprot.WriteMapEnd();
                    }
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder("testCase2_args(");
                sb.Append("Num1: ");
                sb.Append(Num1);
                sb.Append(")");
                return sb.ToString();
            }

        }

        #endregion

        #region testCase2_result

        [Serializable]
        public partial class testCase2_result : TBase
        {
            private List<string> _success;

            public List<string> Success
            {
                get { return _success; }
                set
                {
                    __isset.success = true;
                    this._success = value;
                }
            }


            public Isset __isset;

            [Serializable]
            public struct Isset
            {
                public bool success;
            }

            public testCase2_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.List)
                            {
                                {
                                    Success = new List<string>();
                                    TList _list10 = iprot.ReadListBegin();
                                    for (int _i11 = 0; _i11 < _list10.Count; ++_i11)
                                    {
                                        string _elem12 = null;
                                        _elem12 = iprot.ReadString();
                                        Success.Add(_elem12);
                                    }
                                    iprot.ReadListEnd();
                                }
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                TStruct struc = new TStruct("testCase2_result");
                oprot.WriteStructBegin(struc);
                TField field = new TField();

                if (this.__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.List;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        {
                            oprot.WriteListBegin(new TList(TType.String, Success.Count));
                            foreach (string _iter13 in Success)
                            {
                                oprot.WriteString(_iter13);
                            }
                            oprot.WriteListEnd();
                        }
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder("testCase2_result(");
                sb.Append("Success: ");
                sb.Append(Success);
                sb.Append(")");
                return sb.ToString();
            }

        }

        #endregion

        #region testCase3_args

        [Serializable]
        public partial class testCase3_args : TBase
        {
            public testCase3_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                TStruct struc = new TStruct("testCase3_args");
                oprot.WriteStructBegin(struc);
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder("testCase3_args(");
                sb.Append(")");
                return sb.ToString();
            }

        }

        #endregion

        #region testCase3_result

        [Serializable]
        public partial class testCase3_result : TBase
        {

            public testCase3_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                TStruct struc = new TStruct("testCase3_result");
                oprot.WriteStructBegin(struc);

                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder("testCase3_result(");
                sb.Append(")");
                return sb.ToString();
            }

        }

        #endregion

        #region testCase4_args

        [Serializable]
        public partial class testCase4_args : TBase
        {
            private List<Blog> _blog;

            public List<Blog> Blog
            {
                get { return _blog; }
                set
                {
                    __isset.blog = true;
                    this._blog = value;
                }
            }


            public Isset __isset;

            [Serializable]
            public struct Isset
            {
                public bool blog;
            }

            public testCase4_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.List)
                            {
                                {
                                    Blog = new List<Blog>();
                                    TList _list14 = iprot.ReadListBegin();
                                    for (int _i15 = 0; _i15 < _list14.Count; ++_i15)
                                    {
                                        Blog _elem16 = new Blog();
                                        _elem16 = new Blog();
                                        _elem16.Read(iprot);
                                        Blog.Add(_elem16);
                                    }
                                    iprot.ReadListEnd();
                                }
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                TStruct struc = new TStruct("testCase4_args");
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (Blog != null && __isset.blog)
                {
                    field.Name = "blog";
                    field.Type = TType.List;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    {
                        oprot.WriteListBegin(new TList(TType.Struct, Blog.Count));
                        foreach (Blog _iter17 in Blog)
                        {
                            _iter17.Write(oprot);
                        }
                        oprot.WriteListEnd();
                    }
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder("testCase4_args(");
                sb.Append("Blog: ");
                sb.Append(Blog);
                sb.Append(")");
                return sb.ToString();
            }

        }

        #endregion

        #region testCase4_result

        [Serializable]
        public partial class testCase4_result : TBase
        {

            public testCase4_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                TStruct struc = new TStruct("testCase4_result");
                oprot.WriteStructBegin(struc);

                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder("testCase4_result(");
                sb.Append(")");
                return sb.ToString();
            }

        }

        #endregion


    }
}