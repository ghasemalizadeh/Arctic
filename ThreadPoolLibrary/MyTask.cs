using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadPoolLibrary
{
    public class MyTask : Task
    {
        private int _duration;
        public MyTask(Resource[] resources,int id, int duration) : base(resources, id)
        {
            _duration = duration;

        }
        public override void Operation()
        {
            Thread.Sleep(_duration);
        }
    }
}
