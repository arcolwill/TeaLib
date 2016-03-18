using System.Collections.Generic;
using System.IO;

namespace QteaLib
{
    /// <summary>
    ///   Copyright (c) Aaron Colwill 2016
    /// </summary>

    public class TeaDocumentManager
    {
        public static TeaDocumentManager _instance;
        public static TeaDocumentManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new TeaDocumentManager();
                }
                return _instance;
            }
        }

        // Open documents loaded into the IDE
        private readonly List<TeaDocument> _documents = new List<TeaDocument>();
        private readonly TeaDocumentIO _io = new TeaDocumentIO();
        public TeaDocument ActiveDocument { get; private set; }

        public TeaDocumentManager()
        {
            ActiveDocument = null;
            var document = new TeaDocument("test", Directory.GetCurrentDirectory() + "\\testdocs\\", "Tea File", ".t", QteaLib.Templates.QmlMainTemplate, true);
            _documents.Add(_io.OpenFromFile(document));
            ActiveDocument = _documents[0];
        }

        public TeaDocumentManager(TeaDocument defaultDocument)
        {
            if (defaultDocument == null) return;
            _documents.Add(defaultDocument);
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