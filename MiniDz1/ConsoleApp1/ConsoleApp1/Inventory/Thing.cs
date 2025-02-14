using ZooERP.Domain;

namespace ZooERP.Inventory
{
    public class Thing : IInventory
    {
        public int Number { get; set; }
        public string Name { get; set; }

    }
}