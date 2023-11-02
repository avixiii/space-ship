using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] protected int moveSpeed = 1;
    [SerializeField] protected Vector3 direction = Vector3.right;

    private void Update()
    {
        transform.parent.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
