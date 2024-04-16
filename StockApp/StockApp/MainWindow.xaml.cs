using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using StockApp.Models;
using StockApp.Repositories;
using StockApp.Repositories.Base;

namespace StockApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IProductsRepository<Product> productsRepository;

        private string productName;

        public string ProductName
        {

            get => productName;

            set
            {
                productName = value;

                PropertyChanged.Invoke(sender: this, new PropertyChangedEventArgs(nameof(ProductName)));
            }
        }

        private string productDescription;

        public string ProductDescription
        {

            get => productDescription;

            set
            {
                productDescription = value;

                PropertyChanged.Invoke(sender: this, new PropertyChangedEventArgs(nameof(ProductDescription)));
            }
        }

        private string productCount;

        public string ProductCount
        {

            get => productCount;

            set
            {
                productCount = value;

                PropertyChanged.Invoke(sender: this, new PropertyChangedEventArgs(nameof(ProductCount)));
            }
        }

        private string productCategory;

        public string ProductCategory
        {

            get => productCategory;

            set
            {
                productCategory = value;

                PropertyChanged.Invoke(sender: this, new PropertyChangedEventArgs(nameof(ProductCategory)));
            }
        }


        public IEnumerable<Category> Categories
        {
            get { return Enum.GetValues(typeof(Category)).Cast<Category>(); }
        }

        private IEnumerable<Product> products;

        public IEnumerable<Product> Products
        {

            get => products;

            set
            {
                products = value;

                PropertyChanged.Invoke(sender: this, new PropertyChangedEventArgs(nameof(Products)));
            }
        }

        private Product productSelected;

        public Product ProductSelected
        {

            get => productSelected;

            set
            {
                productSelected = value;

                PropertyChanged.Invoke(sender: this, new PropertyChangedEventArgs(nameof(ProductSelected)));
            }
        }


        public MainWindow()
        {
            InitializeComponent();

            this.productsRepository = new ProductsRepository();

            this.DataContext = this;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
