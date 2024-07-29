namespace CodeJay.MVC
{
    public interface IController
    {
        void SetModel(IModel model);
        void SetView(IView view);
    }
}