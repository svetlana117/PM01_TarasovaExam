using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace exam
{
    public partial class Books
    {
        public string Row1 { get; set; }
        public string Row2 { get; set; }
        public string Row3 { get; set; }
        public string Row4 { get; set; }
        public string Row5 { get; set; }
        public string Row6 { get; set; }
        public string ImagePath { get; set; }
        public static List<Books> GetBooks()
        {
            List<Books> ListBooks = BaseConnect.BaseModel.Books.ToList();
            foreach (Books books in ListBooks)
            {
                books.Row1 = "Название: " + books.Name + " | Жанр: " + books.Genre;
                books.Row2 = "Автор: " + books.Author;
                books.Row3 = "Цена: " + books.Price + " руб.";
                books.Row4 = "Количество в магазине: " + books.CountInStore;
                if (books.CountInStore == 0)
                {
                    books.Row4 = "Количество в магазине: нет";
                }
                else
                {
                    books.Row4 = "Количество в магазине: " + books.CountInStore;
                }
                if (books.CouinInStock > 5)
                {
                    books.Row5 = "Количество на складе: много";
                }
                else if (books.CouinInStock == 0)
                {
                    books.Row5 = "Количество на складе: нет";
                }
                else
                {
                    books.Row5 = "Количество на складе: " + books.CouinInStock;
                }
                books.Row6 = "Описание: " + books.Description;
                books.ImagePath = books.Image;

            }
            return ListBooks;
        }
    }

}

