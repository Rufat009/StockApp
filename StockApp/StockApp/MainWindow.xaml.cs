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

                OnPropertyChanged(nameof(ProductName));
            }
        }

        private string productDescription;

        public string ProductDescription
        {

            get => productDescription;

            set
            {
                productDescription = value;

                OnPropertyChanged(nameof(ProductDescription));
            }
        }

        private string productCount;

        public string ProductCount
        {

            get => productCount;

            set
            {
                productCount = value;

                OnPropertyChanged(nameof(ProductCount));
            }
        }

        private Category productCategory;

        public Category ProductCategory
        {

            get => productCategory;

            set
            {
                productCategory = value;

                OnPropertyChanged(nameof(ProductCategory));
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

                OnPropertyChanged(nameof(Products));
            }
        }

        private Product productSelected;

        public Product ProductSelected
        {

            get => productSelected;

            set
            {
                productSelected = value;

                OnPropertyChanged(nameof(ProductSelected));
            }
        }


        public MainWindow() 
        {
            InitializeComponent();

            this.productsRepository = App.ServiceContainer.GetInstance<IProductsRepository<Product>>();

            Products = productsRepository.GetAll();

            this.DataContext = this;
        }

        private async void AddProduct_Click(object sender, RoutedEventArgs e)
        {
           await productsRepository.AddAsync(new Product
            {
                Name = ProductName,

                Category = ProductCategory,

                Count = int.Parse(ProductCount),

                Description = ProductDescription,
            });

            Products = productsRepository.GetAll();
        }

        private async void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            var product = ProductSelected;

            product.Name = ProductName;

            product.Description = ProductDescription;

            product.Category = ProductCategory;

            product.Count = int.Parse(ProductCount);

            await productsRepository.UpdateAsync(product);

            Products = productsRepository.GetAll();
        }

        private async void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            await productsRepository.DeleteAsync(ProductSelected.Id);

            Products = productsRepository.GetAll();
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
