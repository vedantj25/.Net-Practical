using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    public class TempRecord
    {
        // Array of temperature values
        float[] temps = new float[10]
        {
        56.2F, 56.7F, 56.5F, 56.9F, 58.8F,
        61.3F, 65.9F, 62.1F, 59.2F, 57.5F
        };

        // To enable client code to validate input
        // when accessing your indexer.
        public int Length => temps.Length;

        // Indexer declaration.
        // If index is out of range, the temps array will throw the exception.
        public float this[int index]
        {
            get => temps[index];
            set => temps[index] = value;
        }
    }


    class DayCollection
    {
        string[] days = { "Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };

        // Indexer with only a get accessor with the expression-bodied definition:
        public int this[string day] => FindDayIndex(day);

        private int FindDayIndex(string day)
        {
            for (int j = 0; j < days.Length; j++)
            {
                if (days[j] == day)
                {
                    return j;
                }
            }

            throw new ArgumentOutOfRangeException(
                nameof(day),
                $"Day {day} is not supported.\nDay input must be in the form \"Sun\", \"Mon\", etc");
        }
    }

    internal class Indexers {
        
        public static void Main()
        {

            Console.WriteLine("Vedant Joshi                                      {0}\n\n", DateTime.Now);

            var tempRecord = new TempRecord();

            // Use the indexer's set accessor
            tempRecord[3] = 58.3F;
            tempRecord[5] = 60.1F;

            // Use the indexer's get accessor
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Element #{i} = {tempRecord[i]}");
            }

            var week = new DayCollection();
            Console.WriteLine(week["Fri"]);

            try
            {
                Console.WriteLine(week["Sat"]);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Not supported input: {e.Message}");
            }
        }

    }
}
