namespace PriorityQueue
{
    class Menu
    {
        private readonly PrQueue pq = new();
        public void Run()
        {
            int v;
            do
            {
                v = GetMenuPoint();
                switch (v)
                {
                    case 1:
                        PutIn();
                        Write();
                        break;
                    case 2:
                        RemoveMax();
                        Write();
                        break;
                    case 3:
                        GetMax();
                        Write();
                        break;
                    case 4:
                        CheckEmpty();
                        Write();
                        break;
                    case 5:
                        Write();
                        break;
                    default:
                        Console.WriteLine("\nViszontlatasra!");
                        break;
                }
            } while (v != 0);
        }
        private static int GetMenuPoint()
        {
            int v;
            do
            {
                Console.WriteLine("\n********************************");
                Console.WriteLine("0. Kilepes");
                Console.WriteLine("1. Prior sorba berak");
                Console.WriteLine("2. Legnagyobbat kivesz");
                Console.WriteLine("3. Legnagyobbat lekerdez");
                Console.WriteLine("4. Ures-e vizsgalat");
                Console.WriteLine("5. Sort kiir");
                Console.WriteLine("****************************************");

                try
                {
                    v = int.Parse(Console.ReadLine()!);
                }
                catch (System.FormatException) { v = -1; }
            } while(v<0 || v>5);
            return v;
        }
        private void PutIn()
        {
            Element e = new();
            Console.WriteLine("Mit tegyunk be?");
            e.Read();
            pq.Add(e);
        }
        private void RemoveMax()
        {
            Element e;
            try
            {
                e = pq.RemMax();
                Console.WriteLine("Kivett elem:\n ({0}, {1})", e.pr, e.data);
            }
            catch (PrQueue.PrQueueEmpty)
            {
                Console.WriteLine("A kiveves nem sikerult! A pr.sor ures!\n");
            }
        }
        private void GetMax()
        {
            Element e;
            try
            {
                e = pq.GetMax();
                Console.WriteLine("Legnagyobb elem:\n ({0}, {1})", e.pr, e.data);
            }
            catch (PrQueue.PrQueueEmpty)
            {
                Console.WriteLine("A kiveves nem sikerult! A pr.sor ures!\n");
            }
        }
        private void CheckEmpty()
        {
            if (pq.IsEmpty())
                Console.WriteLine("A pr.sor ures.");
            else
                Console.WriteLine("A pr.sor nem ures.");
        }
        private void Write()
        {
            pq.Write();
        }

    }
}

