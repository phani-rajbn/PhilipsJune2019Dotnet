using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExample.Models
{
    public class SampleModel
    {
        private string data = string.Empty;

        public SampleModel()
        {
            data = "Good Afternoon MVVM";
        }
        public string Welcome
        {
            get { return data; }
            set
            {
                data = value;
            }
        }
    }
}
