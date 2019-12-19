namespace Framework
{
	public static class SpriteSheetTools
	{
		/// <summary>
		/// Calculates the texture coordinates for a sprite inside a sprite sheet.
		/// </summary>
		/// <param name="frame">The frame number. Starts with 0 in the upper left corner and increase in western reading direction up to #sprites - 1.</param>
		/// <param name="columns">Number of sprites per row.</param>
		/// <param name="rows">Number of sprites per column.</param>
		/// <returns>Texture coordinates for a single sprite</returns>
		public static Rectangle CalcTexCoords(uint frame, uint columns, uint rows)
		{
			//TODO: Calculate texture coordinates for an animation frame (look at the method summary for details!)
			return new Rectangle(0f, 0f, 1f, 1f);
		}
	}
}
