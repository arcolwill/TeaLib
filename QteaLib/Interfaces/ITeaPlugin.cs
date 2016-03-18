using System;

namespace QteaLib
{
    public interface ITeaPlugin
    {
        bool    Active      { get; }
        string  Author      { get; }
        string  Name        { get; }
        string  Path        { get; }
        string  Dependency  { get; }
        void    Run();
    }
}
