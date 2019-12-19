using OpenTK;

namespace Framework
{
	public static class IReadOnlyRectangleExtensions
	{
		public static bool Contains(this IReadOnlyRectangle rectangle, Vector2 location)
		{
			var outsideX = (location.X < rectangle.Min.X) || (rectangle.Max.X < location.X);
			var outsideY = (location.Y < rectangle.Min.Y) || (rectangle.Max.Y < location.Y);
			return !(outsideX || outsideY);
		}

		public static bool Contains(this IReadOnlyRectangle rectangle, IReadOnlyRectangle rectangleB)
		{
			var outsideX = (rectangleB.Min.X < rectangle.Min.X) || (rectangle.Max.X < rectangleB.Max.X);
			var outsideY = (rectangleB.Min.Y < rectangle.Min.Y) || (rectangle.Max.Y < rectangleB.Max.Y);
			return !(outsideX || outsideY);
		}

		public static bool Intersects(this IReadOnlyRectangle rectangleA, IReadOnlyRectangle rectangleB)
		{
			bool noXintersect = (rectangleA.Max.X <= rectangleB.Min.X) || (rectangleA.Min.X >= rectangleB.Max.X);
			bool noYintersect = (rectangleA.Max.Y <= rectangleB.Min.Y) || (rectangleA.Min.Y >= rectangleB.Max.Y);
			return !(noXintersect || noYintersect);
		}
	}
}
