using ZooERP.Domain;

namespace ZooERP.Services
{
    public class VetClinic : IVetClinic
    {
        public bool CheckAnimal(Animal animal)
        {
            // Если животное потребляет больше 0 кг еды в день, считаем его здоровым.
            return animal.Food > 0;
        }
    }
}