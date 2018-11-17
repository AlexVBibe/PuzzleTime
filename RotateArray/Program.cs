using System;
using System.Linq;

namespace RotateArray
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("----Input, sequence 1 2 3 4 5 6: ");
                var input = Console.ReadLine();
                var array = input.
                    Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).
                    Select(number => Int32.Parse(number)).
                    ToArray();

                Console.Write("----Number of rotations: ");
                input = Console.ReadLine();
                var numberOfRotations = Int32.Parse(input);

                //RightRotate(array, numberOfRotations);
                Solution(array, numberOfRotations);
                Console.WriteLine($"Array: ({string.Join(", ", array)})");

                LeftRotate(array, numberOfRotations);
                Console.WriteLine(string.Format("Array: ({0})", string.Join(", ", array)));

                Console.WriteLine("Again, y/n?");
            } while (Console.ReadLine() == "y");
        }

        public static int[] Solution(int[] A, int K)
        {
            var shift = K % A.Length;
            var counter = 0;
            var index = 0;
            var start = 0;
            var currentValue = A[index];
            while (counter < A.Length)
            {
                var dstIndex = (index + shift) % A.Length;
                var savedValue = A[dstIndex];
                A[dstIndex] = currentValue;
                currentValue = savedValue;

                if (start == dstIndex)
                {
                    dstIndex++;
                    if (dstIndex >= A.Length)
                        break;
                    currentValue = A[dstIndex];
                    start = dstIndex;
                }
                index = dstIndex;

                counter++;
            }

            return A;
        }

        public static void RightRotate(int[] array, int rotations)
        {
            rotations = rotations % array.Length; // adjust number of rotations to array size

            int startPos = 0;
            int pos = startPos;
            var value = array[pos];
            pos = pos + rotations; //(pos + rotations) % (array.Length);
            int numberOfValuesMoved = 0;
            while (numberOfValuesMoved < array.Length)
            {
                var savedValue = array[pos];
                array[pos] = value;
                if (pos != startPos)
                    value = savedValue;
                else
                {
                    startPos++;
                    if (startPos >= array.Length)
                        break;
                    pos = startPos;
                    value = array[pos];
                }
                pos += rotations;
                if (pos >= array.Length)
                    pos %= array.Length;
                numberOfValuesMoved++;
            }
        }

        /*Function to left rotate arr[] by d*/
        static void LeftRotate(int[] arr, int d)
        {
            d = d % arr.Length;
            int n = arr.Length;
            int i, j, k, temp;
            for (i = 0; i < gcd(d, n); i++)
            {
                /* move i-th values of blocks */
                temp = arr[i];
                j = i;
                while (true)
                {
                    k = j + d;
                    if (k >= n)
                        k = k - n;
                    if (k == i)
                        break;
                    arr[j] = arr[k];
                    j = k;
                }
                arr[j] = temp;
            }
        }

        /*Fuction to get gcd of a and b*/
        static int gcd(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return gcd(b, a % b);
        }

    }
}
