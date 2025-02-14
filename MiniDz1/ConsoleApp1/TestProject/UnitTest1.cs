using System;
using System.IO;
using System.Linq;
using Xunit;
using ZooERP.Domain;
using ZooERP.Inventory;
using ZooERP.Services;
using ZooERP.Zoo;

namespace ZooERP.Tests
{
    public class VetClinicTests
    {
        [Fact]
        public void CheckAnimal_Healthy_ReturnsTrue()
        {
            // Arrange
            var vet = new VetClinic();
            var rabbit = new Rabbit { Name = "Банни", Food = 2, Number = 101, Kindness = 7 };

            // Act
            bool result = vet.CheckAnimal(rabbit);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckAnimal_Unhealthy_ReturnsFalse()
        {
            // Arrange
            var vet = new VetClinic();
            // Здесь имя содержит "Нездоровый" (или "Болен"), поэтому должно возвращаться false
            var sickRabbit = new Rabbit { Name = "Нездоровый Кролик", Food = 2, Number = 102, Kindness = 7 };

            // Act
            bool result = vet.CheckAnimal(sickRabbit);

            // Assert
            Assert.False(result);
        }
    }

    public class ZooTests
    {
        private readonly IVetClinic _vetClinic;
        private readonly IZoo _zoo;

        public ZooTests()
        {
            _vetClinic = new VetClinic();
            _zoo = new ZooPark(_vetClinic);
        }

        [Fact]
        public void AddAnimal_HealthyAnimal_IsAdded()
        {
            var rabbit = new Rabbit { Name = "Банни", Food = 2, Number = 101, Kindness = 7 };

            bool added = _zoo.AddAnimal(rabbit);

            Assert.True(added);
            
            Assert.Contains(rabbit, ((_zoo as ZooPark).Animals));
        }

        [Fact]
        public void AddAnimal_UnhealthyAnimal_IsNotAdded()
        {
            var sickRabbit = new Rabbit { Name = "Боленый Кролик", Food = 2, Number = 102, Kindness = 7 };

            bool added = _zoo.AddAnimal(sickRabbit);

            Assert.False(added);
            Assert.DoesNotContain(sickRabbit, ((_zoo as ZooPark).Animals));
        }

        [Fact]
        public void GetTotalFood_ReturnsCorrectSum()
        {
            _zoo.AddAnimal(new Rabbit { Name = "Банни", Food = 2, Number = 101, Kindness = 7 });
            _zoo.AddAnimal(new Tiger { Name = "Шерхан", Food = 10, Number = 102 });
            _zoo.AddAnimal(new Monkey { Name = "Мартышка", Food = 3, Number = 103 });

            int totalFood = _zoo.GetTotalFood();

            Assert.Equal(15, totalFood);
        }

        [Fact]
        public void GetContactZooAnimals_ReturnsOnlyAnimalsThatCanInteract()
        {
            var rabbit = new Rabbit { Name = "Банни", Food = 2, Number = 101, Kindness = 7 }; // Kindness > 5
            var weakRabbit = new Rabbit { Name = "Слабый Кролик", Food = 2, Number = 102, Kindness = 4 }; // Kindness <= 5
            _zoo.AddAnimal(rabbit);
            _zoo.AddAnimal(weakRabbit);

            var contactAnimals = _zoo.GetContactZooAnimals().ToList();

            Assert.Single(contactAnimals);
            Assert.Contains(rabbit, contactAnimals);
        }

        [Fact]
        public void AddThing_And_GetAllInventory_ReturnsCombinedList()
        {
            var rabbit = new Rabbit { Name = "Банни", Food = 2, Number = 101, Kindness = 7 };
            _zoo.AddAnimal(rabbit);
            var table = new Table { Name = "Стол", Number = 201 };
            var computer = new Computer { Name = "Компьютер", Number = 202 };
            _zoo.AddThing(table);
            _zoo.AddThing(computer);

            var inventory = _zoo.GetAllInventory().ToList();

            Assert.Equal(3, inventory.Count);
            Assert.Contains(rabbit, inventory);
            Assert.Contains(table, inventory);
            Assert.Contains(computer, inventory);
        }

        [Fact]
        public void PrintInventory_WritesExpectedOutput()
        {
            
            // Создаем отдельный экземпляр зоопарка для тестирования вывода
            var localZoo = new ZooPark(_vetClinic);
            localZoo.AddAnimal(new Rabbit { Name = "Банни", Food = 2, Number = 101, Kindness = 7 });
            localZoo.AddThing(new Table { Name = "Стол", Number = 201 });
            localZoo.AddThing(new Computer { Name = "Компьютер", Number = 202 });

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                localZoo.PrintInventory();
                string output = sw.ToString();

                Assert.Contains("Животное: Банни, Инвентарный номер: 101", output);
                Assert.Contains("Вещь: Стол, Инвентарный номер: 201", output);
                Assert.Contains("Вещь: Компьютер, Инвентарный номер: 202", output);
            }
        }
    }
}
