using System;
using System.Runtime.Serialization;

namespace QteaLib
{
  /// <summary>
  ///   Copyright (c) Aaron Colwill 2016
  /// </summary>

  [DataContract]
  public class TeaDocumentMeta
  {
    [DataMember] public string Name { get; set; }
    [DataMember] public string Path { get; set; }
    [DataMember] public string FileType { get; set; }
    [DataMember] public string FileExtension { get; set; }
  }

  public class TeaDocument
  {
    public TeaDocumentMeta  Meta { get; set; }
    public string           Data { get; set; }

    private readonly TeaDocumentIO _io = new TeaDocumentIO();

    public TeaDocument(string _name)
    {
        Meta = new TeaDocumentMeta();
        Meta.Name            = _name;
        Meta.Path            = "";
        Meta.FileType        = "";
        Meta.FileExtension   = "";
    }

    public TeaDocument(string _name, string _path, string _fileType, string _fileExtension)
    {
        Meta = new TeaDocumentMeta();
        Meta.Name            = _name;
        Meta.Path            = _path;
        Meta.FileType        = _fileType;
        Meta.FileExtension   = _fileExtension;
    }

    private bool Save()
    {
      try
      {
        _io.WriteToFile(this);
      }
      catch (Exception e)
      {
        return false;
      }
      return true;
    }
  }
}


