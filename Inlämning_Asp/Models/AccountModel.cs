using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlämning_Asp.Data;

namespace Inlämning_Asp.Models
{
    public class AccountModel
    {
        private List<Account> accounts;

        public AccountModel()
        {
            accounts = new List<Account>() {
                new Account
                {
                    Username = "User",
                    Password = "user",
                    Roles = new string[]{ "user" }
                },
                new Account
                {
                    Username = "Admin",
                    Password = "admin",
                    Roles = new string[]{ "admin" }
                },
                new Account
                {
                    Username = "Organizer",
                    Password = "org",
                    Roles = new string[]{ "organizer" }
                }
            };
        }

        public Account find(string username)
        {
            return accounts.SingleOrDefault(a => a.Username.Equals(username));
        }

        public Account login(string username, string password)
        {
            return accounts.SingleOrDefault(a => a.Username.Equals(username) && a.Password.Equals(password));
        }
    }

}
