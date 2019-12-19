using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;

namespace Example
{
    public class RectangleShape
    {

        public Vector2 Pos { get; private set; }
        public Vector2 Size { get; private set; }
        public Vector3 Color { get; private set; }
        public Vector3 Color2 { get; private set; }
        public float Velocity { get; private set; }

        public RectangleShape(Vector2 pos, Vector2 size, Vector3 color, Vector3 color2)
        {
            Size = size;
            Pos = pos;
            Color = color;
            Color2 = color2;
        }

        internal void SetPos(Vector2 pos)
        {
            Pos = pos;
        }
        internal void SetColor(Vector3 color)
        {
            Color = color;
        }
        /// <summary>
        /// Gravity System
        /// </summary>
        /// <param name="Gravity"></param>
        public void Gravity(float time)
        {
            if (Velocity > 0f) //smoothing the slowdown of the velocity
            {
                Velocity -= 20f*time;
            }
            else //velocity should not be negative
            {
                Velocity = 0f;
            }
            Pos = Vector2.Add(Pos, new Vector2(0f, Velocity * time)); //applying the velocity to the position

            if (Pos.Y > -0.5f) //gravity if not on the floor
            {
                Pos = Vector2.Add(Pos, new Vector2(0f, -1.8f * time));
            }
            if(Pos.Y<=-0.5f) //correction so that the character does not fall lower than the floor
            {
                Pos = new Vector2(-0.5f, -0.5f);
            }
        }

        /// <summary>
        /// Velocity applies an upwards velocity to the character(s)
        /// </summary>
        /// <param name="velo"></param>
        internal void AddVelocity(float velo)
        {
            if (Pos.Y <= -0.5f) //if standing on the ground
            {
                Velocity = velo;
            }
        }

        /// <summary>
        /// Moves Obstacles to the left
        /// </summary>
        /// <param name="time"></param>
        internal void MoveBlock(float time) 
        {
            Pos = Vector2.Add(Pos, new Vector2(-0.8f* time, 0f));
        }

        /// <summary>
        /// Intersection test
        /// </summary>
        /// <param name="otherRect"></param>
        /// <returns></returns>
        public bool Intersects(RectangleShape otherRect)
        {
            if(Pos.X+Size.X>otherRect.Pos.X                     //is the right side of our Player able to touch the left side of the Obstacle?
                && Pos.X < otherRect.Pos.X + otherRect.Size.X   //is the right side of the Obstacle already more to the left than the left side of our Player?
                && Pos.Y < otherRect.Pos.Y + otherRect.Size.Y) // and is the bottom of our Player not higher than the upper side of the Obstacle?
            {
                return true; //collision, player was colliding and not jumping
            }
            return false; //no collision
        }

        
    }
}
