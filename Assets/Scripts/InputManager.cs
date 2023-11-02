using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;

    public static InputManager Instance => _instance; 

    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos => mouseWorldPos;

    [SerializeField] protected float onFiring;

    public float OnFiring => onFiring;

    private void Awake()
    {
        if (InputManager._instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager._instance = this;
    }

    private void Update()
    {
        GetMouseDown();
    }

    private void FixedUpdate()
    {
        GetMousePos();
    }

    protected virtual void GetMouseDown()
    {
        onFiring = Input.GetAxis("Fire1");
    }

    protected virtual void GetMousePos()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
        }
    }

}