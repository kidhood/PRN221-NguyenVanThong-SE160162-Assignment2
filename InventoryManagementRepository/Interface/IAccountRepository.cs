using InventoryManagementBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementRepository.Interface
{
    public interface IAccountRepository
    {
        public List<Account> GetAccount();

        public Account GetAccountByUserNameAndPassword(string userName, string password);
    }
}
