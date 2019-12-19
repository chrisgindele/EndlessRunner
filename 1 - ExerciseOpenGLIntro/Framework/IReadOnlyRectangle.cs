using OpenTK;

namespace Framework
{
	public interface IReadOnlyRectangle
	{
		Vector2 Max { get; }
		Vector2 Min { get; }
		Vector2 Size { get; }
	}
}