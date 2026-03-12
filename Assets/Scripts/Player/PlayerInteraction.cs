using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] //ensures it shows up in the editor in unity
    private Transform CameraTransform; //ray comes from here

    [SerializeField]
    private float InteractionDistance = 5; //how long the ray will be 

    [SerializeField]
    private LayerMask InteractionLayers; //what layers are you going to raycast to? (environment and Interactables)

    private RaycastHit raycastHit;

    private IInteractable currentInteractable;
    private IFocusable currentFocusable;


    private void OnEnable()
    {
        InputManager.Actions.Game.Interact.performed += OnInteract;
    }

    private void Disable()
    {
        InputManager.Actions.Game.Interact.performed -= OnInteract;
        ClearFocus();
    }

    private void OnInteract(InputAction.CallbackContext obj)
    {
        if (currentInteractable != null) 
            if (currentInteractable.CanInteractWith(gameObject))
                currentInteractable.Interact(gameObject);
    }

    private void ClearFocus()
    {
        if (currentFocusable != null && (currentFocusable as Object) != null)
            currentFocusable.Unfocus(gameObject);

        currentFocusable = null;
        currentInteractable = null;
    }

    private void Update()
    {
        CastRay();
    }

    private void CastRay()
    {
        if(Physics.Raycast(
            CameraTransform.position, 
            CameraTransform.forward, 
            out raycastHit, 
            InteractionDistance, 
            InteractionLayers))
        {
            raycastHit.collider.gameObject.TryGetComponent<IInteractable>(out currentInteractable);
            raycastHit.collider.gameObject.TryGetComponent<IFocusable>(out IFocusable newFocusable);

            if (newFocusable != currentFocusable)
            {
                ClearFocus();

                currentFocusable = newFocusable;

                if (currentFocusable != null)
                    currentFocusable.Focus(gameObject);
            }
        }
        else
        {
            ClearFocus();
        }
    }

}
