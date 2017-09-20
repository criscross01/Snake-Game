using System;
namespace Snake_Solution
{
	public class Apple : GameObject
	{
		Random random;

		public Apple (int x, int y, string graphic, Random random) : base(x, y, graphic)
		{
			this.random = random;
		}

		public void respawn()
		{
			this.x = random.Next(1, Console.WindowWidth - 2);
			this.y = random.Next(1, Console.WindowHeight - 2);
			this.draw();
		}
	}
}