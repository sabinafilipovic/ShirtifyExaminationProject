## Shirtify - Garderob på din telefon

Shirtify är en mobilapp utvecklad med .NET MAUI som hjälper användare att hantera och organisera sin garderob direkt i telefonen. Appen gör det möjligt att fotografera och ladda upp kläder för att skapa en digital garderob och ger även användaren aktuell väderprognos för att kunna välja kläder baserat på vädret.

### Funktioner
- **Digital garderob**: Ladda upp bilder på dina kläder och organisera dem direkt i appen.
- **Väderprognos**: Integration av väder-API för att visa aktuell väderprognos, så att du kan välja kläder baserat på vädret.
- **Kamerafunktion**: Ta bilder på kläder direkt i appen och ladda upp dem till din garderob.

### Teknisk Stack
- **.NET MAUI**: Multi-platform app-utveckling med .NET MAUI
- **C#**: Programmeringsspråket som används för all logik i appen.
- **XAML**: Används för att skapa och definiera användargränssnittet (UI). XAML-filer gör det enkelt att beskriva strukturen och layouten av appens sidor, kontroller och element.
- **SQLite**: Används för att lagra information om bilder, som filvägar och metadata, i en lokal databas.
- **Visual Studio**: Huvudverktyget för utveckling och debugging av appen.

### API:er
Projektet använder ett väder-API för att hämta aktuell väderinformation. För att kunna använda väder-API:t, skapa ett konto på OpenWeatherMap och använd din API-nyckel.

Lägg till API-nyckeln i appens inställningar:

```csharp
private const string ApiKey = "x";
