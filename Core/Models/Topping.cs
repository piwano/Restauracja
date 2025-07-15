﻿namespace Core.Models
{
    public class Topping
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Topping(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} (+{Price} PLN)";
        }
    }
}