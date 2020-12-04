using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaberInteractiveTest
{
    class ListNode
    {
        public ListNode previous;
        public ListNode next;
        public ListNode random; // Не понимаю зачем нужно данное поле :D

        public string data;

        public ListNode(string data)
        {
            this.data = data;
        }

        public override string ToString()
        {
            return $" Предыдущий элемент: {(previous == null ? "null" : previous.data)}\n" +
                   $" Этот элемент: {data}\n" +
                   $" Cледующий элемент: {(next == null ? "null" : next.data)}\n\n";
        }
    }
}
