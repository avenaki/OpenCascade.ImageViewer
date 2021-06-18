using OpenCascade.ImageViewer.Controllers.Abstract;
using OpenCascade.ImageViewer.Models.Abstract;
using OpenCascade.ImageViewer.View.Abstract;

namespace OpenCascade.ImageViewer.Controllers
{
    public interface IPictureControl: IControl<IPictureModel, IPictureView>
    {
        void RequestLoadPicture(string path);
    }
}
