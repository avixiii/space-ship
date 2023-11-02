using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : AviMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;

    protected override void LoadComponents()
    {
        LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if (prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            prefabs.Add(prefab);
        }

        HidePrefabs();

        Debug.Log(transform.name + " LoadPrefabs ", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(PrefabType prefabType, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = GetPrefabByType(prefabType);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab not found: " + prefabType.ToString());
            return null;
        }

        Transform newPrefab = Instantiate(prefab, spawnPos, rotation);
        return newPrefab;
    }


    public virtual Transform GetPrefabByType(PrefabType prefabType)
    {
        foreach (Transform prefab in prefabs)
        {
            if (prefab.name == prefabType.ToString()) return prefab;
        }

        return null;
    }
}