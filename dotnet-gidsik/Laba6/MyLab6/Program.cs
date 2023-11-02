using Library;
using System.Threading;

public class ThreadWorker
{
    private Thread thread;

    public ThreadWorker(Thread thread) { thread = new Thread(Work); }

    private void Work()
    {
        while (true)
        {
            string currentString = Console.ReadLine()!;
            switch (currentString)
            {
                //case "create": true; break;
                //case "list": true; break;
                //case "exit": true; break;
            }
            //if (stopFlag) break;
        }
    }

}



