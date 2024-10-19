namespace assignment_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cache<char,int> cha = new Cache<char,int>();
            cha.add('a', 10);
            cha.add('b', 10); 
            cha.add('c', 10);
            cha.add('d', 10);
            foreach(string item in cha)
            {
                Console.WriteLine(item);
            }
           /* int[] numbers = { 1, 2, 3, 4, 5, 6, 432, 4 };
            Console.WriteLine(FindMax(numbers));
            for(int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }*/
        }
        static void ReverseArray<T>(T[] array)
        {
            T temp;
            int len=array.Length;
           for (int i = 0; i < len/2; i++)
            {
                temp = array[i];
                array[i] = array[len - 1 - i];
                array[len - 1 - i] = temp;
            }
        }
        static T FindMax<T>(T[] array) where T : IComparable<T>
        {
            T max = array[0];
            int result;
            for(int i = 1; i < array.Length; i++)
            {
                result = max.CompareTo(array[i]);
                if (result < 0)
                {
                    max= array[i];
                }
            }
            return max;
        }
    }
}
