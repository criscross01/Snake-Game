using System;
namespace Snake_Solution
{
	public class Game
	{

		public void walls()
		{
			for (int i = 1; i <= Console.WindowWidth - 2 ; i ++)
			{
				Console.SetCursorPosition(i, 0);
				Console.Write("#");

				Console.SetCursorPosition(i, Console.WindowHeight - 2);
				Console.Write("#");
			}

			for (int i = 0; i <= Console.WindowHeight - 2; i++)
			{
				Console.SetCursorPosition(0, i);
				Console.Write("#");

				Console.SetCursorPosition(Console.WindowWidth - 1, i);
				Console.Write("#");
			}
		}

		public void start_new()
		{
			//Used to instantiate variables and to set up pre-defined variables
			//The random object
			Random random = new Random();

			//The apple object
			Apple apple = new Apple(random.Next(0, Console.WindowWidth - 1), random.Next(0, Console.WindowHeight - 1), "@", random);

			//The player object
			SnakeHead player = new SnakeHead(Console.WindowWidth / 2, Console.WindowHeight / 2, "X", apple);

			//Used to setup walls
			this.walls();

			while (true)
			{
				player.update();

				apple.draw();

				//Checks if player is in wall
				if (player.x == 0 || player.x == Console.WindowWidth - 1 || player.y == 0 || player.y == Console.WindowHeight - 2)
				{
					this.gameover();
					return;
				}

				System.Threading.Thread.Sleep(50);
			}
		}

		private void gameover()
		{
			Console.Clear();
			Console.WriteLine("GAME OVER");
			Console.WriteLine("Press any key to continue");

			while (true)
			{
				if (Console.KeyAvailable == true)
				{
					return;
				}
			}
		}
	}
}
