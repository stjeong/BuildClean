using System;
using System.IO;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char separator = Path.DirectorySeparatorChar;

            foreach (string dirPath in Directory.EnumerateDirectories(Directory.GetCurrentDirectory(), "*.*", SearchOption.AllDirectories))
            {
                if (dirPath.EndsWith(separator + "bin", StringComparison.CurrentCultureIgnoreCase) == true
                    || dirPath.EndsWith(separator + "obj", StringComparison.CurrentCultureIgnoreCase) == true)
                {
                    try
                    {
                        foreach (string filePath in Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories))
                        {
                            try
                            {
                                File.Delete(filePath);
                            }
                            catch { }
                        }

                        Directory.Delete(dirPath, true);
                    }
                    catch { }
                }
            }
        }
    }
}
