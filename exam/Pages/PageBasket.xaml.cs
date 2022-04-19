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

namespace exam.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageBasket.xaml
    /// </summary>
    public partial class PageBasket : Page
    {
        double sale = 0;
        List<Books> Basket;
        public PageBasket(List<Books> basket)
        {
            InitializeComponent();
            Basket = basket;
            double cost = 0;
            int Count = 0;
            foreach (Books bb in basket)
            {
                Count += Convert.ToInt32(bb.CountBook);
                cost = cost + Convert.ToDouble(bb.Price) * Count;
            }
            sale = dll.Dll.SaleCost(Count, cost);
            List<Books> busketInList = new List<Books>();
            foreach (Books book in basket.Distinct().ToList())
            {
                book.CostSale = " " + (Math.Floor(Convert.ToDouble(book.Price) - (Convert.ToDouble(book.Price) * sale))).ToString();
                busketInList.Add(book);
            }
            BasketListBox.ItemsSource = busketInList;
            Basket = busketInList;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.GoBack();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Basket.Clear();
            BasketListBox.ItemsSource = Basket;
            BasketListBox.Items.Refresh();
        }
    }
}
