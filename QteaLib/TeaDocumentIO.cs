using System.IO;
using Newtonsoft.Json;

namespace QteaLib
{
  /// <summary>
  ///   Copyright (c) Aaron Colwill 2016
  /// </summary>

  public class TeaDocumentIO
  {
    public void WriteToFile(TeaDocument file)
    {
      var serialized = JsonConvert.SerializeObject(file.Meta);
      using (var w = new StreamWriter(file.Meta.Path))
      {
        w.WriteLine(serialized);    // Meta
        w.WriteLine("[\\]");        // Meta Object Markers
        w.Write(file.Data);         // File Data
      }
    }

    public TeaDocument OpenFromFile(TeaDocument file)
    {
      using (var r = new StreamReader(file.Meta.Path))
      {
        file.Data += r.ReadToEnd();
      }
      return file;
    }
  }
}