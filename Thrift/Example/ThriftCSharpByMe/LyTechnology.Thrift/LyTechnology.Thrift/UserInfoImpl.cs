using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyTechnology.Server
{
    public class UserInfoImpl : ThriftCase.Iface
    {
        public UserInfo GetUserInfo(int userId)
        {
            return new UserInfo() { UserId = 1, UserName = "张三" };
        }

        public bool InsertUserInfo(UserInfo userInfo)
        {
            Console.WriteLine("   InsertUserInfo is :" + userInfo.UserId);
            Console.WriteLine(true);
            return true;
        }

        public int InsertUserInfo2(UserInfo userInfo)
        {
            Console.WriteLine("   InsertUserInfo2 is :" + userInfo.UserId);
            Console.WriteLine(1);
            return 1;
        }

        public List<string> GetUserInfoTest(Dictionary<string, string> num1)
        {
            return null;
        }


        public List<UserInfo> GetUserInfoTest2(string userName)
        {
            return null;
        }
    }
}
