namespace OpenCascade.ImageViewer.Models.Abstract
{
    public interface IModel<TView> 
    {
        void AddObserver(TView paramView);
        void RemoveObserver(TView paramView);
        void NotifyObservers();
    }
}
