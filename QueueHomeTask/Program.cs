using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueHomeTask
{
    class Program
    {
        private static MultithreadQueue _multithreadQueue;

        public static void PushTest()
        {
            for (int i = 0; i < 1000000; i++)
            {
                _multithreadQueue.Push(new object());
            }
        }

        public static void PopTest()
        {
            for (int i = 0; i < 1000000; i++)
            {
                _multithreadQueue.Pop();
            }
        }

        static void Main(string[] args)
        {
            _multithreadQueue = new MultithreadQueue();
            _multithreadQueue.PushEvent += (x) =>
            {
                Console.WriteLine(x);
            };
            _multithreadQueue.PopEvent += (x) =>
            {
                Console.WriteLine(x);
            };

            var t1 = new Thread(PushTest);
            t1.Priority = ThreadPriority.BelowNormal;

            var t2 = new Thread(PopTest);
            t2.Priority = ThreadPriority.Highest;
            t2.Start();
            t1.Start();

            Console.ReadLine();
        }
    }
}
