using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeUnionApp
{
    public class LoginAccount
    {
        private String userName;
        private String userId;
        private String userType;

        public LoginAccount() { }

        public LoginAccount(String userName, String userId, String userType)
        {
            this.userId = userId;
            this.userName = userName;
            this.userType = userType;
        }

        public void SetUserName(String name)
        {
            this.userName = name;
        }

        public void SetUserType(String type)
        {
            this.userType = type;
        }

        public void SetUserId(String id)
        {
            this.userId = id;
        }

        public String GetUserId()
        {
            return userId;
        }

        public String GetUserName()
        {
            return userName;
        }

        public String GetUserType()
        {
            return userType;
        }


    }
}
