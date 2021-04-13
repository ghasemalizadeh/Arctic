using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadPoolLibrary
{
    public static class MyThreadPool
    {
        public static int MaximumCount = 1000;
        private static int NumOfRunningThreads;
        static bool isProcessing = false;

        private static object myLock = new object();

        private static Queue<Task> Tasks = new Queue<Task>();


        public static void Dispach(Task item)
        {

            lock (myLock)
            {
                Tasks.Enqueue(item);
                Thread.Sleep(2);
                if(!isProcessing)
                System.Threading.Tasks.Task.Run(() => ProcessQueue());
            }

        }

        public static void ProcessQueue()
        {
            bool shouldContinue;
            lock (myLock)
            {
                do
                {

                    Task item;
                    shouldContinue = Tasks.TryPeek(out item);
                    if (NumOfRunningThreads < MaximumCount)
                    {
                        
                        shouldContinue = Tasks.TryDequeue(out item);
                        if (!shouldContinue)
                        {
                            isProcessing = false;
                        }

                        ThreadStart starter = new ThreadStart(item.Execute);
                        starter += () =>
                        {
                            NumOfRunningThreads--;
                          //  Console.WriteLine("num of running {0}", NumOfRunningThreads);
                        };
                        Thread newThread = new Thread(starter);
                        newThread.Name = String.Format("Thread {0}", item.Id);
                        newThread.Start();
                        NumOfRunningThreads++;
                    //    Console.WriteLine("Started {0}", newThread.Name);
                    }
                    

                }
                while (shouldContinue);
            }
        }

       
    }
}
