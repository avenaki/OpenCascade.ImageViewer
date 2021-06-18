using OpenCascade.ImageViewer.Models.Abstract;
using OpenCascade.ImageViewer.Models.Values;
using OpenCascade.ImageViewer.View.Abstract;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenCascade.ImageViewer.Models.Concrete
{
    public class FileSystemModel : IFileSystemModel
    {
        private ArrayList _observersList = new ArrayList();
        public FileSystemEntryNode RootNode { get; set; }

        public void AddObserver(IFileSystemView paramView)
        {
            _observersList.Add(paramView);
        }

        public void BuildTree(string path)
        {
            RootNode = BuildTreeWithRoot(path, true);
        }

        private FileSystemEntryNode BuildTreeWithRoot(string path, bool isDir)
        {
            var directoryInfo = new DirectoryInfo(path);
            var dirs = directoryInfo.EnumerateDirectories();
            var files = directoryInfo.EnumerateFiles();
            var childs = new List<FileSystemEntryNode>();

            childs.AddRange(files.Select(f => new FileSystemEntryNode()
            {
                Childs = null,
                Name = f.Name,
                Path = f.Directory.FullName,
                Type = EntryType.File
            }));

            childs.AddRange(dirs.Select(d => BuildTreeWithRoot(d.FullName, true)).AsEnumerable());

            var entry = new FileSystemEntryNode
            {
                Name = directoryInfo.Name,
                Path = path,
                Type = isDir ? EntryType.Directory : EntryType.File,
                Childs = childs
            };

            return entry;
        }

        public void NotifyObservers()
        {
            foreach (IFileSystemView view in _observersList)
            {
                view.Update(this);
            }
        }

        public void RemoveObserver(IFileSystemView paramView)
        {
            _observersList.Remove(paramView);
        }
    }
}
