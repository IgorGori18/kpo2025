namespace ZooERP.Domain
{
    public abstract class Herbo : Animal
    {
        public int Kindness { get; set; }
        public bool CanInteract => Kindness > 5;
        
    }
}