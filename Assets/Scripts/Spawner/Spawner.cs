using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;

    protected void Reset()
    {
        LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        LoadPrefabs();
    }


    protected virtual void LoadPrefabs()
    {
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            prefabs.Add(prefab);
        }
        
        HidePrefabs();
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
        {
            
        }
    }
}