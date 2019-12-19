using System;
using System.IO;

namespace Framework
{
	public class FileResourceProvider : IResourceProvider
	{
		public FileResourceProvider(string rootPath)
		{
			this.rootPath = rootPath;
		}

		public bool Exists(string name)
		{
			return File.Exists(GetFileName(name));
		}

		public Stream Open(string name)
		{
			return File.OpenRead(GetFileName(name));
		}

		private string GetFileName(string name)
		{
			return Path.Combine(rootPath, name);
		}

		private readonly string rootPath;
	}
}
