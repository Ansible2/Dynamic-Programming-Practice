using System;

namespace Fib__Tab_
{
    class Program
    {
        static long fibTabulation(long fibIndex)
        {
            if (fibIndex == 0)
            {
                return 0;
            }

            if (fibIndex == 1)
            {
                return 1;
            }

            
            long[] fibArray = new long[fibIndex + 1];
            fibArray[0] = 0;
            fibArray[1] = 1;

            for(long i = 2; i <= fibIndex; i++)
            {
                long fibSequenceNumber = fibArray[i - 1];
                fibSequenceNumber += fibArray[i - 2];
                fibArray[i] = fibSequenceNumber;
            }

            return fibArray[fibIndex];
        }

        // a version similar to the teacher's
        static long fibTabulation_teachers(long fibIndex)
        {
            long[] fibArray = new long[fibIndex + 1];
            Array.Fill(fibArray, 0);
            fibArray[1] = 1;

            for (long i = 0; i <= fibIndex; i++)
            {
                fibArray[i + 1] += fibArray[i];
                fibArray[i + 2] += fibArray[i]; // out of bounds
            }

            return fibArray[fibIndex];
        }



        static void Main(string[] args)
        {
            Console.WriteLine(fibTabulation(50));
            //Console.WriteLine(fibTabulation_teachers(50));
        }
    }
}
