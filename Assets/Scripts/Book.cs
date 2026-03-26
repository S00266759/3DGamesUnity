using UnityEngine;

public class Book : MonoBehaviour, IInteractable
{
    [SerializeField] private BookData BookData;

    public bool CanInteractWith(GameObject interactor)
    {
        return true;
    }

    public void Interact(GameObject Interactor)
    {
        for (int i = 0; i < BookData.Pages.Count; i++)
        {
            Debug.Log($"Page {i} : {BookData.Pages[i]}");
        }
    }
    
}
