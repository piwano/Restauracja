using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Core.Models
{
    public class Food : MenuItem
    {
        public decimal BasePrice { get; set; }
        public bool IsVegetarian { get; set; }
        public List<Topping> Toppings { get; set; } = new();

        public decimal TotalPrice => BasePrice + Toppings.Sum(t => t.Price);

        public override string GetDescription()
        {
            string toppingsText = Toppings.Any()
                ? " + " + string.Join(", ", Toppings.Select(t => t.Name))
                : "";

            string vegetarianText = IsVegetarian ? " (Wegetariañskie)" : "";

            return $"{Name}{toppingsText} - {TotalPrice.ToString("0.00", new CultureInfo("pl-PL"))} z³{vegetarianText}";
        }
    }
}
