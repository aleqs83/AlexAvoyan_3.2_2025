using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlexAvoyan_3._2_2025
{
    internal class Program
    {
        public static Node<int> FromArrToNode(int[] arr)
        {
            if (arr.Length == 0)
                return null;
            Node<int> head = new Node<int>(arr[0]);
            Node<int> current = head;
            for (int i = 1; i < arr.Length; i++)
            {
                current.SetNext(new Node<int>(arr[i]));
                current = current.GetNext();
            }
            return head;
        }
        static bool IsArranged(Node<int> lst)
        {
            if (lst == null || lst.GetNext() == null)
            {
                return true;
            }
            Node<int> current = lst;
            while (current.GetNext() != null)
            {
                if (current.GetValue() > current.GetNext().GetValue())
                {
                    return false;
                }
                current = current.GetNext();
            }
            return true;
        }
        static int Width(Node<int> lst, int num)
        {
            Node<int> p = lst;

            // חיפוש המספר num
            while (p != null && p.GetValue() != num)
                p = p.GetNext();

            if (p == null)
                return -1; // num לא קיים בשרשרת

            int count = 1;
            bool positive = p.GetValue() > 0;
            p = p.GetNext();

            // ספירת תת-הסדרה הנגדית
            while (p != null)
            {
                if ((positive && p.GetValue() < 0) || (!positive && p.GetValue() > 0))
                {
                    count++;
                    p = p.GetNext();
                }
                else
                    break;
            }

            return count;
        }
        public static int Longest(Node<int> lst)
        {
            int max = 0;
            Node<int> p = lst;

            while (p != null)
            {
                int w = Width(lst, p.GetValue());
                if (w > max)
                    max = w;

                p = p.GetNext();
            }

            return max == 0 ? -1 : max;
        }
        static void Main(string[] args)
        {
            //int[] arr = { 1, 2, 3, 4, 5 };
            //Node<int> lst = FromArrToNode(arr);
            //Console.WriteLine(IsArranged(lst)); // Output: True
            //int[] arr2 = { 1, 3, 2, 4, 5 };
            //Node<int> lst2 = FromArrToNode(arr2);
            //Console.WriteLine(IsArranged(lst2)); // Output: False
            int[] arr3 = { -9, -1, 1, -22 , -10, -2, 9, -10 ,4};
            Node<int> lst3 = FromArrToNode(arr3);
            Console.WriteLine(Width(lst3, -1)); // Output: 7
            int[]arr4 = {-9 ,1, 1, 22, 10, 2, 9};
            Node<int> lst4 = FromArrToNode(arr4);
            Console.WriteLine(Longest(lst4)); // Output: 45
        }
    }
}
