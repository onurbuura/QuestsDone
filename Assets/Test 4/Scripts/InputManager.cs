using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputManager Instance;

    [HideInInspector] public bool isTouching;

    [HideInInspector] public Vector2 deltaDir;

    Vector2 initialDir;
    Vector2 oldDir;


    void Awake()
    {
        //Instance = this; // Singleton eksik

        if (Instance != null) Instance =this;
        else Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isTouching = true;
            initialDir = Input.mousePosition;
            oldDir = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            deltaDir = new Vector3(Input.mousePosition.x - oldDir.x, Input.mousePosition.y - oldDir.y);
            oldDir = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isTouching = false;
            oldDir = Vector3.zero;
        }
    }
}
