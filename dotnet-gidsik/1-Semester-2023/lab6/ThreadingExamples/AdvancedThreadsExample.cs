using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp;

public class AdvancedThreadsExample : IDisposable
{
	//private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

	private Thread _workThread;
	private EventWaitHandle _workThreadEventWaitHandle = new AutoResetEvent(false);

	private Thread _anotherWorkThread;
	private EventWaitHandle _anotherWorkThreadEventWaitHandle = new ManualResetEvent(false);

	public AdvancedThreadsExample() { }

	public void InitThreads()
	{
		if (_workThread is null || _workThread.ThreadState is ThreadState.Stopped)
		{
			_workThread = new Thread(WorkBackground) { Name = "WorkThread" };
			_workThread.Start();
		}
		if (_anotherWorkThread is null || _anotherWorkThread.ThreadState is ThreadState.Stopped)
		{
			_anotherWorkThread = new Thread(AnotherWorkBackground) { Name = "AnotherWorkThread" };
			_anotherWorkThread.Start();
		}
	}

	public void StartWork() =>_workThreadEventWaitHandle.Set();
	public void StartAnotherWork() => _anotherWorkThreadEventWaitHandle.Set();

	public void PauseWork() => _workThreadEventWaitHandle.Reset();
	public void PauseAnotherWork() => _anotherWorkThreadEventWaitHandle.Reset();

	public void DeInitThreads()
	{
		PauseWork();
		PauseAnotherWork();
		while ( 
			_workThread.ThreadState			!= ThreadState.WaitSleepJoin && 
			_anotherWorkThread.ThreadState	!= ThreadState.WaitSleepJoin
		) 
		{
			Thread.Sleep(10);
		}

		//_cancellationTokenSource.Cancel();

		_workThread.Interrupt();
		_anotherWorkThread.Interrupt();

		_workThread.Join();
		_anotherWorkThread.Join();
	}

	public void Dispose() => DeInitThreads();

	private void WorkBackground()
	{
		try
		{
			while (_workThreadEventWaitHandle.WaitOne())
			{
				Console.WriteLine($"{Thread.CurrentThread.Name} is Doing some work!");
				Thread.Sleep(1000);

				//if (_cancellationTokenSource.IsCancellationRequested) { return; }
			};
		}
		catch (ThreadInterruptedException ex)
		{
			Console.WriteLine($"{Thread.CurrentThread.Name} is Interrupted");
		}
	}

	private void AnotherWorkBackground()
	{
		try
		{
			while (_anotherWorkThreadEventWaitHandle.WaitOne())
			{
				Console.WriteLine($"{Thread.CurrentThread.Name} is Doing some work!");
				Thread.Sleep(2000);

				//if (_cancellationTokenSource.IsCancellationRequested) { return; }
			};
		}
		catch ( ThreadInterruptedException ex )
		{
			Console.WriteLine($"{Thread.CurrentThread.Name} is Interrupted");
		}
	}

}
