This example has the goal of getting to know C# and OpenGL. Implement the following items (**10 points**):

1. Build and execute the program.
1. Change the clear color of the screen.
1. Move the draw code for the quad into a method `void DrawRectangle(Vector2 min, Vector2 size)` (**2 points**). 
	+ The call `DrawRectangle(new Vector2(0.5f, 0.5f), new Vector2(0.1f, 0.1f));` should for instance draw a rectangle with the lower-left coordinates (0.5, 0.5) and upper-right coordinates (0.6, 0.6).
1. Use this method to draw 10 rectangles (**4 points**). 
	+ Each rectangle should be completely inside the window and have a different random size > 0. 
	+ You can use the `Random` class for generating the required random numbers.
	+ Create the 10 sizes and positions once and reuse them when drawing each frame.
	+ I recommend creating a `class MyRectangle`.
1. Give each rectangle a different persistent color (**1 points**).
	+ Note that OpenGL is a state machine. A color stays active until another color is set.
1. Control one of the rectangles with the keyboard (**3 points**)
	+ Put the code in the `OnUpdateFrame(FrameEventArgs arguments)`method
	+ You can use the `input.IsButtonDown(string name)` method.
    + Scale the movement with the time between 2 frames. This value is available in `arguments.Time`.
	1. Make this rectangle move to the left as long as the left cursor key `Left` is pressed down.
	1. Handle `Right`, `Up` and `Down` keys accordingly.
	1. The rectangle should only be allowed to move inside the window.

![Screenshot](screenshot.png)