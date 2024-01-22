using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PolytechAngers.Interaction
{
    public class InteractionInstigator : MonoBehaviour
    {
        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed && m_NearestInteractable != null && m_NearestInteractable.CanInteract())
            {
                m_NearestInteractable.Interact();
            }
        }

        public void RegisterInteractable(Interactable interactable)
        {
            m_NearbyInteractables.Add(interactable);
            RefreshNearestInteractable();
        }

        public void UnregisterInteractable(Interactable interactable)
        {
            m_NearbyInteractables.Remove(interactable);
            RefreshNearestInteractable();
        }

        private void RefreshNearestInteractable()
        {
            Interactable previousNearest = m_NearestInteractable;
            m_NearestInteractable = null;
            float bestSqrDistance = float.PositiveInfinity;
            foreach (Interactable interactable in m_NearbyInteractables)
            {
                float sqrDistance = (transform.position - interactable.transform.position).sqrMagnitude;
                if (sqrDistance < bestSqrDistance)
                {
                    bestSqrDistance = sqrDistance;
                    m_NearestInteractable = interactable;
                }
            }

            if (m_NearestInteractable != previousNearest)
            {
                //TODO: trigger event
            }
        }

        private List<Interactable> m_NearbyInteractables = new();
        private Interactable m_NearestInteractable;
    }
}
