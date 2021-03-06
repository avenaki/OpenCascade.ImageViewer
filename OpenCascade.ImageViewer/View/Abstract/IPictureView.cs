using OpenCascade.ImageViewer.Models.Abstract;

namespace OpenCascade.ImageViewer.View.Abstract
{
    public interface IPictureView: IView<IPictureModel>
    {
        void showPicture(IPictureModel model);

    }

}
