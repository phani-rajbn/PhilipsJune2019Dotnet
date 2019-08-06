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
using System.Windows.Shapes;
//Create a class called Product, it should have the following Properties:
/*
 * ProductID
 * ProductName
 * ProductPrice
 * ProductImage: String that contains the path of the image.....
 * Quantity
 * 
 * Create a ProductData class which has CRUD operations along with some static data. 
 * The data should be serializable. 
 */
namespace SampleWpfApp
{
    /// <summary>
    /// Interaction logic for ItemTemplates.xaml
    /// </summary>
    public partial class ItemTemplates : Window
    {
        public ItemTemplates()
        {
            InitializeComponent();
        }
    }
}
