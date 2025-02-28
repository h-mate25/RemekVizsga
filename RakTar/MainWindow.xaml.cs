using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model.Entities;
using Model;
using Microsoft.EntityFrameworkCore;
using Model.Implemantations;
using System.Diagnostics;

namespace RakTar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ProcessManagerInterface _process;

        public MainWindow(ProcessManagerInterface process)
        {
            InitializeComponent();
            _process = process;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new WarehouseDbContext(
               new DbContextOptionsBuilder<WarehouseDbContext>()
                   .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RakKezelo_Database")
                   .Options))
            {
                var product = new Product
                {
                    name = txtProductName.Text,
                    barcode = int.Parse(txtBarcode.Text),
                    type = "Általános",
                    weight = 0.0,
                    price = 0.0,
                    onPallet = false,
                    pallet_id = null
                };
                context.Product.Add(product);
                context.SaveChanges(); // Save the product first

                // Create the process after the product is saved
                var processManager = new ProcessDatabaseManager(context);
                var pallets = new List<Pallets>();
                var products = new List<Products> { new Products { product_id = product.id, process_id = 1 } };
                var workerIds = new List<int?>();
                var incomingCargoIds = new List<int?>();
                var outgoingCargoIds = new List<int?>();

                processManager.CreateProcess("Termék felvétele", products, pallets, workerIds, incomingCargoIds, outgoingCargoIds);
                MessageBox.Show("Termék és folyamat sikeresen elmentve!");
            }
        }

    }
}