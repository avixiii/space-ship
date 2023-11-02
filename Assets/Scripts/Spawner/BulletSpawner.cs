using UnityEngine;

public enum PrefabType
{
    Bullet_1,
    // Add more prefab names as needed
}


public class BulletSpawner : Spawner
{
    private static BulletSpawner _instance;
    public static BulletSpawner Instance => _instance;
    
    public static string bulletOne = "Bullet_1";

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner._instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        BulletSpawner._instance = this;
    }
    
}
