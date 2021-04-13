using System;
using System.Threading;

namespace ThreadPoolLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Resource resA = new Resource("A");
            Resource resB = new Resource("B");
            Resource resC = new Resource("C");
            Resource resD = new Resource("D");

            Task item1 = new MyTask(new Resource[]{resA},1,100);
            Task item2 = new MyTask(new Resource[] { resB }, 2,100);
            Task item3 = new MyTask(new Resource[] { resA,resB },3, 200);
            Task item4 = new MyTask(new Resource[] { resC }, 4,300);
            Task item5 = new MyTask(new Resource[] { resB }, 5,400);

            MyThreadPool.Dispach(item1);
            MyThreadPool.Dispach(item2);
            MyThreadPool.Dispach(item3);
            MyThreadPool.Dispach(item4);
            MyThreadPool.Dispach(item5);


            Console.ReadKey();






        }
    }
}
