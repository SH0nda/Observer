using System;
using System.Collections.Generic;

namespace Test
{
	class main
	{
		public static void Main(string[] args)
		{
			Suuchi s = new Suuchi();
			Observer o1 = new NishinHyouji();
			Observer o2 = new JyuurokushinHyouji();

			s.attach(o1);
			s.attach(o2);
			s.detach(o1);

			int i = 0;
			while (i < 100)
			{
				s.putValue(i);
				Random r = new Random();
				i += (int)(r.NextDouble() * 30) - 10;
			}
			Console.ReadLine();
		}
	}

	public abstract class Subject
	{
		public List<Observer> observers;

		public Subject()
		{
			observers = new List<Observer>();
		}

		public void attach(Observer o)
		{
			observers.Add(o);
		}

		public void detach(Observer o)
		{
			observers.Remove(o);
		}

		public void tsuuchi()
		{
			foreach (Observer observer in observers)
			{
				observer.update(this);
			}
		}
	}

	public class Suuchi : Subject
	{
		int suuchiState;
		int atai;

		public int getState()
		{
			return suuchiState;
		}

		public void putValue(int atai)
		{
			if (atai > this.atai)
			{
				this.atai = atai;
				this.tsuuchi();
			}
			else
			{
				Console.WriteLine("確認用メッセージ:更新していません");
			}
		}

		public int getValue()
		{
			return atai;
		}
	}

	public interface Observer
	{
		void update(Subject s);
	}

	class NishinHyouji : Observer
	{
		public void update(Subject s)
		{
			print(((Suuchi)s).getValue());
		}

		private void print(int n)
		{
			Console.WriteLine(n + "を2進数で表示します");
			Console.WriteLine(Convert.ToString((n), 2));
		}
	}

	class JyuurokushinHyouji : Observer
	{
		public void update(Subject s)
		{
			print(((Suuchi)s).getValue());
		}

		private void print(int n)
		{
			Console.WriteLine(n + "を16進数で表示します");
			Console.WriteLine(Convert.ToString((n), 16));
		}
	}

}
