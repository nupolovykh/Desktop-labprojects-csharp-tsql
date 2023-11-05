using ConsoleApp;
using System;
using System.Threading;


//SimpleThreadsExamples.SyncingThreadsExample_Synced();


AdvancedThreadsExample threadsExample = new AdvancedThreadsExample();

threadsExample.InitThreads();


bool stopFlag = false;
while (true)
{
	switch (Console.ReadKey(true).Key)
	{
		case ConsoleKey.A: threadsExample.StartWork(); break;
		case ConsoleKey.S: threadsExample.PauseWork(); break;
		case ConsoleKey.Z: threadsExample.StartAnotherWork(); break;
		case ConsoleKey.X: threadsExample.PauseAnotherWork(); break;
		case ConsoleKey.Escape: stopFlag = true; break;
	}
	if (stopFlag) break;
}

threadsExample.Dispose();

Thread.Sleep(1200);

