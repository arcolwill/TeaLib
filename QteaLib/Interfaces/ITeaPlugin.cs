using System.Reflection;

namespace QteaLib
{
  public interface ITeaPlugin
  {
    string Author { get; }
    string Name { get; }
    string Path { get; }
    string Dependency { get; }
    string Main { get; }
  }
}
