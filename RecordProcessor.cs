using System;
using System.Collections;
using System.Linq;

namespace Task5
{
    public class RecordProcessor
    {
        public static void Search(Record[] db)
        {
            var results = db
                .GroupBy(g => new { g.ClientID, g.Year })
                .Select(g => new {
                    g.Key.ClientID,
                    g.Key.Year,
                    Sum = g.ToList().Sum(x => x.Duration)
                })
                .ToList();
            foreach (var el in results)
                Console.WriteLine($"{el.ClientID} {el.Year} {el.Sum}");
        }
    }
}