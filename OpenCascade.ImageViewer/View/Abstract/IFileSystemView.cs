using OpenCascade.ImageViewer.Models.Abstract;

namespace OpenCascade.ImageViewer.View.Abstract
{
    public interface IFileSystemView: IView<IFileSystemModel>
    {
        void showTreeFolder(IFileSystemModel model);
    }

}
