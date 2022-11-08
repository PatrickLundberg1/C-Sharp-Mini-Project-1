using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Mini_Project_1
{
    internal class Asset
    {
        public Asset(string brand, string model, string office, DateTime purchase_date, int price)
        {
            Brand = brand;
            Model = model;
            Office = office;
            Purchase_date = purchase_date;
            Price = price;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string Office { get; set; }
        public DateTime Purchase_date { get; set; }
        public int Price { get; set; }
    }
}
