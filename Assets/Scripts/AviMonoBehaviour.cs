using UnityEngine;

public class AviMonoBehaviour : MonoBehaviour
{
        protected virtual void Reset()
        {
                LoadComponents();
        }

        protected virtual void Start()
        {
                //For override
        }
        
        protected virtual void Awake()
        {
                LoadComponents();
        }

        protected virtual void LoadComponents()
        {
                
        }
}