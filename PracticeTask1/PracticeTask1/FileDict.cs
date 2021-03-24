using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Security.Cryptography;

namespace PracticeTask1
{
    struct fCode
    {
        public ulong size;
        public byte[] hash;
        //*
        #region operators defining

        public static bool operator == (fCode a, fCode b)
        {
            return (a.size == b.size) && Enumerable.SequenceEqual(a.hash, b.hash);
        }

        public static bool operator != (fCode a, fCode b)
        {
            return (a.size != b.size) || !Enumerable.SequenceEqual(a.hash, b.hash);
        }

        #endregion
        //*/
        #region standart functions override

        public override bool Equals(object b)
        {
            if (!(b is fCode))
                return false;

            //return b.GetHashCode() == this.GetHashCode();
            return (fCode)b == this;
        }

        private int ArrHash(byte[] arr)
        {
            int hash = arr[0];

            for (int i = 1; i < arr.Length; i++)
                hash ^= arr[i];

            return hash;
        }

        public override int GetHashCode()
        {
            return size.GetHashCode() ^ ArrHash(hash);
            //return base.GetHashCode();
        }
        
        public override string ToString()
        {
            return size.ToString();
        }

        #endregion
    };

    class FileDict
    {

        public enum SizeFormat
        {
            bytes = 0,
            kilobyes = 10,
            megabytes = 20,
            gigabytes = 30,
            terabytes = 40
        };

        public enum SortingOrder
        {
            increasingGroupSize,
            increasingMemberSize,
            //decreasingGroupSize,
            //decreasingMemberSize
        };

        #region

        private bool sortGroups = false;

        public void SetSortingOrder(SortingOrder so)
        {
            sortGroups = so == SortingOrder.increasingGroupSize;
        }

        #endregion

        public Dictionary<fCode, List<string>> dictionary = new Dictionary<fCode, List<string>>();
        public List<string> unopenedDirectories;
        public List<string> unopenedFiles;

        public FileDict() //Constructor
        {
            //dictionary = new Dictionary<fCode, List<string>>();
            unopenedDirectories = new List<string>();
            unopenedFiles = new List<string>();
        }

        private void PrintList(List<string> list, fCode key) //Ptints all equal files in console
        {
            Console.WriteLine("\nFile group with size " + key.size + "\n");
            foreach (string str in dictionary[key])
                Console.WriteLine(str);
            Console.WriteLine("\nGroup end\n================\n");
        }

        private void PrintList(List<string> list, fCode key, StreamWriter file) //Prints all equal files
        {
            file.WriteLine();
            file.WriteLine("File group with size " + key.size);
            file.WriteLine();
            foreach (string str in dictionary[key])
                file.WriteLine(str);
            file.WriteLine();
            file.WriteLine("Group end");
            file.WriteLine("================");
            file.WriteLine();
        }

        public void AddToList(string rootDirectory) //Recursive function, which ads all files from rootDirectory
        {
            DirectoryInfo curDI;

            try
            {
                curDI = new DirectoryInfo(rootDirectory);

                if(!curDI.Exists)
                {
                    unopenedDirectories.Add(rootDirectory);
                    return;
                }
            }
            catch
            {
                unopenedDirectories.Add(rootDirectory);
                return;
            }

            using (SHA1Managed sha1 = new SHA1Managed())
            {
                FileInfo[] fInfoArray = curDI.GetFiles();
                FileStream fileStream;
                fCode key;
                //SHA1Managed sha1 = new SHA1Managed();

                foreach (FileInfo fInfo in fInfoArray)
                {
                    try
                    {
                        using (fileStream = new FileStream(fInfo.FullName, FileMode.Open))
                        {

                            key.size = (ulong)fInfo.Length;
                            key.hash = new byte[20];
                            key.hash = sha1.ComputeHash(fileStream);
                        }
                        //Console.WriteLine("File " + fInfo.Name + " computed"); //DEBUG_OUTPUT

                        //fileStream.Close();

                        if (!dictionary.ContainsKey(key))
                            dictionary[key] = new List<string>();

                        dictionary[key].Add(fInfo.FullName);
                    }
                    catch
                    {
                        Console.WriteLine("Failed to open file " + fInfo.FullName);
                        unopenedFiles.Add(fInfo.FullName);
                        continue;
                    }
                }

                //sha1.Dispose();
            }

            
            DirectoryInfo[] dirInfoArray = curDI.GetDirectories();

            foreach (DirectoryInfo dirInfo in dirInfoArray)
            {
                try
                {
                    AddToList(dirInfo.FullName);
                }
                catch
                {
#if (DEBUG)
                    Console.WriteLine("Failed to open directory " + dirInfo.FullName);
#endif
                    unopenedDirectories.Add(dirInfo.FullName);
                    continue;
                }

                Console.WriteLine("Directory " + dirInfo.FullName + " computed"); //DEBUG_OUTPUT
            }
            
            
        }

        public void ShowDictionary(string fileName) //Writes data, collected in this object
        {
            StreamWriter fileStream = new StreamWriter(fileName);
            
            foreach (var p in dictionary.Where(x => x.Value.Count > 1).OrderBy(x => x.Key.size * (ulong)(x.Value.Count - 1)))
            {
                PrintList(dictionary[p.Key], p.Key, fileStream);
            }

            fileStream.Close();
        }

        public void ShowDictionary(string fileName, ulong minimalSize)
        {
            
            StreamWriter fileStream = new StreamWriter(fileName);
            //*
            //Sorted variant
            foreach (var p in dictionary.Where(x => x.Value.Count > 1).Where(x => x.Key.size >= minimalSize).OrderBy(x => x.Key.size + x.Key.size * (sortGroups ? (ulong)1 : (ulong)0) * (ulong)x.Value.Count - 1))
            {
                PrintList(dictionary[p.Key], p.Key, fileStream);
            }
           // */

            /*
            //Unsorted variant
            foreach (var key in dictionary.Keys)
            {
                if (dictionary[key].Count != 1)
                    PrintList(dictionary[key], key, fileStream);
            }
            */
            fileStream.Close();
        }

        public void ShowUnopened(string fileName) //Writes files and directories, which were failed to open
        {
            StreamWriter fileStream = new StreamWriter(fileName);

            if(unopenedDirectories.Count != 0)
            {
                fileStream.WriteLine("Failed to open following directories:");
                foreach (string directory in unopenedDirectories)
                    fileStream.WriteLine(directory);
            }

            if (unopenedFiles.Count != 0)
            {
                fileStream.WriteLine("Failed to open following directories:");
                foreach (string fileDir in unopenedFiles)
                    fileStream.WriteLine(fileDir);
            }

            fileStream.Close();

        }

        public ulong GetDuplicatesSize(SizeFormat format) //Returns disk space, that is used by duplicates
        {
            ulong summaryMissingSpace = 0;

            foreach (var key in dictionary.Keys)
            {
                if (dictionary[key].Count != 1)
                {
                    summaryMissingSpace += (ulong)(dictionary[key].Count - 1) * (ulong)key.size;
                }
            }

            return summaryMissingSpace >> (int)format;
        }
    }
}