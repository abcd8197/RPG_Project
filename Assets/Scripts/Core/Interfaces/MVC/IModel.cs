namespace CodeJay.MVC
{
    public interface IModel
    {
        event System.Action OnModelChanged;
        void NotifyModelChanged();
    }
}