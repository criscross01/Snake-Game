using System;
namespace Snake_Solution
{
	public class SnakeTail : GameObject
	{
		SnakeTail[] tail;
		string cur_direction;
		int position;
		SnakeHead player;
		string next_direction;
		public string direction;

		public SnakeTail(int x, int y, string graphic, SnakeTail[] tail, int position, string direction, SnakeHead player) : base(x, y, graphic)
		{
			this.direction = direction;
			this.tail = tail;
			this.position = position;
			this.next_direction= direction;
			this.cur_direction = direction;
			this.player = player;
		}

		public void create()
		{
			if (position == 0)
			{
				switch (direction)
				{
					case "Right":
						this.x -= 2;
						break;
					case "Left":
						this.x += 2;
						break;
					case "Up":
						this.y += 2;
						break;
					case "Down":
						this.y -= 2;
						break;
				}
			}

			else
			{
				switch (tail[position-1].direction)
				{
					case "Right":
						this.x --;
						break;
					case "Left":
						this.x ++;
						break;
					case "Up":
						this.y++;
						break;
					case "Down":
						this.y --;
						break;
				}
			}
			base.draw();
		}

		public void update(string direction)
		{
			base.undraw();
			//If the direction changes
			if (direction != cur_direction)
			{
				//Set direction to next direction
				next_direction = direction;
			}

			switch (cur_direction)
			{
				case "Right":
					this.x++;
					break;
				case "Left":
					this.x--;
					break;
				case "Up":
					this.y--;
					break;
				case "Down":
					this.y++;
					break;
			}

			if (player.cur_pos - 1 > position)
			{
				tail[position + 1].update(this.cur_direction);
			}

			cur_direction = next_direction;
			base.draw();
		}
	}
}