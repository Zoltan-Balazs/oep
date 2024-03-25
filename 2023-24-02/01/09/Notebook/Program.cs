using System.Text;

namespace Notebook
{
    internal class Program
    {
        static void Main()
        {
            Notebook notebook = new(32, Notebook.Sort.lined);
            Console.WriteLine($"Type of notebook: {notebook.Type}");
            Console.WriteLine(
                $"Number of pages: {notebook.Count()}, Empty pages: {notebook.EmptyCount()}"
            );

            notebook.Write(1);
            notebook.Write(2);
            notebook.Remove(1);
            Console.WriteLine(
                $"Number of pages: {notebook.Count()}, Empty pages: {notebook.EmptyCount()}"
            );

            Notebook.BoolxNat l = notebook.Search();
            if (l.b)
            {
                Console.WriteLine($"Found empty page: {l.n}");
                notebook.Write(l.n);
            }
            else
                Console.WriteLine($"No empty pages");
            Console.WriteLine(
                $"Number of pages: {notebook.Count()}, Empty pages: {notebook.EmptyCount()}"
            );
        }
    }
}
