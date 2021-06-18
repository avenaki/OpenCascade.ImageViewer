namespace OpenCascade.ImageViewer.Controllers.Abstract
{
    public interface IControl<TModel, TView>
    {
        void SetModel(TModel model);
        void SetView(TView view);
    }
}
