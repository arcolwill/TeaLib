using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace QteaLib
{
    /// <summary>
    ///   Copyright (c) Aaron Colwill 2016
    /// </summary>
    public class TeaDocumentIO
    {
        /// <summary>
        ///     Check for directory
        ///     Check for File
        ///     Create file & dir with FileStream
        /// </summary>
        /// <param name="file">File (callee)</param>
        /// <returns>true without failure</returns>
        public bool CreateFile(TeaDocument file)
        {
            if (!Directory.Exists(file.Meta.Path)) Directory.CreateDirectory(file.Meta.Path);
            if (File.Exists(file.Meta.Path + file.Meta.Name + file.Meta.FileExtension)) return false;
            var serialized = JsonConvert.SerializeObject(file.Meta);

            using (var _f = new FileStream(file.Meta.Path + file.Meta.Name + file.Meta.FileExtension, FileMode.CreateNew))
            {
                // Create meta
                using (var _m = new FileStream(file.Meta.Path + file.Meta.Name + ".tmeta", FileMode.CreateNew))
                {
                    var serialMeta = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(file.Meta).ToString());
                    _m.Write(serialMeta, 0, serialMeta.Length);
                    _m.Flush();
                    _m.Close();
                }

                // Create source
                var text = new UTF8Encoding(true).GetBytes(file.Data);
                _f.Write(text, 0, text.Length);
                _f.Flush();
                _f.Close();
            }
            return true;
        }

        /// <summary>
        ///     Write a file
        /// </summary>
        /// <param name="file">file to write</param>
        public bool SaveToFile(TeaDocument file)
        {
            if (file.Meta.Path == string.Empty) return false;
            if (!Directory.Exists(file.Meta.Path)) Directory.CreateDirectory(file.Meta.Path);
            if (!File.Exists(file.Meta.Path + file.Meta.Name + file.Meta.FileExtension)) return false;
            using (var w = new StreamWriter(file.Meta.Path + file.Meta.Name + file.Meta.FileExtension))
            {
                // Save file
                w.Write(file.Data);
            }
            return true;
        }

        /// <summary>
        ///     Open a file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public TeaDocument OpenFromFile(TeaDocument file)
        {
            using (var f = new StreamReader(file.Meta.Path + file.Meta.Name + file.Meta.FileExtension))
            {
                // Load meta
                using (var m = new StreamReader(file.Meta.Path + file.Meta.Name + ".tmeta"))
                {
                    file.Meta = JsonConvert.DeserializeObject<TeaDocumentMeta>(m.ReadToEnd());
                }
                // Load file
                file.Data += f.ReadToEnd();
            }
            return file;
        }

        /// <summary>
        ///     Open a file from path
        /// </summary>
        /// <param name="path">the directory and file name (not extension)</param>
        /// <returns></returns>
        public TeaDocument OpenFromPath(string path)
        {
            var file = new TeaDocument(""); // object for our newly opened file

            // Load meta
            using (var m = new StreamReader(path + ".tmeta"))
                file.Meta = JsonConvert.DeserializeObject<TeaDocumentMeta>(m.ReadToEnd());

            // Load file
            using (var f = new StreamReader(file.Meta.Path + file.Meta.Name + file.Meta.FileExtension))
                file.Data += f.ReadToEnd();
            
            return file;
        }
    }
}