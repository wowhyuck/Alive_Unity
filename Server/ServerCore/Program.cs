using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    // 메모리 베리어
    // A) 코드 재배치 억제
    // B) 가시성

    // 1) Full Memory Barrier (ASM MFENCE, C# Thread.MemoryBarrier) : Store / Load 둘다 막는다.
    // 2) Store Memory Barrier (ASM SFENCE) : Store만 막는다.
    // 3) Load Memory Barrier (ASM LFENCE) : Load만 막는다.

    class Program
    {
        static int number = 0;
        
        // atomic = 원자성

        static void Thread_1()
        {
            for (int i = 0; i < 100000; i++)
            {
                // All or Nothing
                int afterValue = Interlocked.Increment(ref number);
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                Interlocked.Decrement(ref number);
            }
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);
            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);

            Console.WriteLine(number);
        }
    }
}
