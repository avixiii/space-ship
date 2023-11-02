using System;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected Transform bulletPrefab;
    
    private Transform _parentTransform;

    private void Start()
    {
        _parentTransform = transform.parent;
    }
    
    private void Update()
    {
        IsShooting();
        
    }

    private void FixedUpdate()
    {
        Shooting();
    }

    protected virtual void Shooting()
    {
        shootTimer += Time.fixedDeltaTime;

        if (!isShooting) return;
        if (shootTimer < shootDelay) return;
        shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = _parentTransform.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(PrefabType.Bullet_1, spawnPos, rotation);
        if (newBullet == null) return;

        newBullet.gameObject.SetActive(true);
    }

    protected virtual bool IsShooting()
    {
        float epsilon = 0.0001f;
        isShooting = Math.Abs(InputManager.Instance.OnFiring - 1.0f) < epsilon;
        return isShooting;
    }

}
