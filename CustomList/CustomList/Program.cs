using System.Threading.Tasks.Dataflow;

namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> unsortedList = new CustomList<int> { 5, 3, 2, 6, 1, 7, 8 };
            unsortedList.Sort2();

            foreach (var item in unsortedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}