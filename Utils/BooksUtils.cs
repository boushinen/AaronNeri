using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOOKRESERVATION.Models;
using BOOKRESERVATION.Entity;
using Book = BOOKRESERVATION.Models.Book;

namespace BOOKRESERVATION.Utils
{
    public class BooksUtils
    {
        public static void Save(Book acc)
        {
            using (var db = new MyDatabaseEntities())
            {
                var book = db.BookTables.FirstOrDefault(x => x.BookID == acc.ID);
                if (book != null)
                {
                    book.BookAuthor = acc.Author;
                    book.BookTitle = acc.BookTitle;
                }
                else
                {
                    db.BookTables.AddObject(new Entity.BookTable { BookAuthor = acc.Author, BookTitle = acc.BookTitle });
                }
                db.SaveChanges();
            }
        }
        public static void Delete(int id)
        {
            using (var db = new MyDatabaseEntities())
            {
                var selected = db.BookTables.FirstOrDefault(x => x.BookID == id);
                if (selected != null)
                {

                    db.DeleteObject(selected);
                    db.SaveChanges();
                }
            }

        }
        public static List<Book> GetBooks(int id = 0)
        {
            using (var db = new MyDatabaseEntities())
            {

                if (id != 0)
                {
                    var a = db.BookTables.Where(i => i.BookID == id);
                    return a.Select(b => new Book { ID = b.BookID, Author = b.BookAuthor, BookTitle = b.BookTitle }).ToList();
                }
                else
                {
                    return db.BookTables.Select(b => new Book { ID =b.BookID , Author = b.BookAuthor, BookTitle = b.BookTitle }).ToList();
                }
            }
        }
    }
}