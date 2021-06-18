using OpenCascade.ImageViewer.Models.Abstract;

namespace OpenCascade.ImageViewer.View.Abstract
{
    public interface IFileSystemView
    {
        void Update(IFileSystemModel paramModel);
        void showTreeFolder(IFileSystemModel model);
    }

}
