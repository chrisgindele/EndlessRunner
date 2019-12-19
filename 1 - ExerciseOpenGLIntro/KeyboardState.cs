using OpenTK;
using OpenTK.Input;
using System.Collections.Generic;
using System;
using System.Text;
using System.Drawing;
using OpenTK.Platform;
using System.ComponentModel;

namespace Example
{
	public class KeyboardState
	{
		public KeyboardState(INativeWindow window)
		{
			window.KeyDown += (s, a) => pressedKeys.Add(a.Key);
			window.KeyUp += (s, a) => pressedKeys.Remove(a.Key);
		}

		public bool IsKeyDown(Key key)
		{
			return pressedKeys.Contains(key);
		}

        public RectangleShape MovePlayer(RectangleShape playerChar, float time)
        {
            /*
            if (this.IsKeyDown(Key.A) || this.IsKeyDown(Key.Left))
            {
                if (playerChar.GetPos()[0] >= -1)
                {
                    playerChar.SetPos(new Vector2(playerChar.GetPos()[0] - time, playerChar.GetPos()[1]));
                }
            }
            if (this.IsKeyDown(Key.W) || this.IsKeyDown(Key.Up))
            {
                if (playerChar.GetPos()[1] + playerChar.GetSize()[1] <= 1)
                {
                    playerChar.SetPos(new Vector2(playerChar.GetPos()[0], playerChar.GetPos()[1] + time));
                }
            }
            if (this.IsKeyDown(Key.S) || this.IsKeyDown(Key.Down))
            {
                if (playerChar.GetPos()[1] >= -1)
                {
                    playerChar.SetPos(new Vector2(playerChar.GetPos()[0], playerChar.GetPos()[1] - time));
                }
            }
            if (this.IsKeyDown(Key.D) || this.IsKeyDown(Key.Right))
            {
                if (playerChar.GetPos()[0] + playerChar.GetSize()[0] <= 1)
                {
                    playerChar.SetPos(new Vector2(playerChar.GetPos()[0] + time, playerChar.GetPos()[1]));
                }
            }
            */
            if (this.IsKeyDown(Key.Space))
            {
                playerChar.AddVelocity(5.5f);
            }
            return playerChar;
        }

		private HashSet<Key> pressedKeys = new HashSet<Key>();
	}
}
