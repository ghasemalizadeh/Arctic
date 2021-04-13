using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadPoolLibrary
{
    public class Resource
    {
        public string Name { get; }

        private Mutex Mutex { get;}

        public Resource(string name)
        {
            this.Name = name;
            this.Mutex = new Mutex();
        }

        private int count;

        public int NumberOfConcurrentAccess
        {
            get { return count; }
           
        }
        public bool Access()
        {
            Mutex.WaitOne();
            count += 1;
            return true;
        }

        public void Release()
        {
            count -= 1;
            Mutex.ReleaseMutex();
          

        }

    }
}
