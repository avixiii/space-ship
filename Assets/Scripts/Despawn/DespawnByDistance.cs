using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCam;

    protected override void LoadComponents()
    {
        LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (mainCam != null) return;
        mainCam = FindObjectOfType<Camera>().transform;
        Debug.Log(transform.parent.name + ": LoadCamera", gameObject);
    }

    protected override bool CanDespawn()
    {
        distance = Vector3.Distance(transform.position, mainCam.position);
        if (distance > disLimit) return true;
        return false;
    }
}
