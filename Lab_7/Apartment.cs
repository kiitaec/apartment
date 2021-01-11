using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_7
{
    public partial class Apartment
    {
        public Apartment(int id, string name, string quantity, long price)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
            this.price = price;
        }


        public void SetId(int id)
        {
            this.id = id;
        }
        public void SetName(string name)
        {
            this.name = name;   
        }
        public void SetQuantity(string quantity)
        {
            this.quantity = quantity;
        }
        public void SetPrice(long price)
        {
            this.price = price;
        }
    }
}
