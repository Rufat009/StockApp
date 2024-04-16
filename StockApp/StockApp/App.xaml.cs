using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SimpleInjector;
using StockApp.Models;
using StockApp.Repositories;
using StockApp.Repositories.Base;

namespace StockApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container ServiceContainer { get; set; } = new Container();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ConfigureContainer();

            //var startView = new MainWindow();
            //startView.ShowDialog();

        }

        private void ConfigureContainer()
        {
            ServiceContainer.RegisterSingleton<IProductsRepository<Product>, ProductsRepository>();

            ServiceContainer.Verify();
        }


    }
}
