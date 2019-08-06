using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SampleWpfApp.Models
{
    [Serializable]
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; } = 1;
    }

    public class ProductData
    {
        const string file = @"C:\Users\phani\source\repos\PhilipsWPFTraining\WPFApps\SampleWpfApp\Data.xml";
        private List<Product> _products = new List<Product>();
        public ProductData()
        {
            _products.Add(new Product
            {
                Image = "Images/Apple.jpg",
                Price = 250,
                ProductID = 111,
                ProductName = "Kashmir Apples",
                Quantity = 1
            });
            _products.Add(new Product
            {
                Image = "Images/Banana.jpg",
                Price = 25,
                ProductID = 112,
                ProductName = "Juicy Bananas",
                Quantity = 1
            });
            _products.Add(new Product
            {
                Image = "Images/BlueGrapes.jpg",
                Price = 50,
                ProductID = 113,
                ProductName = "Blue Bangalore Grapes",
                Quantity = 1
            });
            _products.Add(new Product
            {
                Image = "Images/CherryFruit.jpg",
                Price = 150,
                ProductID = 114,
                ProductName = "Cherry Fruits",
                Quantity = 1
            });
            _products.Add(new Product
            {
                Image = "Images/Apple.jpg",
                Price = 250,
                ProductID = 115,
                ProductName = "Kashmir Apples",
                Quantity = 1
            });
            _products.Add(new Product
            {
                Image = "Images/Chikku.jpg",
                Price = 60,
                ProductID = 116,
                ProductName = "Tasty Chikku",
                Quantity = 1
            });
            _products.Add(new Product
            {
                Image = "Images/CusturdApple.jpg",
                Price = 90,
                ProductID = 117,
                ProductName = "Custurd Apples",
                Quantity = 1
            });
            _products.Add(new Product
            {
                Image = "Images/Pineapple.jpg",
                Price = 55,
                ProductID = 118,
                ProductName = "Pineapples",
                Quantity = 1
            });
            _products.Add(new Product
            {
                Image = "Images/Gauva.jpg",
                Price = 50,
                ProductID = 119,
                ProductName = "Green White Guavas",
                Quantity = 1
            });
            _products.Add(new Product
            {
                Image = "Images/Orange.jpg",
                Price = 40,
                ProductID = 120,
                ProductName = "Nagpur Oranges",
                Quantity = 1
            });
            if (!File.Exists(file))
                Serialize();
            else
                deserialize();
        }

        private void Serialize()
        {
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer xml = new XmlSerializer(typeof(List<Product>));
            xml.Serialize(fs, _products);
            fs.Close();
        }

        private void deserialize()
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            XmlSerializer xml = new XmlSerializer(typeof(List<Product>));
            _products = xml.Deserialize(fs) as List<Product>;
            fs.Close();
        }

        public List<Product> AllProducts => _products;
    }
}
