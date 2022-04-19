using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using exam.Pages;


namespace exam.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageBooks.xaml
    /// </summary>
    public partial class PageBooks : Page
    {
        List<Books> Basket = new List<Books>();
        List<Books> ListBooks = Books.GetBooks();
        public PageBooks()
        {
            InitializeComponent();
            ListBoxBooks.ItemsSource = ListBooks;

        }
        public PageBooks(List<Books> Basket)
        {
            InitializeComponent();
            ListBoxBooks.ItemsSource = ListBooks;
            this.Basket = Basket;
            double cost = 0;
            int count = 0;
            foreach (Books book1 in Basket)
            {
                count += Convert.ToInt32(book1.CountBook);
                cost = cost + Convert.ToDouble(book1.Price) * Convert.ToDouble(book1.CountBook);
            }
            CountSelectBook.Text = count.ToString();
            double Sale = dll.dll.SaleCost(Convert.ToInt32(count), cost);
            СostSaleSelectBook.Text = " " + (cost - (cost * Sale)).ToString();
            СostSelectBook.Text = cost.ToString();
            СostSelectBook.Visibility = Visibility.Visible;
            SaleProcentBook.Text = (Sale * 100).ToString();
            if (Basket.Count == 0)
            {
                BaseConnect.BaseModel = new Entities();
                ListBooks = Books.GetBooks();
                ListBoxBooks.ItemsSource = ListBooks;
                ListBoxBooks.Items.Refresh();
            }
        }


        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = (Button)sender;
            int id = Convert.ToInt32(senderButton.Uid);
            Books book = ListBooks.FirstOrDefault(x => x.id == id);
            if (book != null)
            {
                if (Convert.ToInt32(book.CountBook) + 1 <= book.CouinInStock + book.CountInStore)
                {
                    book.CountBook = (Convert.ToInt32(book.CountBook) + 1).ToString();
                    if (Basket.Where(x => x.id == id).Count() > 0)
                    {
                    }
                    else
                    {
                        Basket.Add(ListBooks.FirstOrDefault(x => x.id == id));
                    }
                    ListBoxBooks.ItemsSource = ListBooks;
                    double cost = 0;
                    int count = 0;
                    foreach (Books bb in Basket)
                    {
                        count += Convert.ToInt32(bb.CountBook);
                        cost = cost + Convert.ToDouble(bb.Price) * Convert.ToDouble(bb.CountBook);
                    }
                    CountSelectBook.Text = count.ToString();
                    double Sale = dll.dll.SaleCost(Convert.ToInt32(count), cost);
                    СostSaleSelectBook.Text = " " + (cost - (cost * Sale)).ToString();
                    СostSelectBook.Text = cost.ToString();
                    СostSelectBook.Visibility = Visibility.Visible;
                    ListBoxBooks.Items.Refresh();
                    SaleProcentBook.Text = (Sale * 100).ToString();
                }
                else MessageBox.Show("Книги нет в наличии");
            }
        }
        private void ShowBasket_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.Navigate(new PageBasket(Basket));
        }

    }
}
