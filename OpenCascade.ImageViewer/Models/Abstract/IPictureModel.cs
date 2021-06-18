using OpenCascade.ImageViewer.View.Abstract;
using System.Drawing;

namespace OpenCascade.ImageViewer.Models.Abstract
{
    public interface IPictureModel
    {
        public Image Image { get; set; }

        void LoadPicture(string path);
        void AddObserver(IPictureView paramView);
        void RemoveObserver(IPictureView paramView);
        void NotifyObservers();
    }
}
