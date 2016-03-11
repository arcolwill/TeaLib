using System.Reflection;

namespace QteaLib
{
  public interface ITeaPlugin
  {
    string Author { get; set; }
    string Name { get; set; }
    string Path { get; set; }
    string Dependency { get; set; }
    string Main { get; set; }
  }
}
