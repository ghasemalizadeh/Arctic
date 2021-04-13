using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolLibrary
{
    public abstract class Task
    {
        private Resource[] _resources { get; set; }
        private int _id;
        private long finishTime;
        private long startTime;
        public Task(Resource[] resources, int Id)
        {
            _resources = resources;
            _id = Id;

        }
        public int Id
        {
            get { return _id; }
          
        }
        public long FinishTime
        {
            get { return finishTime; }
         
        }

        public long StartTime
        {
            get { return startTime; }

        }
        public void Execute()
        {
            foreach (var res in _resources)
            {
                res.Access();
            }
           
            startTime = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine("Task {0} started in {1}", _id,startTime);
            Operation();
            finishTime = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine("Task {0} ended in {1}", _id,finishTime);
            foreach (var res in _resources)
           res.Release();

        }

        public abstract void Operation();
    }
}
