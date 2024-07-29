namespace CodeJay.MVC
{
    using UnityEngine;

    public class ControllerBase : MonoBehaviour, IController
    {
        protected IModel model;
        protected IView view;

        public virtual void SetModel(IModel model)
        {
            if (this.model != null)
                model.OnModelChanged -= OnModelChanged;

            this.model = model;
            this.model.OnModelChanged += OnModelChanged;
        }

        public virtual void SetView(IView view)
        {
            this.view = view;
        }

        protected virtual void OnModelChanged()
        {
            view.UpdateView();
        }
    }
}