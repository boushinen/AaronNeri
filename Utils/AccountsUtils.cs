using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOOKRESERVATION.Models;
using BOOKRESERVATION.Entity;
using Account = BOOKRESERVATION.Models.Account;
using br = BOOKRESERVATION.Models.BookReservationInfo;

namespace BOOKRESERVATION.Utils
{
    public class AccountsUtils
    {
        public static List<Account> GetAccounts(int id = 0)
        {
            using (var db = new MyDatabaseEntities())
            {

                if (id != 0)
                {
                    var a = db.AccountTables.Where(i => i.ID == id);
                    return a.Select(b => new Account { Id = b.ID, Name = b.Name, Age = b.Age, Address = b.Address, Username = b.Username, Password =b.Password}).ToList();
                }
                else
                {
                    return db.AccountTables.Select(b => new Account { Id = b.ID,Name = b.Name, Age = b.Age, Address = b.Address, Username = b.Username, Password = b.Password }).ToList();
                }
            }
        }
        public static void reserve()
        {
             using (var db = new MyDatabaseEntities())
            db.BookReservations.AddObject(new Entity.BookReservation{BookID })
        }

        public static void Save(Account acc)
        {
            using (var db = new MyDatabaseEntities())
            {
                var account = db.AccountTables.FirstOrDefault(x => x.ID == acc.Id);
                if (account != null)
                {
                    account.Name = acc.Name;
                    account.Age = acc.Age;
                    account.Address = acc.Address;
                    account.Username = acc.Username;
                    account.Password = acc.Password;
                }
                else
                {
                    db.AccountTables.AddObject(new Entity.AccountTable {ID= acc.Id, Name = acc.Name, Address = acc.Address, Age = acc.Age, Username = acc.Username, Password = acc.Password });
                    //db.BookTables.AddObject(new Entity.BookTable { BookAuthor = acc.Author, BookTitle = acc.BookTitle });
                }
                db.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var db = new MyDatabaseEntities())
            {
                var selected = db.AccountTables.FirstOrDefault(x => x.ID == id);
                if (selected != null)
                {

                    db.DeleteObject(selected);
                    db.SaveChanges();
                }
            }

        }

        public static bool ValidAccountNamePassword(string username, string password)
        {
            var selectedUser = AccountsUtils.GetAccounts().FirstOrDefault(x => x.Username == username && x.Password == password);
            return selectedUser != null;
        }

    }
}