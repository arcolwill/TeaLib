using System.Collections.Generic;

namespace QteaLib
{
  /// <summary>
  ///   Copyright (c) Aaron Colwill 2016
  /// </summary>

  public class TeaDocumentManager
  {
    // Open documents loaded into the IDE
    private readonly List<TeaDocument>      _documents  = new List<TeaDocument>();
    private readonly TeaDocumentIO          _io         = new TeaDocumentIO();
    private TeaDocument                     ActiveDocument { get; set; }

    public TeaDocumentManager(TeaDocument defaultDocument)
    {
      _documents.Add(defaultDocument);
      ActiveDocument = _documents[0];
    }

    public void OpenDocument(TeaDocument document)
    {
      var file = _io.OpenFromFile(document);
      if(file != null) _documents.Add(file);
    }

    public void SaveDocument(TeaDocument document)
    {
      _io.WriteToFile(document);
      _documents.Remove(document);
    }

    public void CloseDocument(int index)
    {
      // close file read (if open) and close in IDE
    }
  }
}