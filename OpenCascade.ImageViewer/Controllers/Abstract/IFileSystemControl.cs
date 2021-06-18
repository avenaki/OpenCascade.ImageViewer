using OpenCascade.ImageViewer.Models.Abstract;
using OpenCascade.ImageViewer.View.Abstract;

namespace OpenCascade.ImageViewer.Controllers
{
    public interface IFileSystemControl
    {
        void RequestBuildTree(string path);
        void SetModel(IFileSystemModel model);
        void SetView(IFileSystemView view);
    }

}
