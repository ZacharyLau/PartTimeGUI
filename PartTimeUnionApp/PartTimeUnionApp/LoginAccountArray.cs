using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeUnionApp
{
    public class LoginAccountArray
    {
        private ADTArray<LoginAccount> loginList = new ADTArray<LoginAccount>();

        public void Insert(LoginAccount account)
        {
            if (Search(account) != -1)
            {
                throw new Exception("Duplicated account.");
            }
            else
            {
                loginList.Insert(account);
            }
        }

        private int Search(LoginAccount account)
        {
            for (int i = 0; i < loginList.GetNumOfItem(); i++)
            {
                if (loginList.GetAll()[i].GetUserId().Equals(account.GetUserId()) || loginList.GetAll()[i].GetUserName().Equals(account.GetUserId()))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Delete(LoginAccount account)
        {
            int num = Search(account);
            if (num == -1)
            {
                throw new Exception("Account does not exist.");
            }
            loginList.Delete(num);
        }

        public int GetNumOfAccount()
        {
            return loginList.GetNumOfItem();
        }

    }
}
