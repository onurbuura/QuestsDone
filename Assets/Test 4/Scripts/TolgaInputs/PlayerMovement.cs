using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public void MoveCharacterToPosition(float _position)
    {
        Vector3 movePos = new Vector3(_position,transform.position.y,transform.position.z);
        Vector3 lerpedPos = Vector3.Lerp(transform.position,movePos,Time.fixedDeltaTime*movementSpeed);
        transform.position = lerpedPos;
    }
}
