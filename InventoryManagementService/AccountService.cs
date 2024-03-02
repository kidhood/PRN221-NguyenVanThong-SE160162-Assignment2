using InventoryManagementBO.Models;
using InventoryManagementRepository;
using InventoryManagementRepository.Interface;
using InventoryManagementService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepo;

        public AccountService()
        {
            _accountRepo = new AccountRepository();
        }

        public Account GetAccountByUserNameAndPassword(string userName, string password)
        {
            return _accountRepo.GetAccountByUserNameAndPassword(userName, password);
        }

        public List<Account> GetAccounts()
        {
            return _accountRepo.GetAccount();
        }
    }
}
