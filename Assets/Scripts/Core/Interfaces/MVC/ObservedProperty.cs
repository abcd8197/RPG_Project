namespace CodeJay.Classes
{

    [System.Serializable]
    public class ObservedProperty<T> : System.IDisposable
    {
        public System.Action OnChangedValue;

        public ObservedProperty(T data)
        {
            Value = data;
        }

        public T Value
        {
            get
            {
                return Value;
            }
            set
            {
                if (!Value.Equals(value))
                {
                    Value = value;
                    OnChangedValue?.Invoke();
                }
            }
        }

        public void Dispose()
        {
            OnChangedValue = null;
        }
    }
}