using OpenCascade.ImageViewer.Models;
using System.Collections.Generic;

namespace OpenCascade.ImageViewer
{
    public enum EntryType
    {
        File,
        Directory
    }

    public class FileSystemEntry : ITreeNodeValue
    {
        public EntryType Type { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        //there is a bug when Type==dir
        public string FullPath => Path + "\\" + Name;// use path.combine 

        public string NodeName => Name;
    }

    class FileSystemEntryNode : FileSystemEntry
    {
        public IReadOnlyCollection<FileSystemEntryNode> Childs { get; set; }
    }
}
