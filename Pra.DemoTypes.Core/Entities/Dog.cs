using System;
using System.Collections.Generic;
using System.Text;
using Pra.DemoTypes.Core.Enums;

namespace Pra.DemoTypes.Core.Entities
{
    public class Dog : Animal
    {
        public byte FavoriteLampposts { get; set; }
        public string Breed { get; set; }
        public Dog(string name, Gender gender, DateTime? dateOfBirth, byte favoriteLampposts, string breed)
            : base(name, gender, dateOfBirth)
        {
            FavoriteLampposts = favoriteLampposts;
            Breed = breed;
        }

        // override ToString hoeft hier niet : de basisklasse Animal doet dit al

        public override string ShowDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ShowDetails());  // schrijf hier zeker de code niet meer opnieuw ... de basisklasse doe al al het werk ...
            // enkel nog het ras en het aantal lantaarnpalen toevoegen voor een hond
            sb.AppendLine($"Ras : {Breed}");
            sb.AppendLine($"Aantal favoriete lantaarnpalen : {FavoriteLampposts}");
            return sb.ToString();
        }
    }
}
