using System;
namespace Snake_Solution
{
	public class Game
	{
		private void walls()
		{
			for (int i = 1; i <= Console.WindowWidth-2; i++)
			{
				Console.SetCursorPosition(i,0);
				Console.Write("#");
				Console.SetCursorPosition(i, Console.WindowHeight - 1);
				Console.Write("#");
			}

			for (int i = 0; i <= Console.WindowHeight - 1; i++)
			{
				Console.SetCursorPosition(0, i);
				Console.Write("#");
				Console.SetCursorPosition(Console.WindowWidth - 1,i);
				Console.Write("#");
			}
		}

		public void start_new()
		{
			//Instantiate objects and set up predefined definitions
			Console.CursorVisible = false;

			//Set up random object
			Random random = new Random();

			//Creates array for snaketails
			SnakeTail[] tail = new SnakeTail[(Console.WindowWidth - 2) * (Console.WindowHeight - 2)];

			//Set up the apple object
			Apple apple = new Apple(random.Next(1, Console.WindowWidth-2),random.Next(1, Console.WindowHeight - 2),"@",random);

			//Creates player object
			SnakeHead player = new SnakeHead((Console.WindowWidth / 2), (Console.WindowHeight / 2), "X", apple, tail);

			//Draws walls
			this.walls();

			//Draws apple
			apple.draw();	

			//Draws player
			player.draw();

			while (true)
			{
				player.update();

				if (player.cur_pos != 0)
				{
					tail[0].update(player.direction);
				}

				if (player.direction == "Down" || player.direction == "Up")
				{
					System.Threading.Thread.Sleep(100);
				}
				else
				{
					System.Threading.Thread.Sleep(55);
				}

				//Checks if snake is in wall
				if (player.x == 0 || player.x == Console.WindowWidth -1 || player.y == 0 || player.y == Console.WindowHeight -1)
				{
					this.game_over(player);
					break;
				}
				//Checks if player is in snake tail
				for (int i = 0; i <= player.cur_pos - 1; i++)
				{
					if (player.x == tail[i].x && player.y == tail[i].y)
					{
						this.game_over(player);
						return;
					}
				}
			}
		}

		private void game_over(SnakeHead player)
		{
			Console.Clear();
			Console.WriteLine("GAME OVER");
			Console.WriteLine("Your Score was: " + player.cur_pos);
			Console.WriteLine("Press any key to continue");
			while (true)
			{
				if (Console.KeyAvailable == true)
				{
					Console.Clear();
					break;
				}
			}
		}
	}
}
