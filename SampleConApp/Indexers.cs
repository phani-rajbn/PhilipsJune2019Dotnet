using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
//Overloading the [] operator is called as INDEXing in C#. U could create index for UR classes to access the elements, data or members of the Class. 
namespace SampleConApp
{
    class Content
    {
        public int ContentID { get; set; }
        public string Heading { get; set; }
        public string NewsContent { get; set; }
        public string Reporter { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;//Default value for the Property.

        public string this[int index]
        {
            get
            {
                var list = GetType().GetProperties();
                return list[index].GetValue(this).ToString();
            }
        }
    }
    class Indexers
    {
        static void Main(string[] args)
        {
            Content article = new Content
            {
                ContentID = 1,
                Heading = "Pompeo meets PM Modi, discusses key strategic issues",
                NewsContent = "US Secretary of State Mike Pompeo met Prime Minister Narendra Modi on Wednesday and discussed various aspects of the bilateral relationship to strengthen the India-US strategic partnership.",
                Reporter = "Phaniraj"
            };
            Console.WriteLine(article[1]);
        }
    }
}
