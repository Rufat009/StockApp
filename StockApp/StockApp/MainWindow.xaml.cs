using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

        private string productSearch;

        public string ProductSearch
        {

            get => productSearch;

            set
            {
                productSearch = value;

                OnPropertyChanged(nameof(ProductSearch));
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


        public List<Category> Categories { get; set; } = new List<Category>();
    

        private readonly string namePlaceHolder = "Enter product name...";

        private readonly string descriptionPlaceHolder = "Enter product description...";

        private readonly string countPlaceHolder = "Enter product count...";


        public MainWindow() 
        {
            InitializeComponent();

            this.productsRepository = App.ServiceContainer.GetInstance<IProductsRepository<Product>>();

            Products = productsRepository.GetAll();

            ProductName = this.namePlaceHolder;

            ProductDescription = this.descriptionPlaceHolder;

            ProductCount = this.countPlaceHolder;

            this.DataContext = this;
        }

        private async void AddProduct_Click(object sender, RoutedEventArgs e)
        {
           await productsRepository.AddAsync(new Product
            {
                Name = ProductName,

                Categories = Categories,

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

            product.Categories = Categories;

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

        private async void SearchProducts_Click(object sender, RoutedEventArgs e)
        {
             if (!string.IsNullOrWhiteSpace(ProductSearch))
            {
                Products = await productsRepository.SearchAsync(ProductSearch);
            }
             else
            {
                Products = productsRepository.GetAll();
            }
        }

        private void NameTextBox_OnFocus(object sender, RoutedEventArgs e)
        {
                ProductName = string.Empty;
        }

        private void DescriptionTextBox_OnFocus(object sender, RoutedEventArgs e)
        {
                ProductDescription = string.Empty;
        }

        private void CountTextBox_OnFocus(object sender, RoutedEventArgs e)
        {
                ProductCount = string.Empty;
        }

        private void CheckBox_FoodCheck(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkbox) 
            { 
                AddCategory(checkbox);
            }

        }

        private void CheckBox_ElectronicalEquipmentCheck(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkbox)
            {
                AddCategory(checkbox);
            }
        }

        private void CheckBox_ConstructionalMaterialCheck(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkbox) 
            { 
                AddCategory(checkbox); 
            }
        }

        private void AddCategory(CheckBox checkbox)
        {

            Enum.TryParse((string)checkbox.Content, out Category category);


            if (Categories.Contains(category))
            {
                Categories.Remove(category);   
                return;
            }

            Categories.Add(category);
        }
    }
}
