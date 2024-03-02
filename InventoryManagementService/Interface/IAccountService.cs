using InventoryManagementBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementService.Interface
{
    public interface IAccountService
    {
        public List<Account> GetAccounts();

        public Account GetAccountByUserNameAndPassword(string userName, string password);  
    }
}
