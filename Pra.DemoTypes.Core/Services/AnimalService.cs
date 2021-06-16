using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pra.DemoTypes.Core.Entities;
using Pra.DemoTypes.Core.Enums;

namespace Pra.DemoTypes.Core.Services
{
    public class AnimalService
    {
        // we gaan de dieren deze keer niet aanbieden via een prop, maar gaan hiervoor een methode ter beschikking stellen (zie verder)
        // in de List<Animal> Animals (die hier dus een globaal veld is) gaan we wel in onze service klasse al onze dieren bijhouden (dit had ook een private prop mogen zijn)
        private List<Animal> animals;

        public AnimalService()
        {
            animals = new List<Animal>();
            Seeding();
        }
        private void Seeding()
        {
            animals.Add(new Cat("Minou", Gender.Vrouwelijk, new DateTime(2018, 1, 1), 9));
            animals.Add(new Cat("Felix", Gender.Mannelijk, new DateTime(2015, 1, 1)));  // hier zal automatisch de standaard waarde 9 gebruikt worden in de constructor
            animals.Add(new Cat("Monster", Gender.Onbekend, null, 5));
            animals.Add(new Dog("Sam", Gender.Mannelijk, new DateTime(2005, 5, 1), 3, "Border Collie"));
            animals.Add(new Dog("Pipa", Gender.Vrouwelijk, new DateTime(2020, 11, 29), 0, "Parson Russel"));
            animals = animals.OrderBy(a => a.GetType().Name).ThenBy(a => a.Name).ToList();
            //animals = animals.OrderBy(a => a.Name).ToList();
        }

        // we bieden een lijst aan met alle types van dieren die we hebben : uiteraard zal dit Cat en Dog zijn, maar het zouden er ook veel meer kunnen zijn ...
        public List<Type> GetAnimalTypes()
        {
            // er zijn veel manieren om dit op te lossen
            // dit is er een van ...
            // we overlopen al onze dieren en vragen telkens het type op
            // vervolgens voegen we dat type toe aan een List met types
            List<Type> availableTypes = new List<Type>();
            foreach(Animal animal in animals)
            {
                Type type = animal.GetType();
                // we zorgen er wel voor dat elk type (cat of dog dus) maar één keer voorkomt in deze List
                if(!availableTypes.Contains(type))
                {
                    availableTypes.Add(type);
                }
            }
            return availableTypes;
        }

        // we voorzien een methode die een list met dieren (animals) zal retourneren
        // de methode zal ofwel :
        //   * alle dieren retourneren via deze list
        //   * enkel de dieren die tot een bepaald type behoren via deze list
        // het argumenet van deze methode krijgt een defaultwaarde, namelijk null
        // wanneer we deze methode gaan oproepen en er wordt geen argument meegegeven (of null) dan zullen alle dieren in de list ziten
        // wanneer we deze methode gaan oproepen en er wordt wel een type meegegeven, dan zullen enkel de dieren van dat type in de list zitten
        public List<Animal> GetAnimals(Type animalType = null)
        {
            List<Animal> filteredAnimals = new List<Animal>();
            foreach(Animal animal in animals)
            {
                if (animalType == null)
                {
                    filteredAnimals.Add(animal);
                }
                else
                {
                    if (animal.GetType() == animalType)
                    {
                        filteredAnimals.Add(animal);
                    }
                }
            }
            return filteredAnimals;
        }


    }
}
