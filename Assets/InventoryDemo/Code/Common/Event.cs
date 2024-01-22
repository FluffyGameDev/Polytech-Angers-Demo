using System;
using UnityEngine;

namespace PolytechAngers.Inventory
{
    [CreateAssetMenu(menuName = "Polytech Angers/Common/Event")]
    public class Event : ScriptableObject
    {
        public event Action OnEventTriggered;

        public void TriggerEvent()
        {
            OnEventTriggered?.Invoke();
        }
    }

    public class Event<T> : ScriptableObject
    {
        public event Action<T> OnEventTriggered;

        public void TriggerEvent(T arg)
        {
            OnEventTriggered?.Invoke(arg);
        }
    }

    public class Event<T1, T2> : ScriptableObject
    {
        public event Action<T1, T2> OnEventTriggered;

        public void TriggerEvent(T1 arg1, T2 arg2)
        {
            OnEventTriggered?.Invoke(arg1, arg2);
        }
    }
}
