
struct UserInfo{
	1: i32 UserId
	2: string UserName
	3: string Address
	4: map<string,string>Phone
	5: string remark
	}


service ThriftCase{

	UserInfo GetUserInfo(1:i32 userId)
	
	bool InsertUserInfo(1:UserInfo userInfo)
	
	i32 InsertUserInfo2(1:UserInfo userInfo)
	
	list<string> GetUserInfoTest(1:map<string,string>  num1)
	
	list<UserInfo> GetUserInfoTest2(1:string userName)
	
	
}