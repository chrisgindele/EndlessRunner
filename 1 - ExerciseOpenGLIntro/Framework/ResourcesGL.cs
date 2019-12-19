using System.Collections.Generic;

namespace Framework
{
	/// <summary>
	/// Manage OpenGL textures
	/// </summary>
	public class ResourcesGL
	{
		public ResourcesGL(IResourceProvider resourceProvider)
		{
			this.resourceProvider = resourceProvider;
		}

		/// <summary>
		/// Get texture by name
		/// </summary>
		/// <param name="name">resource name of the texture</param>
		/// <returns></returns>
		public Texture2d GetTexture(string name, bool filterLinear = true)
		{
			if (textures.TryGetValue(name, out var texture))
			{
				return texture;
			}
			texture = new Texture2d(resourceProvider.Open(name), filterLinear);
			textures[name] = texture;
			return texture;
		}

		public void BindTexture(string name, bool filterLinear = true)
		{
			if (textures.TryGetValue(name, out var texture))
			{
				if (currentTexture.TexturId != texture.TexturId)
				{
					texture.Bind();
					currentTexture = texture;
				}
			}
			else
			{
				texture = new Texture2d(resourceProvider.Open(name), filterLinear);
				textures[name] = texture;
				texture.Bind();
			}
		}

		private readonly Dictionary<string, Texture2d> textures = new Dictionary<string, Texture2d>();
		private readonly IResourceProvider resourceProvider;
		private Texture2d currentTexture;
	}
}
