using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexAvoyan_3._2_2025
{
    internal class Node <T>
    {
        private T value;
        private Node<T> next;
        /* הפעולה בונה ומחזירה חוליה שהערך שלה הוא value ואין לה חוליה עוקבת **/
        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }
        /*הפעולה בונה ומחזירה חוליה, שהערך שלה הוא value
          והחוליה העוקבת לה היא החוליה next */
        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }
        /* הפעולה מחזירה את הערך של החוליה הנוכחית **/
        public T GetValue()
        {
            return this.value;
        }
        /* הפעולה מחזירה את החוליה העוקבת לחוליה הנוכחית **/
        public Node<T> GetNext()
        {
            return this.next;
        }
        /* הפעולה קובעת את ערך החוליה הנוכחית להיות  value **/
        public void Setvalue(T value)
        {
            this.value = value;
        }
        /* הפעולה קובעת את החוליה העוקבת לחוליה הנוכחית להיות החוליה next **/
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }
        /* הפעולה מחזירה מחרוזת המתארת את החוליה הנוכחית */


        public override String ToString()
        {
            string str = this.value + " -- > ";
            Node<T> p = this.next;
            while (p != null)
            {
                str += p.GetValue() + " --> ";
                p = p.GetNext();
            }


            return str;
        }
    }//Class
}
