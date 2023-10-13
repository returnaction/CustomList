using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T> : IEnumerable where T : IComparable<T>
    {
        // Documentation about -Operator in PDF File:  CustomList_T_  - Operator Overloading.pdf

        //Member Variables (HAS A)
        private T[] items;
        private int capacity;
        private int count;

        public int Count { get => count; }
        public int Capacity { get => capacity; }
        // copied from Amy'screen but it wasn't in the task;
        public T[] Items { get { return items; } set { items = value; } }

        //Constructor
        public CustomList()
        {
            count = 0;
            capacity = 4;
            items = new T[capacity];
        }

        //Member Methods (CAN DO)
        // Indexer
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < count)
                    return items[index];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < count)
                    items[index] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }
        // helper method. Calls when Array is full
        // SRP 
        void HelperIncreaseArray()
        {
            capacity *= 2;

            T[] tempArray = new T[capacity];

            for (int i = 0; i < count; i++)
            {
                tempArray[i] = items[i];
            }

            items = tempArray;
        }

        // Add item to the list. if List is full calls HelperIncreaseArray()
        public void Add(T item)
        {
            if (count == capacity)
            {
                HelperIncreaseArray();
            }

            items[count] = item;
            count++;
        }

        // If Method returns -1 . Doesn't contain
        // If method returns a number. It's the index in the array where item is
        // SRP
        int IndexOf(T item)
        {
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        // Removes items from the list
        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
            {
                return false;
            }
            else
            {
                for (int i = index; i < count - 1; i++)
                {
                    items[i] = items[i + 1];
                }

                count--;
                items[count] = default(T);
                return true;
            }
        }


        public override string ToString()
        {
            string listToString = "";

            for (int i = 0; i < count; i++)
            {
                listToString += $"{items[i]}";
            }
            return listToString;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        public static CustomList<T> operator +(CustomList<T> firstList, CustomList<T> secondList)
        {
            for (int i = 0; i < secondList.count; i++)
            {
                firstList.Add(secondList[i]);
            }

            return firstList;
        }

        public static CustomList<T> operator -(CustomList<T> firstList, CustomList<T> secondList)
        {
            for (int i = 0; i < secondList.count; i++)
            {
                firstList.Remove(secondList[i]);
            }

            //returns a single CustomList<T> with all items from firstList, EXCEPT any items that also appear in secondList
            return firstList;
        }

        // Zips one item from the first List and one from the second list
        // If item one list is longer. it zips first and then add leftovers
        public void Zip(CustomList<T> zipper)
        {
            T[] tempArray = new T[count + zipper.count];

            int indexTempArray = 0;
            int indexItems = 0;
            int indexZipper = 0;

            for (int i = 0; i < count + zipper.count; i++)
            {
                if (indexItems < count)
                {
                    tempArray[indexTempArray] = items[indexItems];
                    indexTempArray++;
                    indexItems++;
                }

                if (indexZipper < zipper.count)
                {
                    tempArray[indexTempArray] = zipper[indexZipper];
                    indexTempArray++;
                    indexZipper++;
                }
            }

            count += zipper.count;
            items = tempArray;
        }

        public CustomList<T> Zip2(CustomList<T> listTwo)
        {
            CustomList<T> zippedList = new();
            int totalLength = Math.Max(count, listTwo.Count);

            for (int i = 0; i < totalLength; i++)
            {   // I didn't get why we need I < count in here?
                if (i < count)
                {
                    zippedList.Add(Items[i]);
                }
                // I didn't get why we need I < count in here?
                if (i < listTwo.Count)
                {
                    zippedList.Add(listTwo[i]);
                }
            }

            return zippedList;
        }


        // I am using BubbleSort algorithm . What it does it checks firts item with the one on the right
        // And if the item on the left is > item on the right. Then we swap them.
        // 5, 3, 4, 7
        // 5 > 3 So we need to swap them. We create a temp variable  and we put 5 in there... temp = [5];
        // then to [0] index we assign 3 .. [0] = [1];
        // then to [1] index we assign what is in the temp.. [1] = temp;
        // result: 3, 5, 4, 7
        // then we do the same logic for 5 and 4 and etc...


        // I was trying to make that Mehtos better by finding more results about IComparer... but I decided to give up... 
        // Custom<int> unsorted = new Custom<int>{3,5,3,2,6,2,};
        // Custom<int> sorted = unsorted.Sort(unsorted); I think this is so bad. but it works
        // I don't like the way we need to call theat method from a variable and then  pass in argument the same variable we need to store
        // and then all of that save it to new CustomLis<T>... 

        public CustomList<T> Sort<T>(CustomList<T> list) where T : IComparable<T>
        {
            T temp;

            for (int i = 0; i < list.count - 1; i++)
            {
                for (int j = i + 1; j < list.count; j++)
                {
                    int result = list[i].CompareTo(list[j]);

                    if (result == 1)
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }

            return list;
        }

        // THIS IS THE SORT!!!!!
        public void Sort2()
        { 
            T temp;

            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    int result = items[i].CompareTo(items[j]);

                    if (result == 1)
                    {
                        temp = items[i];

                        items[i] = items[j];
                        items[j] = temp;
                    }
                }
            }
        }
    }
}

