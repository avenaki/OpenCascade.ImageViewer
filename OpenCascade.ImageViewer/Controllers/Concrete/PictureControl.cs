using OpenCascade.ImageViewer.Models.Abstract;
using OpenCascade.ImageViewer.View.Abstract;

namespace OpenCascade.ImageViewer.Controllers.Concrete
{
    public class PictureControl : IPictureControl
    {
        private IPictureModel Model { get; set; }
        private IPictureView View { get; set; }

        public void RequestLoadPicture(string path)
        {
            Model.LoadPicture(path);
        }

        public void SetModel(IPictureModel model)
        {
            Model = model;
        }

        public void SetView(IPictureView view)
        {
            View = view;
        }

        private void SetView()
        {
            if (Model.Image != null)
            {
                View.showPicture(Model);
            }
        }
    }
}
