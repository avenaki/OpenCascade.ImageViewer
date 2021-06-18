using OpenCascade.ImageViewer.Models.Abstract;

namespace OpenCascade.ImageViewer.View.Abstract
{
    public interface IView<TModel> 
    {
        void Update(TModel model);
    }
}
