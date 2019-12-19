using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;


namespace Example
{
	/// <summary>
	/// The exercises window code derived from <seealso cref="GameWindow"/>.
	/// </summary>
	internal class MyWindow : GameWindow
	{
		public MyWindow()
		{
			//TODO: Change the clear color of the screen.
			GL.ClearColor(OpenTK.Color.NavajoWhite); // set the clear color of the screen
			keyboard = new KeyboardState(this);

            CreateRectangles(); //fills the empty rectangles array
		}

		private readonly KeyboardState keyboard;
        private RectangleShape[] rectangles = new RectangleShape[9];
        private RectangleShape playerChar = new RectangleShape(new Vector2(-0.5f,-0.5f),new Vector2(0.05f,0.1f),new Vector3(0f,0f,0f),new Vector3(0f, 0f, 0f));
        private bool alive = true; //if player dies, set alive to false to not update game objects and pause the game
        private float spawnTimer; //respawns obstacles

        /// <summary>
        /// Will be called each time the frame is rendered.
        /// </summary>
        /// <param name="arguments"></param>
        protected override void OnRenderFrame(FrameEventArgs arguments)
		{
			base.OnRenderFrame(arguments); // call the GameWindows implementation before executing the example code

			GL.Clear(ClearBufferMask.ColorBufferBit); // clear the screen
            
            DrawRectangle(new Vector2(-1f, -1f), new Vector2(2f, 0.5f), new Vector3(0f,0f,0f), new Vector3(0f, 0f, 0f)); //floor

            DrawRectangles(); //obstacles

            DrawRectangle(playerChar.Pos, playerChar.Size, playerChar.Color,playerChar.Color); //player character

            SwapBuffers(); // buffer swap needed for double buffering
		}

		/// <summary>
		/// Will be called each time the window is resized
		/// </summary>
		/// <param name="sender">The calling window.</param>
		/// <param name="arguments"></param>
		protected override void OnResize(EventArgs arguments)
		{
			base.OnResize(arguments); // call the GameWindows implementation before executing the example code

			GL.Viewport(0, 0, Width, Height); // tell OpenGL to use the whole window for drawing
		}

		/// <summary>
		/// Will be called for each game loop iteration, so by default exactly 60 times a second
		/// </summary>
		/// <param name="arguments"></param>
		protected override void OnUpdateFrame(FrameEventArgs arguments)
		{
			base.OnUpdateFrame(arguments);
            float time = (float)arguments.Time;

            if (alive == true)
            {
                playerChar = keyboard.MovePlayer(playerChar, time);
                playerChar.Gravity(time);
                SpawnBlocks(time);
                foreach(RectangleShape rect in rectangles)
                {
                    rect.MoveBlock(time);
                    if (playerChar.Intersects(rect))
                    {
                        alive = false;
                    }
                }
            }
            else{
                playerChar.SetColor(new Vector3(1f, 0f, 0f));
            }
            
        }
        /// <summary>
        /// Respawns Blocks if they are left of the screen but never faster than spawnTimer
        /// </summary>
        private void SpawnBlocks(float time)
        {
             spawnTimer -= time; //always reduce SpawnTimer
             for(int i=0; i < rectangles.Length; i++) //check every rectangle
            {
                if(spawnTimer<=0f && rectangles[i].Pos.X < -1.1f) //if rectangle is outside and spawnTimer is finished, make new rectangle instead and place it to the right
                {
                    rectangles[i] = CreateRectangle();
                    rectangles[i].SetPos(new Vector2(1.05f, -0.5f));
                    Random rand = new Random();
                    spawnTimer = (float)rand.NextDouble() + 0.3f;
                }
            }
        }

        private void DrawRectangle(Vector2 min, Vector2 size, Vector3 color, Vector3 color2)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(color[0], color[1], color[2]);
            GL.Vertex2(min[0], min[1]);
            GL.Vertex2(min[0] +(size[0]), min[1]);
            GL.Vertex2(min[0] + (size[0]), min[1] + (size[1]));
            GL.Vertex2(min[0], min[1] + (size[1]));
            GL.Color3(0f,0f,0f);
            GL.End();
        }
        /// <summary>
        /// Creates one Rectangle on the left, outside of the screen 
        /// </summary>
        /// <returns></returns>
        public RectangleShape CreateRectangle()
        {
            Random random = new Random();
            Vector2 pos = new Vector2(-1.1f, ((float)random.NextDouble()*2f - 1f)*0.7f);
            Vector2 size = new Vector2(((float)random.NextDouble()+0.05f)*0.07f, ((float)random.NextDouble()+0.2f)*0.1f);
            Vector3 color = new Vector3((float)random.NextDouble()-0.2f, (float)random.NextDouble()-0.2f, (float)random.NextDouble()-0.2f);
            Vector3 color2 = new Vector3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());

            RectangleShape rectangle = new RectangleShape(pos,size,color,color2);
            return rectangle;
        }

        private void CreateRectangles()
        {
            for(int i = 0; i < rectangles.Length; i++)
            {
                rectangles[i] = CreateRectangle();
            }
        }

        private void DrawRectangles()
        {
            for (int i = 0; i < rectangles.Length; i++)
            {
                DrawRectangle(rectangles[i].Pos,rectangles[i].Size,rectangles[i].Color,rectangles[i].Color2 );
            }
        }
    }
}