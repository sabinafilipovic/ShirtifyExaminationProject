Shirtify - Garderob p� din telefon
Shirtify �r en mobilapp utvecklad med .NET MAUI som hj�lper anv�ndare att hantera och organisera sin garderob direkt i telefonen. Appen g�r det m�jligt att fotografera och ladda upp kl�der f�r att skapa en digital garderob och ger �ven anv�ndaren aktuell v�derprognos f�r att kunna v�lja kl�der baserat p� v�dret.

Funktioner
Digital garderob: Ladda upp bilder p� dina kl�der och organisera dem direkt i appen.
V�derprognos: Integration av v�der-API f�r att visa aktuell v�derprognos, s� att du kan v�lja kl�der baserat p� v�dret.
Kamerafunktion: Ta bilder p� kl�der direkt i appen och ladda upp dem till din garderob.
Teknisk Stack
.NET MAUI: Multi-platform app-utveckling med .NET MAUI, vilket g�r det m�jligt att skapa en app som fungerar p� b�de Android och iOS.
C#: Programmeringsspr�ket som anv�nds f�r all logik i appen.
XAML: Anv�nds f�r att skapa och definiera anv�ndargr�nssnittet (UI). XAML-filer g�r det enkelt att beskriva strukturen och layouten av appens sidor, kontroller och element.
SQLite: Anv�nds f�r att lagra information om bilder, som filv�gar och metadata, i en lokal databas.
Visual Studio: Huvudverktyget f�r utveckling och debugging av appen.

API:er
Projektet anv�nder ett v�der-API f�r att h�mta aktuell v�derinformation. F�r att kunna anv�nda v�der-API:t, skapa ett konto p� OpenWeatherMap och anv�nd din API-nyckel.

L�gg till API-nyckeln i appens inst�llningar:
private const string ApiKey = "x";

F�rb�ttringar & Framtida Funktioner
Kategorisering av kl�der: L�gga till m�jlighet att kategorisera kl�der, till exempel "Tr�jor", "Byxor", "Jackor" etc.
Sparade outfitf�rslag: Baserat p� v�derprognos och anv�ndarens val, skapa outfitf�rslag.
Integration med sociala medier: Dela dina outfits med v�nner direkt fr�n appen.