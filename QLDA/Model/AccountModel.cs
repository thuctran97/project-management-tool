using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Framework;
using System.Data.SqlClient;

namespace Model
{
    public class AccountModel
    {
        private QLDAContext context = null;
        public AccountModel()
        {
            context = new QLDAContext();
        }
        public bool Login(string account, string password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@Account",account),
                new SqlParameter("@Password",password),
            };
            var res = context.Database.SqlQuery<bool>("sp_account_login @Account, @Password", sqlParams).SingleOrDefault();
            return res;
        }
    }
}
