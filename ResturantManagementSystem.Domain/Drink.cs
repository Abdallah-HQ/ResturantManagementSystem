﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantManagementSystem.Domain
{
    public sealed class Drink : Item
    {
        private static int _autoDrinksIds = 0;
        public DrinkType Type { get; private set; }
        public Drink(string name, decimal price, DrinkType type) : base(name, price)
        {
            this.Id = ++_autoDrinksIds;
            SetType(type);
        }

        public void SetType(DrinkType type)
        {
            if (Enum.IsDefined(typeof(DrinkType), type))
                throw new ArgumentException("Invalid drink type");
            
            this.Type = type;
        }

    }
}
