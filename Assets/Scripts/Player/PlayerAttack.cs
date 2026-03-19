using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public float WeaponDistance = 3;
    public float WeaponDamage = 25;

    public Transform CameraTransform;
    public LayerMask DamageableLayers;
    public RaycastHit raycastHit;

    private void OnEnable()
    {
    }
    private void OnDisable()
    {
        
    }
    public void OnAttack(InputAction.CallbackContext obj)
    {

    }
    private void CastRay()
    {
        if (Physics.Raycast(
            CameraTransform.position,
            CameraTransform.forward,
            out raycastHit,
            WeaponDistance,
            DamageableLayers))
        {
            if (raycastHit.collider.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                if (damageable.IsAlive)
                    damageable.ApplyDamage(WeaponDamage);
            }

        }
    }
}
