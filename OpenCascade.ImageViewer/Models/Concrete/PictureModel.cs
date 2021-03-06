using OpenCascade.ImageViewer.Models.Abstract;
using OpenCascade.ImageViewer.View.Abstract;
using System.Collections;
using System.Drawing;

namespace OpenCascade.ImageViewer.Models.Concrete
{
    public class PictureModel: IPictureModel
    {
        private ArrayList _observersList = new ArrayList();
        public Image Image { get; set; }

        public void AddObserver(IPictureView paramView)
        {
            foreach (IPictureView view in _observersList)
            {
                view.Update(this);
            }
        }

        public void LoadPicture(string path)
        {
           Image = Image.FromFile(path);
        }

        public void NotifyObservers()
        {
            foreach (IPictureView view in _observersList)
            {
                view.Update(this);
            }
        }

        public void RemoveObserver(IPictureView paramView)
        {
             _observersList.Remove(paramView);
        }
    }
}
