namespace Core.Models
{
    public class Drink : MenuItem
    {
        public decimal Price { get; set; }  // ← Dodano

        public bool IsAlcoholic { get; set; }

        public override string GetDescription()
        {
            return $"{Name} - {(IsAlcoholic ? "Alcoholic" : "Non-alcoholic")} - {Price:C}";
        }
    }
}
