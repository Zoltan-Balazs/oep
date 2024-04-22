using System;
using TextFile;

namespace Fisher_Contest
{
    class Program
    {
        static void Main()
        {
            Organization org = new();
            try
            {
                TextFileReader reader = new("contests.txt");

                reader.ReadLine(out string line);
                char[] separators = new char[] { ' ', '\t' };
                string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (string fishername in tokens)
                {
                    org.Join(new Fisher(fishername)); // horgász példányosítása és beléptetése
                }

                while (reader.ReadLine(out string filename))
                {
                    TextFileReader reader1 = new(filename);

                    reader1.ReadLine(out line);
                    string[] conteststr = line.Split(
                        separators,
                        StringSplitOptions.RemoveEmptyEntries
                    );
                    Contest contest = org.Organize(conteststr[0], DateTime.Parse(conteststr[1])); // verseny kiírása

                    reader1.ReadLine(out line);
                    string[] fishernames = line.Split(
                        separators,
                        StringSplitOptions.RemoveEmptyEntries
                    );
                    foreach (string fishername in fishernames)
                    {
                        contest.SignUp(org.Search(fishername));
                    }

                    while (reader1.ReadString(out string fishername))
                    { // verseny eseményei
                        reader1.ReadString(out string timestr);
                        DateTime time = DateTime.Parse(conteststr[1][0..11] + timestr);
                        reader1.ReadString(out string fishname);
                        reader1.ReadDouble(out double weight);

                        Fisher fisher = org.Search(fishername);
                        switch (fishname)
                        {
                            case "keszeg":
                                fisher.Catch(time, Bream.Instance(), weight, contest);
                                break;
                            case "ponty":
                                fisher.Catch(time, Carp.Instance(), weight, contest);
                                break;
                            case "harcsa":
                                fisher.Catch(time, Catfish.Instance(), weight, contest);
                                break;
                        }
                    }
                }

                if (org.BestContest(out Contest contest1))
                    Console.WriteLine($"A legjobb verseny: {contest1.place}");
                else
                    Console.WriteLine("Nincs olyan verseny, ahol mindenki fogott harcsat.");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Hibás fájlnév");
            }
        }
    }
}
