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
            instigator?.RegisterInteractable(this);
        }

        private void OnTriggerExit(Collider other)
        {
            InteractionInstigator instigator = other.GetComponent<InteractionInstigator>();
            instigator?.UnregisterInteractable(this);
        }
    }
}
