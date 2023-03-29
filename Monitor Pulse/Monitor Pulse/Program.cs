using System;
using System.Threading;

public class WaitPulse
{
	private object mSync;
	private string mName;

	public WaitPulse(string aName, object aSync)
	{
		mName = aName;
		mSync = aSync;
	}

	public void DoJob()
	{
		lock (mSync)
		{
			Console.WriteLine("{0}: Start", mName);

			Console.WriteLine("{0}: Pulsing...", mName);
			Monitor.Pulse(mSync);

			for (int i = 1; i <= 3; i++)
			{
				Console.WriteLine("{0}: Waiting...", mName);
				Monitor.Wait(mSync);

				Console.WriteLine("{0}: WokeUp", mName);
				Console.WriteLine("{0}: Do some work...", mName);
				Thread.Sleep(1000);

				Console.WriteLine("{0}: Pulsing...", mName);
				Monitor.Pulse(mSync);
			}
			Console.WriteLine("{0}: Exiting", mName);
		}
	}
}

public class WaitPulseDemo
{
	public static void Main(String[] args)
	{
		object sync = new object();

		WaitPulse wp1 = new WaitPulse("WaitPulse1", sync);
		Thread thread1 = new Thread(new ThreadStart(wp1.DoJob));
		thread1.Start();

		WaitPulse wp2 = new WaitPulse("WaitPulse2", sync);
		Thread thread2 = new Thread(new ThreadStart(wp2.DoJob));
		thread2.Start();
	}
}
