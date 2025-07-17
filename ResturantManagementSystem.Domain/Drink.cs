using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantManagementSystem.Domain
{
    public sealed class Drink : Item
    {
        private static int _autoDrinksIds = 0;
        public bool IsHot { get; private set; }  // Hot Drink / Cold Drink
        public Drink(string name, decimal price, bool isHot) : base(name, price)
        {
            this.Id = ++_autoDrinksIds;
            this.IsHot = isHot;
        }

        public void SetIsHot(bool isHot)
        {
            this.IsHot = isHot;
        }

    }
}
