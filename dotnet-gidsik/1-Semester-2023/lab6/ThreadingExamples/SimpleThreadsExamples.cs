using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp;

public static class SimpleThreadsExamples
{
	public static void ThreadsWorkingExample()
	{
		Thread.CurrentThread.Name = "Main  ";

		var thread2 = new Thread(() =>
		{
			for (int i = 0; i < 3; i++)
			{
				Console.WriteLine($"Writing from thread #{Thread.CurrentThread.ManagedThreadId} {Thread.CurrentThread.Name} - number {i + 1}");
				Thread.Sleep(1);
			}
			Thread.Sleep(5000);
			Console.WriteLine("Last WriteLine Inner _2_ !!!");
		})
		{
			Name = "Inner2"
		};
		var thread1 = new Thread(() =>
		{
			for (int i = 0; i < 3; i++)
			{
				Console.WriteLine($"Writing from thread #{Thread.CurrentThread.ManagedThreadId} {Thread.CurrentThread.Name} - number {i + 1}");
				Thread.Sleep(1);
			}
			Thread.Sleep(8000);
			Console.WriteLine("Last WriteLine Inner _1_ !!!");
		})
		{
			Name = "Inner1"
		};

		thread2.Start();
		thread1.Start();

		for (int i = 0; i < 3; i++)
		{
			Console.WriteLine($"Writing from thread #{Thread.CurrentThread.ManagedThreadId} {Thread.CurrentThread.Name} - number {i + 1}");
			Thread.Sleep(2);
		}

		//thread1.Join();
		thread2.Join();
		Console.WriteLine("Last WriteLine Main!!! LAST EVER!!!");
	}

	public static void InitializingThreadsExample()
	{
		{
			Thread thread1 = new Thread(Print);
			Thread thread2 = new Thread(new ThreadStart(Print));
			Thread thread3 = new Thread(() => Print());

			thread1.Start();
			thread2.Start();
			thread3.Start();
		}


		{
			Thread thread1 = new Thread(PrintPerson);
			Thread thread2 = new Thread(new ParameterizedThreadStart(PrintPerson));
			Thread thread3 = new Thread((person) => PrintPerson(person));

			var person = new Person("Vovan", 10);

			thread1.Start(person);
			thread2.Start(person);
			thread3.Start(person);
		}
	}

	public static void SyncingThreadsExample_UnSynced()
	{
		List<Thread> threads = new List<Thread>();
		for (int i = 0; i < 10; i++)
		{
			threads.Add(new Thread(PrintInThread_UnSynced) { Name = i.ToString() });
		}
		threads.ForEach(thread => thread.Start());
	}
	private static void PrintInThread_UnSynced()
	{
		_num = 1;
		for (int i = 0; i < 10; i++)
		{
			Console.WriteLine($"Thread [{Thread.CurrentThread.Name}] - number [{_num++}]!");
			Thread.Sleep(1);
		}
	}


	static int _num = 1;
	public static void SyncingThreadsExample_Synced()
	{
		List<Thread> threads = new List<Thread>();
		for (int i = 1; i < 10; i++)
		{
			threads.Add(new Thread(PrintInThread_Synced) { Name = i.ToString() });
		}

		threads.ForEach(thread => thread.Start());
	}

	static object _locker = new object();
	static Mutex _mutex = new Mutex();
	static AutoResetEvent autoResetEvent = new AutoResetEvent(true);
	private static void PrintInThread_Synced()
	{
		//lock (_locker)
		//{
			//Monitor.Enter(_locker);
			autoResetEvent.WaitOne();
			//_mutex.WaitOne();

			_num = 1;
			for (int i = 1; i < 10; i++)
			{
				Console.WriteLine($"Thread [{Thread.CurrentThread.Name}] - number [{_num++}]!");
				Thread.Sleep(1);

			}

			//_mutex.ReleaseMutex();
			autoResetEvent.Set();
			//Monitor.Exit(_locker);
		//}
	}


	static void Print() => 
		Console.WriteLine("Hello I'm in the Thread!");
	static void PrintPerson(object? person)
	{
		if (person is not Person) throw new Exception();
		Console.WriteLine(person?.ToString());
	}
	
	record class Person(string Name, int Age)
	{
		public override string ToString() => $"Person's name is {Name} and age is {Age}";
	}


}
