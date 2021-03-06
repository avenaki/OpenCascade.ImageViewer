using OpenCascade.ImageViewer.Models.Values;
using OpenCascade.ImageViewer.View.Abstract;

namespace OpenCascade.ImageViewer.Models.Abstract
{
    public interface IFileSystemModel: IModel<IFileSystemView>
    {
        public FileSystemEntryNode RootNode { get; set; }
        public void BuildTree(string path);

    }

   
}
