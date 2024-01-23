using System.Collections.Generic;
using UnityEngine;

namespace PolytechAngers.Interaction
{
    public abstract class Interactable : MonoBehaviour
    {
        public abstract bool CanInteract();
        public abstract void Interact();

        private void OnTriggerEnter(Collider other)
        {
            InteractionInstigator instigator = other.GetComponent<InteractionInstigator>();
            if (instigator != null)
            {
                instigator.RegisterInteractable(this);
                m_NearbyInstigators.Add(instigator);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            InteractionInstigator instigator = other.GetComponent<InteractionInstigator>();
            if (instigator != null)
            {
                instigator.UnregisterInteractable(this);
                m_NearbyInstigators.Remove(instigator);
            }
        }

        private void OnDestroy()
        {
            foreach (InteractionInstigator instigator in m_NearbyInstigators)
            {
                instigator.UnregisterInteractable(this);
            }
            m_NearbyInstigators.Clear();
        }

        private List<InteractionInstigator> m_NearbyInstigators = new();
    }
}
