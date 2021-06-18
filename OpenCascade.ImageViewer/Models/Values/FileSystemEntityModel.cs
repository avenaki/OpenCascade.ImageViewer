using OpenCascade.ImageViewer.Models.Abstract;
using System.Collections.Generic;

namespace OpenCascade.ImageViewer.Models.Values
{
    public enum EntryType
    {
        File,
        Directory
    }

    public class FileSystemEntityModel : ITreeNodeValue
    {
        public EntryType Type { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        //there is a bug when Type==dir
        public string FullPath => Path + "\\" + Name;// use path.combine 

        public string NodeName => Name;
    }

    public class FileSystemEntryNode : FileSystemEntityModel
    {
        public IReadOnlyCollection<FileSystemEntryNode> Childs { get; set; }
    }
}
