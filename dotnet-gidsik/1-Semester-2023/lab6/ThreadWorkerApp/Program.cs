using Library;
using System.Reflection.Metadata;
using System.Threading;


ThreadWorker worker = new ThreadWorker();
worker.Work();



public class ThreadWorker
{
    private Thread _backgroundThread;
    private Queue<string> queue;
    private List<Person> people;

    private static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
    private static Mutex _mutex = new Mutex();
    private static object _locker = new object();

    public ThreadWorker()
    {
        _backgroundThread = new Thread(ThreadMethod) {Name = "Background"};
        queue = new Queue<string>();
        people = new List<Person>();
    }

    public void Work()
    {
        while (true)
        {
            string currentCommand = Console.ReadLine()!.Trim().ToLower();
            switch (currentCommand)
            {
                case "create": {
                    _mutex.WaitOne();
                    queue.Enqueue(ParticularMethods.Create(0));
                    queue.Enqueue(ParticularMethods.Create(1));
                    Thread.Sleep(5000);
                    _mutex.ReleaseMutex();

                    if(_backgroundThread.ThreadState == ThreadState.Unstarted) _backgroundThread.Start();
                    autoResetEvent.Set();
                }
                    break;
                case "list": {
                    if (Monitor.TryEnter(_locker))
                    {
                        ParticularMethods.List(people);
                        Monitor.Exit(_locker);
                        Thread.Sleep(5000);
                    }
                    else Console.WriteLine("List unavailable now");
                }
                    break;
                case "exit": {
                    _backgroundThread.Interrupt();
                    return;
                }
                default: Console.WriteLine("Undefiant command");
                    break;
            }
        }
    }

    private void ThreadMethod(){
        while(true)
        {
            autoResetEvent.WaitOne();
            while(queue.Count > 1){
                _mutex.WaitOne();
                var name = queue.Dequeue();
                var age = int.Parse(queue.Dequeue());
                Thread.Sleep(5000);
                _mutex.ReleaseMutex();

                lock (_locker){
                    people.Add(new Person(name, age));
                    people = people.OrderBy(_person => _person.age).ToList();
                    Thread.Sleep(5000);
                }
            }
        }
    }

}
