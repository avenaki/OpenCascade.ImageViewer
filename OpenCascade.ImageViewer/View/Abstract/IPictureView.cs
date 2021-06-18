using OpenCascade.ImageViewer.Models.Abstract;

namespace OpenCascade.ImageViewer.View.Abstract
{
    public interface IPictureView
    {
        void Update(IPictureModel paramModel);

        void showPicture(IPictureModel model);

    }

}
