using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    public Transform[] bounds = new Transform[2];
    private PlayerMovement movement;
    public float sensitivity;
    private Vector2 inputStartPosition;
    private float currentX;
    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            inputStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 deltaPos = (Vector2)Input.mousePosition - inputStartPosition;
            
            inputStartPosition = Input.mousePosition;
            
            currentX += deltaPos.x / (Screen.width / sensitivity);
        }
        
        currentX = Mathf.Clamp(currentX,bounds[0].position.x,bounds[1].position.x);
        
        movement.MoveCharacterToPosition(currentX);
    }
}
