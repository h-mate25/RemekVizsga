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
                    name = txtProductName.Text, // A felhasználó által megadott név
                    barcode = int.Parse(txtBarcode.Text), // A vonalkód
                    type = "Általános", // Alapértelmezett típus
                    weight = 1.0, // Alapértelmezett súly
                    price = 2.0, // Alapértelmezett ár
                    onPallet = false // Alapértelmezett állapot
                };

                // Az entitás hozzáadása a dbContexthez
                context.Product.Add(product);

                // Az adatok mentése az adatbázisba
                context.SaveChanges();

                // Visszajelzés a felhasználónak
                MessageBox.Show("Termék sikeresen elmentve!");



                _process.CreateProcess("Termék felvétele");
                MessageBox.Show("Log mentve!");
            }
        }
    }
}