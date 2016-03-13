using System.Collections.Generic;

namespace QteaLib
{
    /// <summary>
    ///   Copyright (c) Aaron Colwill 2016
    /// </summary>

    public class TeaDocumentManager
    {
        // Open documents loaded into the IDE
        private readonly List<TeaDocument> _documents = new List<TeaDocument>();
        private readonly TeaDocumentIO _io = new TeaDocumentIO();
        public TeaDocument ActiveDocument { get; private set; }

        public TeaDocumentManager()
        {
            ActiveDocument = null;
        }

        public TeaDocumentManager(TeaDocument defaultDocument)
        {
            _documents.Add(defaultDocument);
            ActiveDocument = _documents[0];
        }

        public TeaDocumentManager(string defaultDocumentPath)
        {
            _documents.Add(_io.OpenFromPath(defaultDocumentPath));
            ActiveDocument = _documents[0];
        }

        public void OpenDocument(TeaDocument document)
        {
            var file = _io.OpenFromFile(document);
            if (file != null) _documents.Add(file);
        }

        public bool SaveDocument(TeaDocument document)
        {
            return _io.SaveToFile(document);
        }

        public void CloseDocument(int index)
        {
            // close file read (if open) and close in IDE
        }
    }
}