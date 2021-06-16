using System;
using System.Collections.Generic;
using System.Text;
using Pra.DemoTypes.Core.Enums;
namespace Pra.DemoTypes.Core.Entities
{
    public abstract class Animal
    {
        private string name;
        public string Name
        {
            get { return Name; }
            set
            {
                // beveiliging van je data via de setter van je prop laten gebeuren, niet via de constructor
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Naam kan niet leeg zijn");
                name = value;
            }

        }
        public Gender Gender { get; set; }
        public DateTime? DateOfBirth { get; set; } // hou er overal rekening mee dat dit een nullable datetime is : je zal waarschijnlijk vaak eerst moeten casten naar een gewone datetime
        public string Age
        {
            // Age wordt berekend op basis van DateOfBirth en de huidige datum
            // alle code hiervoor kan in het getter gedeelte geschreven worden (of in een methode die hier dan opgeroepen wordt)
            get
            {
                if (DateOfBirth == null)
                    return "Onbekend";
                else
                {
                    int age = DateTime.Today.Year - ((DateTime)DateOfBirth).Year;
                    if (((DateTime)DateOfBirth).Date > DateTime.Today.AddYears(-age)) age--;
                    return age.ToString() + " jaar";
                }

            }
        }

        public Animal(string name, Gender gender, DateTime? dateOfBirth)
        {
            Name = name;  //Prop Name vullen en NIET private variabele name zodat de beveiliging van de setter zeker wordt uitgevoerd
            Gender = gender;
            DateOfBirth = DateOfBirth;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} - {name} - leeftijd : {Age}";
        }
        public virtual string ShowDetails()  // VIRTUAL : niet vergeten aan te geven dat deze methode door afgeleid klassen mag overschreven worden !
        {
            // veel tekst te concateneren ?  gebruik dan een stringbuilder !
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Diersoort : {this.GetType().Name}");
            sb.AppendLine($"Roepnaam : {name}");
            sb.AppendLine($"Geslacht : {Gender.ToString()}");
            string geboortedatum = DateOfBirth == null ? "Onbekend" : ((DateTime)DateOfBirth).ToString("dd/MM/yyyy");
            
            // alternatieve manier voor bovenstaande shorthand if : 
            // string geboortedatum
            //if (DateOfBirth == null)
            //    geboortedatum = "Onbekend";
            //else
            //{
            //    DateTime gebdat = (DateTime)DateOfBirth;
            //    geboortedatum = gebdat.ToString("dd/MM/yyyy");
            //}
                        
            sb.AppendLine($"Geboortedatum : {geboortedatum}");
            sb.AppendLine($"Leeftijd : {Age}");
            return sb.ToString();  // vergeet de stringbuilder niet te converteren naar een string
        }

    }
}
