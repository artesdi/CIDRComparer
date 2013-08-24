using System;

namespace CIDRComparer
{
    internal class Program
    {
        private static string _input1;
        private static string _input2;

        private static void Main(string[] args)
        {
            var comparator = new CIDRComparator();

            while (true)
            {
                ReadInput();

                var report = comparator.CompareCidr(_input1, _input2);

                WriteOutput(report);
            }
        }

        private static void ReadInput()
        {
            Console.WriteLine("Enter 2 CIDR ranges (format: 192.168.0.1/22)");
            Console.Write("First range: ");
            _input1 = Console.ReadLine();
            Console.Write("Second range: ");
            _input2 = Console.ReadLine();
        }

        private static void WriteOutput(CIDRComparatorResult report)
        {
            Console.WriteLine("\n\"{0}\" {2} \"{1}\"\n", _input1, _input2, report);
        }
        
        private static int _testIncr = 0;
        private static void TestCase()
        {
            switch (_testIncr)
            {
                case 0:
                    _input1 = "23.45.67.89/16";
                    _input2 = "23.45.255.255/16";
                    break;
                case 1:
                    _input1 = "1.2.3.4/24";
                    _input2 = "1.2.3.4/16";
                    break;
                case 2:
                    _input1 = "172.84.26.128/16";
                    _input2 = "172.84.26.255/24";
                    break;
                case 3:
                    _input1 = "197.54.16.128/25";
                    _input2 = "197.54.16.127/25";
                    break;
                case 4:
                    _input1 = "0.0.0.0/0";
                    _input2 = "1.1.1.1/1";
                    break;
                case 5:
                    _input1 = "255.255.255.255/25";
                    _input2 = "255.255.255.255/32";
                    break;
                default:
                    break;
            }
            _testIncr++;
            Console.ReadKey();
        }
    }
}