using System.Globalization;

namespace Core.Models
{
    public class Drink : MenuItem
    {
        public decimal Price { get; set; }
        public bool IsAlcoholic { get; set; }

        public string DisplayText => $"{Name} - {Price.ToString("0.00", new CultureInfo("pl-PL"))} zł";

        public override string GetDescription()
        {
            return $"{Name} - {Price.ToString("0.00", new CultureInfo("pl-PL"))} zł";
        }
    }
}
