using OpenCascade.ImageViewer.Models.Abstract;
using OpenCascade.ImageViewer.View.Abstract;

namespace OpenCascade.ImageViewer.Controllers.Concrete
{
    public class FileSystemControl : IFileSystemControl
    {
        private IFileSystemModel Model;
        private IFileSystemView View;

        public void RequestBuildTree(string path)
        {
            if (Model != null)
            {
                Model.BuildTree(path);
                if (View != null)
                {
                    SetView();
                }
            }
        }

        public void SetModel(IFileSystemModel model)
        {
            Model = model;
        }

        public void SetView(IFileSystemView view)
        {
            View = view;
        }

        private void SetView()
        {
            if (Model.RootNode != null)
            {
                View.showTreeFolder(Model);
            }

        }
    }
}
