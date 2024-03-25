using System;
using TextFile;

namespace StarWars
{
    class Program
    {
        class NotExistingPlanetException : Exception { }

        static void Main()
        {
            SolarSystem ss = new("solarsystem.txt");
            try
            {
                TextFileReader reader = new("input.txt");

                reader.ReadInt(out int n);
                for (int i = 0; i < n; ++i)
                {
                    reader.ReadString(out string planetname);
                    Planet planet = ss.SearchPlanetbyName(planetname);
                    if (null == planet)
                        throw new NotExistingPlanetException();

                    reader.ReadInt(out int m);
                    for (int j = 0; j < m; ++j)
                    {
                        StarShip ship = null;
                        reader.ReadString(out string shipname);
                        reader.ReadString(out string type);
                        reader.ReadInt(out int s);
                        reader.ReadInt(out int a);
                        reader.ReadInt(out int g);
                        switch (type)
                        {
                            case "Breaker":
                                ship = new Breaker(shipname, s, a, g);
                                break;
                            case "Lander":
                                ship = new Lander(shipname, s, a, g);
                                break;
                            case "Laser":
                                ship = new Laser(shipname, s, a, g);
                                break;
                        }
                        ship.Protect(planet);
                    }
                }

                if (ss.MaxFireShip(out StarShip starship))
                    Console.WriteLine($"Best firepower starship: {starship.name}");
                else
                    Console.WriteLine("There is no planet with starships");

                Console.WriteLine(
                    $"shield of Earth: {ss.SearchPlanetbyName("Earth").TotalShield()}"
                );

                Console.WriteLine($"{ss.Defenseless().name} is defensless");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Hibás fájlnév");
            }
            catch (StarShip.StarShipInServiceException)
            {
                Console.WriteLine("Hibás fájlnév");
            }
            catch (StarShip.NotYourBuisnessException)
            {
                Console.WriteLine("Hibás fájlnév");
            }
        }
    }
}
