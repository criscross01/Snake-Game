using System;
namespace Snake_Solution
{
	public class Menu
	{
		private void draw_mainMenu()
		{
			Console.SetWindowSize(50, 20);

			Console.SetCursorPosition((Console.WindowWidth / 2) -2, (Console.WindowHeight / 2) - 5);
			Console.Write("SNAKE");

			Console.SetCursorPosition((Console.WindowWidth / 2) - 4, (Console.WindowHeight / 2));
			Console.Write("Play Game");
		
			Console.SetCursorPosition((Console.WindowWidth / 2) - 3, (Console.WindowHeight / 2)+ 2);
			Console.Write("Options");

			Console.SetCursorPosition((Console.WindowWidth / 2) - 8, (Console.WindowHeight / 2) + 4);
			Console.Write("Don't Press This!!! :(");

			Console.SetCursorPosition((Console.WindowWidth / 2) - 2, (Console.WindowHeight /2 ) + 6);
			Console.Write("Quit");
		}

		public void main_menu()
		{
			Game game;
			draw_mainMenu();
			int selected = 0;
			while (true)
			{
				//Places X in next position
				Console.Write(' ');
				switch (selected)
				{
					case 0:
						Console.SetCursorPosition((Console.WindowWidth / 2) - 6, (Console.WindowHeight / 2));
						break;
					case 1:
						Console.SetCursorPosition((Console.WindowWidth / 2) - 5, (Console.WindowHeight / 2)+ 2);
						break;
					case 2:
						Console.SetCursorPosition((Console.WindowWidth / 2) - 10, (Console.WindowHeight / 2)+ 4);
						break;
					case 3:
						Console.SetCursorPosition((Console.WindowWidth / 2) - 4, (Console.WindowHeight /2 ) + 6);
						break;
				}
				Console.Write('X');

				if (Console.KeyAvailable == true)
				{
					ConsoleKeyInfo cki = Console.ReadKey(true);

					switch (selected)
					{
						case 0:
							Console.SetCursorPosition((Console.WindowWidth / 2) - 6, (Console.WindowHeight / 2));
							Console.Write(' ');
							break;
						case 1:
							Console.SetCursorPosition((Console.WindowWidth / 2) - 5, (Console.WindowHeight / 2) + 2);
							Console.Write(' ');
							break;
						case 2:
							Console.SetCursorPosition((Console.WindowWidth / 2) - 10, (Console.WindowHeight / 2) + 4);
							Console.Write(' ');
							break;
						case 3:
							Console.SetCursorPosition((Console.WindowWidth / 2) - 4, (Console.WindowHeight / 2) + 6);
							Console.Write(' ');
							break;
					}

					switch (cki.Key)
					{
					case ConsoleKey.UpArrow:
					case ConsoleKey.W:
						if (selected != 0)
						{
							selected--;
						}
						break;
					case ConsoleKey.DownArrow:
					case ConsoleKey.S:
						if (selected != 3)
						{
							selected++;
						}
						break;
					}
					if (cki.Key == ConsoleKey.Enter)
					{
						switch (selected)
						{
							case 0:
								Console.Clear();
								game = new Game();
								game.start_new();
								this.draw_mainMenu();
								break;
							case 1:
								Console.Clear();
								Console.WriteLine("You're in options!");
								Console.Write("Press any key to exit");
								while (true)
								{
									if (Console.KeyAvailable == true)
									{
										break;
									}
								}
								Console.Clear();
								this.draw_mainMenu();
								break;
							case 2:
								Console.Clear();
								Console.WriteLine("CONGRATULATIONS!!!!");
								Console.WriteLine("You Found the Robin Easter Egg!");
								Console.Write("Press any key to exit");
								while (true)
								{
									if (Console.KeyAvailable == true)
									{
										break;
									}
								}
								Console.Clear();
								this.draw_mainMenu();
								break;
							case 3:
								return;
						}
					}
				}
			}
		}
	}
}
