using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantManagementSystem.Domain
{
    public abstract class Item
    {
        public int Id { get; protected set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        public Item(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
            this.CreatedAt = DateTime.Now;
            this.IsDeleted = false;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Food name can't be empty");
                return;

            }
            if (name.Length > 150)
            {
                Console.WriteLine("Food name is too long");
                return;
            }
            this.Name = name;
        }

        public void SetPrice(decimal price)
        {
            if (price < 0)
            {
                Console.WriteLine("Food price can't be negative");
                return;
            }
            this.Price = price;
        }

        public void Delete()
        {
            if (this.IsDeleted == true)
            {
                Console.WriteLine("Food is deleted already");
                return;
            }
            this.IsDeleted = true;
        }

        
    }
}
