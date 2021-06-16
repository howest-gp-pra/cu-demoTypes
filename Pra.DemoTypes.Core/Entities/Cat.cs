using System;
using System.Collections.Generic;
using System.Text;
using Pra.DemoTypes.Core.Enums;

namespace Pra.DemoTypes.Core.Entities
{
    public class Cat:Animal
    {
        private byte lives;
        public byte Lives 
        {
            get { return lives; }
            set
            {
                if (value > 9) value = 9;
                lives = value;
            }
        }
        public Cat(string name, Gender gender, DateTime? dateOfBirth, byte lives = 9)
            :base(name, gender, dateOfBirth)
        {
            Lives = lives;
        }

        // override ToString hoeft hier niet : de basisklasse Animal doet dit al

        public override string ShowDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ShowDetails());  // schrijf hier zeker de code niet meer opnieuw ... de basisklasse doe al al het werk ...
            // enkel nog het aantal levens toevoegen voor een kat
            sb.AppendLine($"Aantal levens : {lives}");
            return sb.ToString();
        }
    }
}
