using InventoryManagementBO.Models;
using InventoryManagementDAO;
using InventoryManagementRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementRepository
{
    public class AccountRepository : IAccountRepository
    {
        public List<Account> GetAccount()
        => AccountDAO.Instance.getAccount();

        public Account GetAccountByUserNameAndPassword(string userName, string password)
        => AccountDAO.Instance.GetAccountByUserNamePassword(userName, password);
    }
}
