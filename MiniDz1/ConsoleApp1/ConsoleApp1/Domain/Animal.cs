namespace ZooERP.Domain
{
    public abstract class Animal : IAlive, IInventory
    {
        public int Food { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }

        public bool IsHealthy { get; set; }
    }
}