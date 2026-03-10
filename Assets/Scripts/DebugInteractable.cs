using UnityEngine;

public class DebugInteractable : MonoBehaviour, IInteractable
{
    public bool CanInteractWith(GameObject interactor)
    {
        return true; //player always can interact with an object
    }

    public void Interact(GameObject interactor)
    {
        Destroy(gameObject); //object will be destroyed when player interacts with it

        Debug.Log($"Interacted with {gameObject.name} by {interactor.name}");
    }
}
