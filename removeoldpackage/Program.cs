using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace removeoldpackage
{
    class Program
    {
        /// <summary>
        /// Remove old Visual Studio 2017 component from offline images
        /// </summary>
        /// <param name="args">VS2017 offline image source</param>
        /// <returns></returns>
        static int Main(string[] args)
        {
            if(args.Length != 1)
            {
                Console.WriteLine("1st parameter must require VS2017 offline folder");
                return 1;
            }

            var target = new List<Tuple<string, string, string>>();
            var folders = Directory.GetDirectories(args[0]);
            foreach(var folder in folders)
            {
                var delimiters = folder.Split(",");
                Tuple<string, string, string> folderDelimiter;
                if(delimiters.Length >= 2)
                {
                    folderDelimiter = new Tuple<string, string, string>
                        (folder, delimiters[0], delimiters[1]);
                    target.Add(folderDelimiter);
                }
            }

            var groups = from p in target
                         group p by new
                         {
                             ItemName = p.Item2,
                         };
            foreach (var itemName in groups)
            {
                if(itemName.Count() > 1)
                {
                    var newest = itemName.Max(x => x.Item3);
                    var removeFolders = itemName.Where(x => string.CompareOrdinal(x.Item3, newest) != 0).Select(x => x.Item1);

                    foreach (var item in removeFolders)
                    {
                        Directory.Delete(item, true);
                        Console.WriteLine($"remove {item} Folder");
                    }
                }
            }
            return 0;
        }

    }
}
