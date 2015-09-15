using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            var arr = new IComparable[20];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(100);
            }
            ShowArr(arr);

            MergeSort(arr);
            ShowArr(arr);

            Console.ReadKey();
        }

        static void ShowArr(IComparable[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write("{0}  ", item);
            }
            Console.WriteLine();
        }

        static void Merge(IComparable[] arr, int leftBegin, int leftEnd, int rightBegin, int rightEnd)
        {
            int leftLenght = leftEnd - leftBegin + 1;
            int rightLenght = rightEnd - rightBegin + 1;
            IComparable[] mergedArr = new IComparable[leftLenght + rightLenght];
                
            int k = 0, l = leftBegin, r = rightBegin;
            while(k < leftLenght + rightLenght)
            {
                if(l < leftEnd +1 && r < rightEnd + 1)
                {
                    if(arr[l].CompareTo(arr[r]) <= 0)
                    {
                        mergedArr[k++] = arr[l++];
                    }
                    else
                    {
                        mergedArr[k++] = arr[r++];
                    }
                }
                else
                {
                    if(l > leftEnd)
                    {
                        while(r <= rightEnd)
                        {
                            mergedArr[k++] = arr[r++];
                        }
                    }
                    else if(r >= rightEnd)
                    {
                        while(l <= leftEnd)
                        {
                            mergedArr[k++] = arr[l++];
                        }
                    }
                }
            }

            Array.Copy(mergedArr, 0, arr, leftBegin, leftLenght + rightLenght);
        }

        static void MergeSort(IComparable[] array)
        {
            if (array.Length < 2)
            {
                return;
            }

            int step = 1;
            int leftBegin, rightBegin;

            while (step < array.Length)
            {
                leftBegin = 0;
                rightBegin = step;
                while (rightBegin + step <= array.Length)
                {
                    Merge(array, leftBegin, leftBegin + step - 1, rightBegin, rightBegin + step - 1);

                    leftBegin = rightBegin + step;
                    rightBegin = leftBegin + step;
                }

                if (rightBegin < array.Length)
                {
                    Merge(array, leftBegin, leftBegin + step - 1, rightBegin, array.Length - 1);
                }

                step *= 2;
            }
        }
    }
}
