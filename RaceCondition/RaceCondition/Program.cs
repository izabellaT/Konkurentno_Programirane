using System;
using System.Threading;

namespace RaceCondition
{
    class Program
    {
        static void Main(string[] args)
        {
			Account acc = new Account();
			acc.mBalance = 500;
			Console.WriteLine("Account balance = {0}", acc.mBalance);
			Thread user1 = new Thread(new ThreadStart
				(acc.Withdraw100));
			Thread user2 = new Thread(new ThreadStart
				(acc.Withdraw100));
			user1.Start();
			user2.Start();
			user1.Join();
			user2.Join();
			Console.WriteLine("Account balance = {0}", acc.mBalance);
		}
	}

	class Account
	{
		public int mBalance;

		public void Withdraw100()
		{
			int oldBalance = mBalance;
			Console.WriteLine("Withdrawing 100...");
			// Simulate some delay during the processing
			Thread.Sleep(100);
			int newBalance = oldBalance - 100;
			mBalance = newBalance;
		}
	}

}
