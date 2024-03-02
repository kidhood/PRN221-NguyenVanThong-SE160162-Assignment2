using InventoryManagementBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDAO
{
    public class AccountDAO
    {
        private readonly InventoryManagementContext _dbContext = null;

        private static AccountDAO instance = null;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }

        public AccountDAO()
        {
            _dbContext = new InventoryManagementContext();
        }

        public List<Account> getAccount()
        {
            return _dbContext.Accounts.ToList();
        }

        public Account GetAccountByUserNamePassword(string userName, string password)
        {
            return _dbContext.Accounts.FirstOrDefault(acc => acc.UserName == userName && acc.Password == password);
        }
    }
}
