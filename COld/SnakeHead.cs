using System;
namespace Snake_Solution
{
	public class SnakeHead : GameObject
	{
		public string direction = "Right";

		public int cur_pos;

		Apple apple;

		SnakeTail[] tail;

		public SnakeHead(int x, int y, string graphic, Apple apple, SnakeTail[] tail) : base(x, y, graphic)
		{
			
			this.apple = apple;
			this.tail = tail;
		}

		public void update()
		{
			//Removes last graphic of snake
			base.undraw();

			//Check if key is pressed and set direction
			if (Console.KeyAvailable == true)
			{
				//Detects key pressed
				ConsoleKeyInfo cki = Console.ReadKey(true);

				//Changes directions based on key pressed
				switch (cki.Key)
				{
					case ConsoleKey.UpArrow:
					case ConsoleKey.W:
						if (direction != "Down")
						{
							direction = "Up";
						}
						break;
					case ConsoleKey.DownArrow:
					case ConsoleKey.S:
						if (direction != "Up")
						{
							direction = "Down";
						}
						break;
					case ConsoleKey.RightArrow:
					case ConsoleKey.D:
						if (direction != "Left")
						{
							direction = "Right";
						}
						break;
					case ConsoleKey.LeftArrow:
					case ConsoleKey.A:
						if (direction != "Right")
						{
							direction = "Left";
						}
						break;
				}
			}
			//Move Snake towards direction
			switch (direction)
			{
				case "Up":
					base.y--;
					break;
				case "Down":
					base.y++;
					break;
				case "Right":
					base.x++;
					break;
				case "Left":
					base.x--;
					break;
			}

			//Check if on top of apple
			if (this.x == apple.x && this.y == apple.y)
			{
				//If so respawn apple
				apple.respawn();

				//And grow tail
				if (cur_pos == 0)
				{
					tail[cur_pos] = new SnakeTail(this.x, this.y, "X", tail, cur_pos, this.direction,this);
					tail[cur_pos].create();
				}
				else
				{
					tail[cur_pos] = new SnakeTail(tail[cur_pos - 1].x, tail[cur_pos - 1].y, "X", tail, cur_pos,tail[cur_pos-1].direction,this);
					tail[cur_pos].create();
				}
				cur_pos++;
			}
			//Draws updated
			base.draw();
		}
	}
}