using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace PracticeTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileDict dict = new FileDict();
            List<string> usedArgs = new List<string>();
            String fileName;
#if (DEBUG)

            ulong summaryMissingSpace = 0;
            DateTime launchTime = DateTime.Now;
            ulong minimalDetectionSize;

#endif
            fileName = args[0];
            usedArgs.Add(args[0]);

            try
            {
                minimalDetectionSize = ulong.Parse(args[1]);
                usedArgs.Add(args[1]);
            }
            catch
            {
                minimalDetectionSize = 0;
            }

            if (args[1].Equals("SortSum"))
            {
                dict.SetSortingOrder(FileDict.SortingOrder.increasingGroupSize);
                usedArgs.Add(args[1]);
            }

            if (args[2].Equals("SortSum"))
            {
                dict.SetSortingOrder(FileDict.SortingOrder.increasingGroupSize);
                usedArgs.Add(args[2]);
            }

            foreach (string directory in args.Except(usedArgs).Where(dir => !dir.Equals(minimalDetectionSize.ToString())))
            {
                dict.AddToList(directory);

                Console.WriteLine("!");

                
            }

            //dict.ShowDictionary("Res.txt");
            dict.ShowDictionary(fileName, minimalDetectionSize);
            fileName = "FailsIn" + fileName;
            dict.ShowUnopened(fileName);

#if (DEBUG)

            Console.WriteLine(dict.GetDuplicatesSize(FileDict.SizeFormat.megabytes) + "MB");
            Console.WriteLine(DateTime.Now - launchTime);
            Console.WriteLine(summaryMissingSpace);

#else

            Console.WriteLine("Release");
            Thread.Sleep(2000);

#endif
        }
    }
}
