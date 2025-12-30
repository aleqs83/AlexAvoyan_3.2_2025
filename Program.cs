using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
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
            int count = 1;
            while (lst.GetValue() != num && lst.GetValue() != -num)
            {
                lst = lst.GetNext();
            }
            int numToFind = -lst.GetValue();
            while (lst != null && lst.GetValue() != numToFind)
            {
                lst = lst.GetNext();
                count++;
            }
            if (lst == null)
                return -1;
            return count;
        }
        static int Longest(Node<int> lst)
        {
            int max = -1;
            while (lst != null)
            {
                int w = Width(lst, lst.GetValue());
                if (w > max)
                {
                    max = w;
                }
                lst = lst.GetNext();
            }
            return max;
        }
        public static int CountList(Node<int> lst)//o(N) n- list size
        {
            int count = 0;
            Node<int> pos = lst;
            while (pos != null)
            {
                count++;
                pos = pos.GetNext();
            }
            return count;
        }
        static Node<int> Move(Node<int> lst, int n)//o(N) n- list size
        {
            int count = CountList(lst);
            Node<int> pos = lst;
            for (int i = 0; i < count - n - 1; i++)
            {
                pos = pos.GetNext();
            }
            Node<int> pos2 = pos;
            while (pos2.GetNext() != null)
            {
                pos2 = pos2.GetNext();
            }
            Node<int> newHead = pos.GetNext();
            pos.SetNext(null);
            pos2.SetNext(lst);
            return newHead;
        }
        static Node<int> BuildDigit(Node<int>lst)
        {
            Node<int> pos = lst;
            Node<int> pos2 = null;
            int x, num = 0;
            int p = 1;
            Node<int> listDigit = null;
            while(pos != null)
            {
                x = pos.GetValue();
                if(x != -9)
                {
                    num = num + x * p;
                    p = p * 10;
                }
                else
                {
                    if(listDigit ==null)
                    {
                        listDigit = new Node<int>(num);
                        pos2 = listDigit;
                    }
                    else
                    {
                        pos2.SetNext(new Node<int>(num));
                        pos2=pos2.GetNext();
                    }
                    num = 0; p = 1;
                }
                pos = pos.GetNext();
            }
            return listDigit;
        }

        static void Main(string[] args)
        {
            //int[] arr = { 1, 2, 3, 4, 5 };
            //Node<int> lst = FromArrToNode(arr);
            //Console.WriteLine(IsArranged(lst)); // Output: True
            //int[] arr2 = { 1, 3, 2, 4, 5 };
            //Node<int> lst2 = FromArrToNode(arr2);
            //Console.WriteLine(IsArranged(lst2)); // Output: False\
            //int[] arr3 = { -9, -1, 1, 22, 10, -2, 9, -10, 4 };
            //Node<int> lst3 = FromArrToNode(arr3);
            //Console.WriteLine($"width of 9 is:" + Width(lst3, 9)); // Output: 7
            //Console.WriteLine($"width of -1 is:" + Width(lst3, -1)); // Output: 7
            //Console.WriteLine($"width of 22 is:" + Width(lst3, 22)); // Output: 7
            //Console.WriteLine("longest: " + Longest(lst3));
            //int[] arr4 = { 5, 1, 2, 8, 4 };
            //Node<int> lst4 = FromArrToNode(arr4);
            //Console.WriteLine("the node before it was moved: " + lst4);
            //Console.WriteLine("the node after it was moved: " + Move(lst4, 2));
            int[] arr5 = {2,9,-9,4,-9,3,4,5,-9,7,6,-9};
            Node<int> lst5 = FromArrToNode(arr5);
            Console.WriteLine(BuildDigit(lst5));
            
        }
    }
}
