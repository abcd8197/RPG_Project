namespace CodeJay.MVC
{
    public class ModelBaseCodeJay : IModel
    {
        public event System.Action OnModelChanged;
        protected MVCProperty m_Property;

        public virtual void NotifyModelChanged()
        {
            OnModelChanged?.Invoke();
        }
    }
}