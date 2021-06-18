using OpenCascade.ImageViewer.View.Abstract;
using System.Drawing;

namespace OpenCascade.ImageViewer.Models.Abstract
{
    public interface IPictureModel: IModel<IPictureView>
    {
        public Image Image { get; set; }

        void LoadPicture(string path);

    }
}
