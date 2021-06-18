using OpenCascade.ImageViewer.Controllers.Abstract;
using OpenCascade.ImageViewer.Models.Abstract;
using OpenCascade.ImageViewer.View.Abstract;

namespace OpenCascade.ImageViewer.Controllers
{
    public interface IFileSystemControl: IControl<IFileSystemModel, IFileSystemView>
    {
        void RequestBuildTree(string path);
    }

}
