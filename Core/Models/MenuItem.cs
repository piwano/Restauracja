namespace Core.Models
{
    public abstract class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public abstract string GetDescription();
    }
}
