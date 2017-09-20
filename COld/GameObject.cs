using System;
namespace Snake_Solution
{
	public class GameObject
	{
		public int x;
		public int y;
		string graphic;

		public GameObject(int x, int y, string graphic)
		{
			this.x = x;
			this.y = y;
			this.graphic = graphic;
		}

		public void draw()
		{
			Console.SetCursorPosition(x, y);
			Console.Write(graphic);
		}

		public void undraw()
		{
			Console.SetCursorPosition(x, y);
			Console.Write(' ');
		}
	}
}