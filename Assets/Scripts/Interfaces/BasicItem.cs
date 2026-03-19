using UnityEngine;

public class BasicItem : MonoBehaviour, IInteractable
{
    [SerializeField] private string itemName;

    public bool CanInteractWith(GameObject interactor)
    {
        return true;
    }

    public void Interact(GameObject interactor)
    {
        if (interactor.TryGetComponent<BasicInventory>(out var inventory))
        {
            inventory.AddItem(itemName);
            Destroy(gameObject);
        }
    }
}
