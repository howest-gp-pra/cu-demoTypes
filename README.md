# Demo : extra voorbeeld rond werken met **TYPES**  

Er waren een aantal vragen van studenten rond het werken met types : meer in het bijzonder hoe je types van objecten kunt gebruiken om een collectie te filteren (denk aan je PE opdracht rond HEATERS (woodstove, pelletstove, gasradiator ...)  

In dit eenvoudige project kan je nog eens een voorbeeld nakijken.  Ik heb er eveneens nog een aantal zaken/voorbeelden in opgenomen waarvan ik gemerkt heb bij de verbetering van jullie PE opdrachten dat er nogal wat fouten tegen gemaakt werden.  
Waarover gaat het : 

  * we hebben een basisklasse **Animal**  
    * van deze klasse mag geen instantie kunnen gemaakt worden   
    * de klasse heeft volgende eigenschappen :   
      * Name, string,  mag niet leeg zijn.  Indien wel leeg : fout opgooien  
      * Gender, enumeratiewaarde Gender  
      * DateOfBirth, datumtijd waarde die een null mag bevatten  
      * Age, string, readonly : geeft de ouderdom van het dier in jaren op basis van de geboortedatum, eventueel "onbeken" indien geboortedatum niet gekend is  
    * Er is 1 consturctor die de waarden voor alle props (behalve Age) ontvangt  
    * De ToString methode wordt overschreven en vervangen door :  <soort dier> - naam - leeftijd   
      Met <soort dier> bedoelen we het type van de betrokken klasse
      Deze override ToString is van toepassing voor deze klasse, maar is identiek voor alle afgeleide klassen (m.a.w. je hoeft in de afgeleide klassen de ToString niet meer te overschrijven)  
    * Er is een methode ShowDetails() die door de afgeleide klasse mag overschreven worden en die alle informatie over het dier toont in volgende vorm : 
      >  Voorbeeld : 
      >  
      >  Diersoort : xxx   
      >  Roepnaam : xxx   
      >  Geslacht : xxx   
      >  Geboortedatum : xxx   
      >  Leeftijd : xxx     
         
      Ter info : omdat er geen instantie kan gemaakt worden van deze klasse zelf zal deze methode ook nooit echt uitgevoerd worden.  In de afgeleide klassen (waarvan wel instanties kunnen gemaakt worden) gaan we deze methode overschrijven en verder uitwerken.
  * we hebben de klasse **Cat** die overerft van **Animal**   
    * Deze klasse heeft 1 bijkomende eigenschap   
      * Lives, byte, mag niet groter zijn dan 9, indien toch groter aanpassen naar 9   
    * Deze constructor ontvangt alle waarden die de basisklasse nodig heeft plus een bijkomende waarde t.b.v. de prop Lives : dit laatste argument krijgt trouwens de standaardwaarde 9 mee.
    * Deze klasse overschrijft de ShowDetails() methode van de basisklasse en voegt nog extra info toe : 
      >  Voorbeeld :    
      >    
      >  Diersoort : cat  
      >  Roepnaam : Minous  
      >  Geslacht : vrouwelijk  
      >  Geboortedatum : 1/1/2010  
      >  Leeftijd : 11 jaar       
      >  Aantal levens : 9 
  * we hebben de klasse **Dog** die overerft van **Animal**   
    * Deze klasse heeft 2 bijkomende eigenschappen  
      * FavoriteLampposts, byte
      * Breed, string
    * Deze constructor ontvangt alle waarden die de basisklasse nodig heeft plus twee bijkomende waarde t.b.v. de props FavoriteLampposts en Breed  
    * Deze klasse overschrijft de ShowDetails() methode van de basisklasse en voegt nog extra info toe : 
      >  Voorbeeld :    
      >    
      >  Diersoort : dog  
      >  Roepnaam : Sam  
      >  Geslacht : mannelijk  
      >  Geboortedatum : 1/1/2010  
      >  Leeftijd : 11 jaar       
      >  Ras : Border Collie
      >  Aantal favoriete lantaarnpalen : 7     
           
Er is 1 serviceklasse : **AnimalService**    
  * In deze klasse houden we een lijst bij van onze 2 soorten dieren (cat & dog).   
    De constructor dient voor seeding te zorgen.   
    De lijst (List<Animal>) gaan we deze keer niet publiek maken.   
    De beschikbare dieren zullen aangeboden worden m.b.v. een methode.  
    
    Er zijn 2 methoden : 
    * GetAnimalTypes() : deze methode retourneert een lijst met types (dus List<Type> )  
      Deze methode moet dus in onze lijst met dieren gaan kijken welke types daar allemaal gebruikt worden : dat zal dus uiteraard Cat en Dog zijn, maar we mogen daar niet zo maar van uit gaan ... in de toekomst komen daar misschien nog heel wat andere diersoorten bij ...  
      We overlopen dus dus de lijst met beschikbare dieren en vragen van elk die op tot welk type dat dier behoort (GetType() ).
      Eenmaal we dit type hebben gaan we op zoek in de lijst met types dat we aan het opbouwen zijn of dit type al in deze lijst zit : is dat nog niet het geval, dan moet het daar aan toegevoegd worden.  
    * GetAnimals(... ) : deze methode retourneert een lijst van dieren (dus List<Animal> )  
      De methode heeft ook 1 argument van het type Type dat standaard de null waarde krijgt.  
      Is het argument = null, dan worden alle beschikbare dieren geretourneerd.  
      Is het argument != null - is er m.a.w. wel een type meegeleverd - dan worden enkel de dieren die tot dat type behoren geretourneerd.   
       
De GUI is uiteraard door mij geprogrammeerd, maar ik laat het aan jullie over om zelf even de code te doorlopen : deze is vrij voor de hand liggend ...  


    
    
