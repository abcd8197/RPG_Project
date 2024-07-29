namespace CodeJay.MVC
{
    using UnityEngine;

    public abstract class ViewBase : MonoBehaviour, IView
    {
        public abstract void UpdateView();
    }
}