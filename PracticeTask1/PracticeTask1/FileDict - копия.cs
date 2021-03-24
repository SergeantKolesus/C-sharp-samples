using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PracticeTask1
{
    struct fCode : IComparable
    {
        public ulong size;
        public string ext;

        #region operators defining

        public static bool operator < (fCode a, fCode b)
        {
            if (a.size < b.size)
            {
                return true;
            }
            else
            {
                if ((a.size == b.size) && (String.Compare(a.ext, b.ext) < 0))
                    return true;

                return false;
            }
        }

        public static bool operator > (fCode a, fCode b)
        {
            if (a < b)
                return false;
            return true;
            /*if (a.size > b.size)
            {
                return true;
            }
            else
            {
                if ((a.size == b.size) && (String.Compare(a.ext, b.ext) > 0))
                    return true;

                return false;
            }*/
        }

        public static bool operator == (fCode a, fCode b)
        {
            return (a.size == b.size) && (a.ext == b.ext);
        }

        public static bool operator != (fCode a, fCode b)
        {
            return (a.size != b.size) || (a.ext != b.ext);
        }

        #endregion

        #region standart functions override

        public override bool Equals(object b)
        {
            if (!(b is fCode))
                return false;

            return (fCode)b == this;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string s;

            s = size.ToString() + " " + ext;

            return s;
        }

        #endregion

        #region IComparable

        public int CompareTo(object obj)
        {
            if (!(obj is fCode))
                return 0;

            fCode fc = (fCode)obj;

            if (this < fc)
                return -1;

            if (this == fc)
                return 0;

            return 1;
        }

        #endregion
    };

    class FileDict
    {
        public enum sizeFormat
        {
            bytes = 0,
            kilobyes = 10,
            megabytes = 20,
            gigabytes = 30,
            terabytes = 40
        };

        public SortedDictionary<fCode, List<string>> dictionary;
        public List<string> unopenedDirectories;
        public List<string> unopenedFiles;

        public FileDict()
        {
            dictionary = new SortedDictionary<fCode, List<string>>();
            unopenedDirectories = new List<string>();
            unopenedFiles = new List<string>();
        }

        private void p_PrintList(List<string> list, fCode key)
        {
            Console.WriteLine("\nFile group with size " + key.size + " and extension " + key.ext + "\n");
            foreach (string s in dictionary[key])
                Console.WriteLine(s);
            Console.WriteLine("\nGroup end\n================\n");
        }

        private void p_PrintList(List<string> list, fCode key, StreamWriter file)
        {
            file.WriteLine();
            file.WriteLine("File group with size " + key.size + " and extension " + key.ext);
            file.WriteLine();
            foreach (string s in dictionary[key])
                file.WriteLine(s);
            file.WriteLine();
            file.WriteLine("Group end");
            file.WriteLine("================");
            file.WriteLine();
        }

        public void AddToList(string RootDirectory)
        {
            DirectoryInfo curDI = new DirectoryInfo(RootDirectory);

            {                
                FileInfo[] fiArr = curDI.GetFiles();
                fCode key;

                foreach (FileInfo fi in fiArr)
                {
                    try
                    {
                        key.size = (ulong)fi.Length;
                        key.ext = fi.Extension;

                        if (!dictionary.ContainsKey(key))
                            dictionary[key] = new List<string>();

                        dictionary[key].Add(fi.FullName);
                    }
                    catch
                    {
                        Console.WriteLine("Failed to open file " + fi.FullName);
                        unopenedFiles.Add(fi.FullName);
                        continue;
                    }
                }
            }

            
            DirectoryInfo[] diArr = curDI.GetDirectories();

            foreach (DirectoryInfo di in diArr)
            {
                try
                {
                    AddToList(di.FullName);
                    //Console.WriteLine("Dir " + di.FullName + " completed");
                }
                catch
                {
                    Console.WriteLine("Failed to open directory " + di.FullName);
                    unopenedDirectories.Add(di.FullName);
                    continue;
                }
            }
            
            
        }

        /*
        public void ShowDictionary()
        {

                foreach (var key in dictionary.Keys)
                {
                    if (dictionary[key].Count != 1)
                        p_PrintList(dictionary[key], key);
                }
                
        }
        //*/

        /*
         public void ShowDictionary(string fileName, out ulong summaryMissingSpace)
        {
            StreamWriter file = new StreamWriter(fileName);

            summaryMissingSpace = 0;

            foreach (var key in dictionary.Keys)
            {
                if (dictionary[key].Count != 1)
                {
                    p_PrintList(dictionary[key], key, file);
                    summaryMissingSpace += (ulong)dictionary[key].Count * (ulong)key.size;
                }
            }
        }
        //*/

        public void ShowDictionary(string fileName)
        {
            StreamWriter file = new StreamWriter(fileName);

            foreach (var key in dictionary.Keys)
            {
                if (dictionary[key].Count != 1)
                    p_PrintList(dictionary[key], key, file);
            }

            file.Close();
        }
        
        /*
        public void ShowDictionary(StreamWriter file, ulong maxFullCheckSize)
        {
            //StreamWriter file = new StreamWriter(fileName);

            foreach (var key in dictionary.Keys)
            {
                if(key.size <= maxFullCheckSize)
                {
                    List<List<string>> files = new List<List<string>>();
                    List<string> curBranch;

                    foreach (string s in dictionary[key])
                    {
                        if(files.Count == 0)
                        {
                            curBranch = new List<string>();
                            curBranch.Add(s);
                            files.Add(curBranch);
                        }
                        else
                        {
                            
                        }
                    }
                }

                if (dictionary[key].Count != 1)
                {
                    file.WriteLine("================\nFile group with size " + key.size + " and extension " + key.ext + "\n================");
                    foreach (string s in dictionary[key])
                        file.WriteLine(s);
                    file.WriteLine("================\nGroup end\n================");
                }
            }
        }
        //*/
        
        public ulong GetDuplicatesSize(sizeFormat format)
        {
            ulong summaryMissingSpace = 0;

            foreach(var key in dictionary.Keys)
            {
                if (dictionary[key].Count != 1)
                {
                    summaryMissingSpace += (ulong)dictionary[key].Count * (ulong)key.size;
                }
            }

            return summaryMissingSpace >> (int)format;
        }

        public void ShowUnopened(string fileName)
        {
            StreamWriter file = new StreamWriter(fileName);

            if(unopenedDirectories.Count != 0)
            {
                file.WriteLine("Failed to open following directories:");
                foreach (string directory in unopenedDirectories)
                    file.WriteLine(directory);
            }

            if (unopenedFiles.Count != 0)
            {
                file.WriteLine("Failed to open following directories:");
                foreach (string fileDir in unopenedFiles)
                    file.WriteLine(fileDir);
            }

            file.Close();

        }

        public void ShowListFullCheck(string fileName, ulong maxFullCheckSize)
        {
            StreamWriter file = new StreamWriter(fileName);

            foreach(var key in dictionary.Keys)
            {
                if(key.size <= maxFullCheckSize)
                {
                    List<List<string>> files = new List<List<string>>();

                    FileStream curFileStr;
                    FileStream curCompStr;
                    BinaryReader curFileBin;
                    BinaryReader curCompBin;

                    foreach(string curFile in dictionary[key])
                    {
                        if(files.Count == 0)
                        {
                            files.Add(new List<string>());
                            files.ElementAt(0).Add(curFile);

                            continue;
                        }

                        curFileStr = new FileStream(curFile, FileMode.Open);
                        curFileBin = new BinaryReader(curFileStr);

                        foreach(List<string> fileGroup in files)
                        {
                            curCompStr = new FileStream(curFile, FileMode.Open);
                            curCompBin = new BinaryReader(curFileStr);
                        }
                    }
                }
            }
        }

        /*
        public void ShowDictionary(int byteCheckingSizeCap)
        {
            foreach (var key in dictionary.Keys)
            {
                if (dictionary[key].Count != 1)
                {
                    if (key.size <= byteCheckingSizeCap)
                    {
                        SortedDictionary<ulong, List<string>> duplicates = new SortedDictionary<ulong, List<string>>();
                        StreamReader file;
                        int i;
                        ulong data;

                        foreach (string s in dictionary[key])
                        {
                            file = new StreamReader(s);

                            
                        }
                    }
                    else
                    {
                        Console.WriteLine(key);
                        Console.WriteLine("==================");
                        foreach (string s in dictionary[key])
                            Console.WriteLine(s);
                        Console.WriteLine("------------------");
                    }
                }
            }
        }
        //*/

    }
}