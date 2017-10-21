using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueHomeTask
{
    public class MultithreadQueue
    {
        private readonly Queue<object> _queue;

        private static readonly object Sync = new object();

        private readonly AutoResetEvent _are;

        public event Action<string> PushEvent;

        public event Action<string> PopEvent;

        public MultithreadQueue()
        {
            _queue = new Queue<object>();
            _are = new AutoResetEvent(false);
        }

        public void Push(object obj)
        {
            if (obj != null)
            {
                lock (Sync)
                {
                    _queue.Enqueue(obj);
                    if (PushEvent != null)
                    {
                        PushEvent("Выполнен psuh");
                    }
                    _are.Set();
                }
            }
            else
            {
                throw new ArgumentNullException("obj");
            }
        }

        private object Wait()
        {
            object res = null;
            _are.WaitOne();
            if (_queue.Count > 0)
            {
                lock (Sync)
                {
                    if (_queue.Count > 0)
                    {
                        res = _queue.Dequeue();
                        if (PopEvent != null)
                        {
                            PopEvent("Выполнен pop с ожиданием");
                        }
                    }
                }
            }

            return res;
        }

        public object Pop()
        {
            object res = null;
            _are.Reset();
            if (_queue.Count > 0)
            {
                lock (Sync)
                {
                    if (_queue.Count > 0)
                    {
                        res = _queue.Dequeue();
                        if (PopEvent != null)
                        {
                            PopEvent("Выполнен pop");
                        }
                    }
                }
            }
            else
            {
                res = Wait();
            }

            while (res == null)
            {
                res = Wait();
            }

            return res;
        }
    }
}
