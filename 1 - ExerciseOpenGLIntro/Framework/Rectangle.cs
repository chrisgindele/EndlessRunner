using OpenTK;

namespace Framework
{
	public class Rectangle : IReadOnlyRectangle
	{
		public Vector2 Center => Min + 0.5f * Size;
		public Vector2 Min { get; set; }
		public Vector2 Max => Min + Size;
		public Vector2 Size { get; }

		public Rectangle(IReadOnlyRectangle rectangle)
		{
			Min = rectangle.Min;
			Size = rectangle.Size;
		}

		public Rectangle(Vector2 min, Vector2 size)
		{
			Min = min;
			Size = size;
		}

		public Rectangle(float minX, float minY, float width, float height)
		{
			Min = new Vector2(minX, minY);
			Size = new Vector2(width, height);
		}

		public static Rectangle FromCenterSize(float centerX, float centerY, float width, float height)
		{
			return FromCenterSize(new Vector2(centerX, centerY), new Vector2(width, height));
		}

		public static Rectangle FromCenterSize(Vector2 center, Vector2 size)
		{
			return new Rectangle(center - 0.5f * size, size);
		}

		public Rectangle CopyTo(float minX, float minY)
		{
			return CopyTo(new Vector2(minX, minY));
		}

		public Rectangle CopyTo(Vector2 t)
		{
			return new Rectangle(Min + t, Size);
		}

		public override string ToString() => $"{Min} - {Max}";
	}
}
