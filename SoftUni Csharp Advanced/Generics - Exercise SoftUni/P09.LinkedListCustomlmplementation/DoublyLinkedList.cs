using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private long elementsCount;

        private ListNode<T> head;

        private ListNode<T> tail;

        private class ListNode<T>
        {
            public ListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public ListNode<T> PreviousNode { get; set; }

            public ListNode<T> NextNode { get; set; }
        }

        private ListNode<T> Head 
        {
            get { return head; }
            set { head = value; }
        }

        private ListNode<T> Tail 
        {
            get { return tail; }
            set { tail = value; }
        }

        private long ElementsCount 
        { 
            get { return elementsCount; }
            set { elementsCount = value; }
        }

        private void ThrowExceptionIfListIsEmpty()
        {
            if (this.ElementsCount == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
        }

        private bool ListIsEmpty => this.ElementsCount == 0;

        public long Count() => this.ElementsCount;

        public IEnumerator<T> GetEnumerator()
        {
            T[] array = this.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        public void AddFirst(T elementToAdd)
        {
            if (ListIsEmpty)

                this.Head = this.Tail = new ListNode<T>(elementToAdd);

            else
            {
                var newHead = new ListNode<T>(elementToAdd);

                newHead.NextNode = this.Head;

                this.Head = newHead;

            }
            this.ElementsCount++;
        }

        public void AddLast(T elementToAdd)
        {
            if (ListIsEmpty)

                this.Head = this.Tail = new ListNode<T>(elementToAdd);

            else
            {
                var newTail = new ListNode<T>(elementToAdd);

                newTail.PreviousNode = this.Tail;

                this.Tail.NextNode = newTail;

                this.Tail = newTail;
                
            }
            this.ElementsCount++;
        }

        public T RemoveFirst()
        {
            ThrowExceptionIfListIsEmpty();

            T firstElement = this.Head.Value;
            this.Head = this.Head.NextNode;

            if (this.Head != null)

                this.Head.PreviousNode = null;

            else
                this.Tail = null;

            this.ElementsCount--;
            return firstElement;
        }

        public T RemoveLast()
        {
            ThrowExceptionIfListIsEmpty();

            T lastElement = this.Tail.Value;
            this.Tail = this.Tail.PreviousNode;

            if (this.Tail != null)

                this.Tail.NextNode = null;

            else

                this.Head = null;

            this.ElementsCount--;
            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.Head;

            while (currentNode != null)
            {
                action(currentNode.Value);

                currentNode = currentNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] informationArray = new T[this.ElementsCount];

            var counter = 0;

            this.ForEach(item =>
            {
                informationArray[counter] = item;
                counter++;
            });

            return informationArray;
        }

        public List<T> ToList()
        {
            var list = new List<T>();

            this.ForEach(item => list.Add(item));

            return list;
        }

        public void Clear() 
        {
            this.ElementsCount = 0;
            this.Head = this.Tail = null;
        }

        public bool Contains(T item)
        {
            var currentNode = this.Head;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    return true;
                }
                currentNode = currentNode.NextNode;
            }

            return false;
        }

    }
}
