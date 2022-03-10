using GoEat.Logic.Order.ValueObjects;

namespace GoEat.Logic.Menu
{
    public class Category
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public ICollection<MenuItem> Menus { get; set; }
    }
}
