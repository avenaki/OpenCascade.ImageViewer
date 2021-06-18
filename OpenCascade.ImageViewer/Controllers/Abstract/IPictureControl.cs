using OpenCascade.ImageViewer.Models.Abstract;
using OpenCascade.ImageViewer.View.Abstract;

namespace OpenCascade.ImageViewer.Controllers
{
    public interface IPictureControl
    {
        void RequestLoadPicture(string path);
        void SetModel(IPictureModel model);
        void SetView(IPictureView view);
    }
}
