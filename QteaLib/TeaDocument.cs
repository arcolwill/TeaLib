using System;
using Newtonsoft.Json;

namespace QteaLib
{
    /// <summary>
    ///   Copyright (c) Aaron Colwill 2016
    /// </summary>

    [JsonObject]
    public class TeaDocumentMeta
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Path")]
        public string Path { get; set; }
        [JsonProperty("FileType")]
        public string FileType { get; set; }
        [JsonProperty("FileExtension")]
        public string FileExtension { get; set; }
    }

    public class TeaDocument
    {
        public TeaDocumentMeta Meta { get; set; }
        public string Data { get; set; }

        private readonly TeaDocumentIO _io = new TeaDocumentIO();

        public TeaDocument(string _name)
        {
            Meta                = new TeaDocumentMeta();
            Meta.Name           = _name;
            Meta.Path           = "";
            Meta.FileType       = "";
            Meta.FileExtension  = "";
        }

        public TeaDocument(string _name, string _path, string _fileType, string _fileExtension, string _data, bool _create)
        {
            Meta                = new TeaDocumentMeta();
            Meta.Name           = _name;
            Meta.Path           = _path;
            Meta.FileType       = _fileType;
            Meta.FileExtension  = _fileExtension;
            Data                = _data;
            if (_create) _io.CreateFile(this);
        }

        private bool Save()
        {
            try
            {
                _io.SaveToFile(this);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}


