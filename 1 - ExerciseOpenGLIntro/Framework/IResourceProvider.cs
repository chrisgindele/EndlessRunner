using System.IO;

namespace Framework
{
	public interface IResourceProvider
	{
		bool Exists(string name);
		Stream Open(string name);
	}
}