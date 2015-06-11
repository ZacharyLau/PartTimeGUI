using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/** This ADT list is for both person and course
 *  It automatically increase the size 
 * 
 **/

namespace PartTimeUnionApp
{
    public class ADTArray<T>
    {
        private static int capacity = 5;
        private T[] array = new T[capacity];
        private int numOfItem = 0;
        



        private void CapacityChecker()
        {
            if (numOfItem == capacity * 0.7 || numOfItem > capacity * 0.7)
            {
                capacity =(int)(capacity * 0.5) + capacity;
                T[] temp = new T[capacity];
				for (int i = 0; i < numOfItem; i++)
				{
					temp[i] = array[i];
				}
				array = temp;
			}
        }

        public void Insert(T item){
			////Console.WriteLine("numOfItem: " + numOfItem);
			//Console.WriteLine("Capacity: " + array.Length);
            array[numOfItem] = item;
            numOfItem++;
            CapacityChecker();
            //add to database later
    }

        public void Delete(int index)
        {
            if (index < 0 || index >= numOfItem)
            {
                throw new Exception("Index out of bound.");
            }

            for (int i = index; i < numOfItem - 2; i++)
            {
                array[i] = array[i + 1];

            }

            numOfItem--;
        }


        public T GetItem(int index)
        {
            if (index < 0 || index >= numOfItem)
            {
                throw new Exception("Index out of bound.");
            }

            return array[index];
        }


        public T[] GetAll()
        {
            return array;
        }


        public int GetNumOfItem()
        {
            return numOfItem;
        }



    }
}
