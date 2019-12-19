using OpenTK.Graphics.OpenGL;

namespace Framework
{
	public static class Shapes
	{
		/// <summary>
		/// Draws a rectangle using the provided texture coordinates.
		/// </summary>
		/// <param name="rectangle">The rectangle.</param>
		/// <param name="texCoords">The texture coordinates of the rectangle.</param>
		public static void Draw(this IReadOnlyRectangle rectangle, IReadOnlyRectangle texCoords)
		{
			//TODO: draw a rectangle with geometrical coordinates taken from rectangle and texture coordinates taken from texCoords
			GL.Begin(PrimitiveType.Quads);
			GL.Vertex2(rectangle.Min);
			GL.Vertex2(rectangle.Max.X, rectangle.Min.Y);
			GL.Vertex2(rectangle.Max);
			GL.Vertex2(rectangle.Min.X, rectangle.Max.Y);
			GL.End();
		}
	}
}
