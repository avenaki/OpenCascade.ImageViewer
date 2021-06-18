using OpenCascade.ImageViewer.Models.Values;
using OpenCascade.ImageViewer.View.Abstract;

namespace OpenCascade.ImageViewer.Models.Abstract
{
    public interface IFileSystemModel
    {
        public FileSystemEntryNode RootNode { get; set; }
        public void BuildTree(string path);

        void AddObserver(IFileSystemView paramView);
        void RemoveObserver(IFileSystemView paramView);
        void NotifyObservers();
    }

   
}
