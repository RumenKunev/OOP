namespace _03.GenericList
{
    using System;
    using System.Text;    

    [Version(2, 11)]
    public class GenericList<T>
    {
        const int capacity = 3;

        private int index;
        private T[] arrData;


        public GenericList(int listCapacity = capacity)
        {
            arrData = new T[capacity];
        }

        public int Index
        {
            get
            {
                return this.index;
            }
            set
            {
                if (value < 0 || value > this.arrData.Length)
                {
                    throw new ArgumentOutOfRangeException("Not a valid index value!");
                }
                this.index = value;
            }
        }

        public void Add(T value)
        {
            if (this.Index >= this.arrData.Length)
            {
                Resize(arrData);
            }
            arrData[this.Index] = value;
            this.Index++;
        }

        public void Remove(int removeIndex)
        {
            if (removeIndex < 0 || removeIndex >= this.Index)
            {
                throw new ArgumentOutOfRangeException();
            }
            for (int i = removeIndex; i < this.Index; i++)
            {
                this.arrData[i] = this.arrData[i + 1];
            }
            this.Index--;
        }

        public void InsertElementAtPosition(T element, int position)
        {
            if (position < 0 || position >= this.Index)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (this.Index >= this.arrData.Length)
            {
                Resize(this.arrData);
            }
            int currentIndexPosition = this.Index;

            for (int i = this.Index; i > position; i--)
            {
                this.arrData[i] = this.arrData[i - 1];
            }

            this.arrData[position] = element;
            this.Index = currentIndexPosition + 1;
        }

        public void Clear()
        {
            Array.Clear(this.arrData, 0, this.arrData.Length);
            this.Index = 0;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.arrData.Length; i++)
            {
                if (this.arrData[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool ContainsValue(T element)
        {
            bool result = false;
            if (this.IndexOf(element) != -1)
            {
                result = true;
            }
            return result;
        }

        public T Min()
        {
            T[] sortedArr = new T[this.Index - 1];
            for (int i = 0; i < sortedArr.Length; i++)
            {
                sortedArr[i] = this.arrData[i];
            }
            Array.Sort(sortedArr);
            return sortedArr[0];
        }

        public T Max()
        {
            T[] sortedArr = new T[this.Index - 1];
            for (int i = 0; i < sortedArr.Length; i++)
            {
                sortedArr[i] = this.arrData[i];
            }
            Array.Sort(sortedArr);
            return sortedArr[sortedArr.Length - 1];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.arrData.Length)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range!");
                }
                return this.arrData[index];
            }
            set
            {
                if (index < 0 || index >= this.arrData.Length)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range!");
                }
                this.arrData[index] = value;
            }
        }

        private void Resize(T[] arrData)
        {
            int newCapacity = this.arrData.Length * 2;
            T[] resizedArr = new T[newCapacity];
            for (int i = 0; i < this.arrData.Length; i++)
            {
                resizedArr[i] = this.arrData[i];
            }
            this.arrData = resizedArr;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.Index; i++)
            {
                result.Append(this.arrData[i] + ", ");
            }
            return result.ToString().Trim(' ', ',');
        }
    }
}


