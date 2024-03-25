using System.Globalization;

namespace AHM
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            Menu m = new();
            m.Run();
        }
    }

    //class of menu for diagonal matrix
    class Menu
    {
        private readonly AHM[] matrix = new AHM[2];
        private const int size = 3;

        public Menu()
        {
            matrix[0] = new AHM(size);
            matrix[1] = new AHM(size);
        }

        public void Run()
        {
            int n;
            do
            {
                MenuWrite();
                try
                {
                    n = int.Parse(Console.ReadLine()!);
                }
                catch (System.FormatException)
                {
                    n = -1;
                }
                switch (n)
                {
                    case 1:
                        GetElement(0);
                        break;
                    case 2:
                        GetElement(1);
                        break;
                    case 3:
                        SetElement(0);
                        break;
                    case 4:
                        SetElement(1);
                        break;
                    case 5:
                        WriteMatrix(0);
                        break;
                    case 6:
                        WriteMatrix(1);
                        break;
                    case 7:
                        Sum();
                        break;
                    case 8:
                        Mul();
                        break;
                }
            } while (n != 0);
        }

        private static void MenuWrite()
        {
            Console.WriteLine("\n\n 0. - Quit");
            Console.WriteLine(" 1. - Get an element of the matrix A");
            Console.WriteLine(" 2. - Get an element of the matrix B");
            Console.WriteLine(" 3. - Overwrite an element of the matrix A");
            Console.WriteLine(" 4. - Overwrite an element of the matrix B");
            Console.WriteLine(" 5. - Write matrix A");
            Console.WriteLine(" 6. - Write matrix B");
            Console.WriteLine(" 7. - Add matrices");
            Console.WriteLine(" 8. - Multiply matrices");
        }

        private void GetElement(int x)
        {
            do
            {
                try
                {
                    Console.WriteLine("Give the index of the row: ");
                    int i = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Give the index of the column: ");
                    int j = int.Parse(Console.ReadLine()!);
                    Console.WriteLine($"a[{i},{j}]={matrix[x][i, j]}");
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine($"Index must be between 1 and {size}");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"Index must be between 1 and {size}");
                }
            } while (true);
        }

        private void SetElement(int x)
        {
            do
            {
                try
                {
                    Console.WriteLine("Give the index of the row: ");
                    int i = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Give the index of the column: ");
                    int j = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Give the value: ");
                    double e = double.Parse(Console.ReadLine()!);
                    matrix[x][i, j] = e;
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine($"Valós számot kell megadni");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"Index must be between 1 and {size}");
                }
                catch (AHM.ReferenceToNullPartException)
                {
                    Console.WriteLine("Only the elements in the diagonal may be rewritten");
                }
            } while (true);
        }

        private void WriteMatrix(int x)
        {
            Console.Write(matrix[x].ToString());
        }

        private void Sum()
        {
            try
            {
                Console.Write((matrix[0] + matrix[1]).ToString());
            }
            catch (AHM.DifferentSizeException)
            {
                Console.Write("Különböző méretű mátrixokat nem lehet összeadni!");
            }
        }

        private void Mul()
        {
            try
            {
                Console.Write((matrix[0] * matrix[1]).ToString());
            }
            catch (AHM.DifferentSizeException)
            {
                Console.Write("Különböző méretű mátrixokat nem lehet összeszorozni!");
            }
        }
    }
}
