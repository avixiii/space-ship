using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;

    [SerializeField] protected float speed = 0.1f;

    private Transform _parentTransform;

    private void Start()
    {
        _parentTransform = transform.parent;
    }

    private void FixedUpdate()
    {
        GetTargetPosition();
        LookAtTarget();
        Moving();
    }

    protected virtual void LookAtTarget()
    {
        Vector3 diff = targetPosition - transform.parent.position;
        diff.Normalize();
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        _parentTransform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }

    protected virtual void GetTargetPosition()
    {
        targetPosition = InputManager.Instance.MouseWorldPos;
        targetPosition.z = 0;
    }

    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, speed);
        _parentTransform.position = newPos;
    }
}