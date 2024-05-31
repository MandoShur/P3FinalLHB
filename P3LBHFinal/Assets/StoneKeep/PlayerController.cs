using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool canMove = true;

    void Update()
    {
        if (canMove)
        {
            float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

            transform.Translate(new Vector3(moveX, 0, moveZ));
        }
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }
}
