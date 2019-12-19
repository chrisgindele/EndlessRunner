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
            if (IsKeyDown(Key.Space))
            {
                playerChar.AddVelocity(5.5f);
            }
            return playerChar;
        }

		private HashSet<Key> pressedKeys = new HashSet<Key>();
	}
}
