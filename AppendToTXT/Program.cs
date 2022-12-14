using System;
using System.IO;

class Test
{
    public static void Main()
    {
        string[] files = Directory.GetFiles(@"\\XXX.XXX.XXX.XXX\mega\secret", "*", SearchOption.TopDirectoryOnly);
        if (files.Length != 0)
        {
            foreach (string name in files)
            {
                FileInfo fi = new FileInfo(name);
                if (fi.CreationTime > DateTime.Now.AddMonths(-3))
                    Console.WriteLine(fi.Name);
                string firstLine = "S1:000000000 000000000000000";
                string secondLine = "S3:000000000 000";
                string input = name;
                Console.WriteLine(input);
                var lines = File.ReadLines(input).ToArray(); // read file only once, and save result to variable
                if (lines == null || lines.Any()) // continue iteration with next item, if no lines are present
                {
                    continue;
                }

                var lastLine = lines.Last(); // gets the last line. .Last() fails if lines variable is null or has not items, but since we checked earlier, this is fine
                var secondLast = lines.Length >= 2 ? lines[lines.Length - 2] : string.Empty; // if lines.Length was less than two, then lines[lines.Length -2] would fail
                if (secondLast.Equals(firstLine, StringComparison.OrdinalIgnoreCase) && lastLine.Equals(secondLine, StringComparison.OrdinalIgnoreCase)) // no need for .Contains() here, if we're checking for equality. .Contains() is significantly slower than .Equals(). Equals also allows for case insensitive comparison
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Soubor již obsahuje přidané řádky");
                    Console.WriteLine("Stiskněte enter");
                    Console.ReadLine();
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(input))
                    {
                        sw.WriteLine(firstLine);
                        sw.WriteLine(secondLine);
                    }

                    using (StreamReader sr = File.OpenText(input))
                    {
                        Console.WriteLine(" ");
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine(" ");
                        Console.WriteLine("Soubor byl zpracován");
                        Console.WriteLine("Stiskněte enter");
                        Console.ReadLine();
                    }
                }
            }
        }
        else
        {
            Console.WriteLine(" ");
            Console.WriteLine("Žádný soubor ke zpracování");
            Console.WriteLine("Stiskněte enter");
            Console.ReadLine();
        }
    }
}

//class Test
//{
//    public static void Main()
//    {
//        string[] files1 = Directory.GetFiles(@"\\192.168.171.31\ebs\out", "*", SearchOption.TopDirectoryOnly);
//        foreach (string name in files1)
//        {
//            FileInfo fi = new FileInfo(name);
//            if (fi.CreationTime > DateTime.Now.AddMonths(-3))
//                Console.WriteLine(fi.Name);
//        }
//        if (files1.Length > 0)
//        {
//            Console.WriteLine(" ");
//            Console.WriteLine("Vyplňte název souboru:");
//            string firstLine = "S1:000000000 000000000000000";
//            string secondLine = "S3:000000000 000";

//            string path1 = "\\\\192.168.171.31\\ebs\\out\\";
//            string fileName1 = Console.ReadLine();
//            string input = path1 + fileName1;
//            Console.WriteLine(input);
//            var lastLine = File.ReadLines(input).Last();
//            var secondLast = File.ReadLines(input);
//            if (secondLast.Contains("S1:000000000 000000000000000") && lastLine.Contains("S3:000000000 000"))
//            {
//                Console.WriteLine(" ");
//                Console.WriteLine("Soubor již obsahuje přidané řádky");
//                Console.WriteLine("Stiskněte enter");
//                Console.ReadLine();
//            }
//            else
//            {
//                using (StreamWriter sw = File.AppendText(input))
//                {
//                    sw.WriteLine(firstLine);
//                    sw.WriteLine(secondLine);
//                }

//                using (StreamReader sr = File.OpenText(input))
//                {
//                    Console.WriteLine(" ");
//                    string s = "";
//                    while ((s = sr.ReadLine()) != null)
//                    {
//                        Console.WriteLine(s);
//                    }
//                }
//                if (File.GetCreationTime(input) < DateTime.Now.AddMinutes(-1))
//                {
//                    Console.WriteLine(" ");
//                    Console.WriteLine("Soubor byl zpracován");
//                    Console.WriteLine("Stiskněte enter");
//                }
//                Console.ReadLine();
//            }
//            if (files1.Length == 0)
//            {
//                Console.WriteLine(" ");
//                Console.WriteLine("Žádný soubor ke zpracování");
//                Console.WriteLine("Stiskněte enter");
//                Console.ReadLine();
//            }
//        }
//    }
