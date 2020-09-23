using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Radix_Sort
{
    class Sort
    {
        private int[] data;
        private IList<IList<int>> digits = new List<IList<int>>();
        private int maxLength = 0;
        public Sort()
        {
            for (int i = 0; i < 10; i++)
            {
                digits.Add(new List<int>());
            }
            Console.Write("Enter the Number of Elements : ");
            int count = int.Parse(Console.ReadLine());
            data = new int[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write("[{0}]: ", i + 1);

                data[i] = int.Parse(Console.ReadLine());

                if (maxLength < data[i].ToString().Length)
                    maxLength = data[i].ToString().Length;
            }
        }

        public void RadixSort()
        {
            for (int i = 0; i < maxLength; i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    int digit = (int)((data[j] % Math.Pow(10, i + 1)) / Math.Pow(10, i));

                    digits[digit].Add(data[j]);
                }

                int index = 0;
                for (int k = 0; k < digits.Count; k++)
                {
                    IList<int> selDigit = digits[k];

                    for (int l = 0; l < selDigit.Count; l++)
                    {
                        data[index++] = selDigit[l];
                        
                    }

                    Console.Write("Bin " + k + ": ");
                    foreach (int x in selDigit)
                    {
                        Console.Write("{0} ", x);
                    }
                    Console.Write("\n");

                }
                Console.ReadKey();
                Console.Write("\nPass " + (i+1) + ": ");
                foreach (int x in data)
                {
                    Console.Write("{0} ", x);
                }
                Console.Write("\n\n");
                ClearDigits();
                Console.ReadKey();
            }
            GetSortedData();
        }

        private void ClearDigits()
        {
            for (int k = 0; k < digits.Count; k++)
            {
                digits[k].Clear();
            }
        }

        public void GetSortedData()
        {
            Console.Write("The Sorted Numbers are : ");
            foreach (int x in data)
            {
                Console.Write("{0} ", x);
            }
        }
    }
}
