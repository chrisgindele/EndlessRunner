using OpenTK;
using OpenTK.Input;

namespace Example
{
	class Program
	{
		static void Main(string[] args)
		{
			var window = new MyWindow(); // create the example window
			window.WindowState = WindowState.Maximized; // render the window maximized
			window.Run(); // start the game loop with 60Hz
		}
	}
}
