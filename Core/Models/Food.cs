namespace Core.Models
{
    public class Food : MenuItem
    {
        public decimal Price { get; set; }
        public bool IsVegetarian { get; set; }

        public override string GetDescription()
        {
            return $"{Name} - {Price} PLN {(IsVegetarian ? "(Wegetariañskie)" : "")}";
        }
    }
}
