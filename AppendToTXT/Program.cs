using System;
using System.IO;

class Test
{
    public static void Main()
    {
        string[] files = Directory.GetFiles(@"\\192.168.171.31\ebs\out", "*", SearchOption.TopDirectoryOnly);
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
                var lastLine = File.ReadLines(input).Last();
                var secondLast = File.ReadLines(input);
                if (secondLast.Contains(firstLine) && lastLine.Contains(secondLine))
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
