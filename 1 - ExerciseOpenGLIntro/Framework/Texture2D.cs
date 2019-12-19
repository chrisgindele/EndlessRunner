using ImageMagick;
using OpenTK.Graphics.OpenGL;
using System;
using System.IO;

namespace Framework
{
	public struct Texture2d
	{
		public enum TextureFunction
		{
			Repeat = TextureWrapMode.Repeat,
			MirroredRepeat = TextureWrapMode.MirroredRepeat,
			ClampToEdge = TextureWrapMode.ClampToEdge,
			ClampToBorder = TextureWrapMode.ClampToBorder
		}

		public Texture2d(Stream stream, bool filterLinear = true, TextureFunction textureFunction = TextureFunction.MirroredRepeat)
		{
			using (var image = new MagickImage(stream))
			{
				var format = PixelFormat.Rgb;
				switch (image.ChannelCount)
				{
					case 3: break;
					case 4: format = PixelFormat.Rgba; break;
					default: throw new ArgumentOutOfRangeException("Unexpected image format");
				}
				image.Flip();
				var bytes = image.GetPixelsUnsafe().ToArray();
				TexturId = GL.GenTexture();
				Width = image.Width;
				Height = image.Height;
				Bind();
				GL.TexImage2D(Target, 0, (PixelInternalFormat)format, image.Width, image.Height, 0, format, PixelType.UnsignedByte, bytes);
				GL.TexParameter(Target, TextureParameterName.TextureWrapS, (int)textureFunction);
				GL.TexParameter(Target, TextureParameterName.TextureWrapT, (int)textureFunction);
				GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
				var filterMagMode = filterLinear ? TextureMagFilter.Linear : TextureMagFilter.Nearest;
				var filterMinMode = filterLinear ? TextureMinFilter.LinearMipmapLinear : TextureMinFilter.NearestMipmapNearest;
				GL.TexParameter(Target, TextureParameterName.TextureMagFilter, (int)filterMagMode);
				GL.TexParameter(Target, TextureParameterName.TextureMinFilter, (int)filterMinMode);
				Unbind();
			}
		}

		public void Bind()
		{
			GL.BindTexture(Target, TexturId);
		}

		public static void Unbind()
		{
			GL.BindTexture(Target, 0);
		}

		public int TexturId { get; }
		public int Width { get; }
		public int Height { get; }

		public const TextureTarget Target = TextureTarget.Texture2D;
	}
}
