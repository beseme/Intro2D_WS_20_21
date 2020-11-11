using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed = 0;

    private void FixedUpdate()
    {
        Vector3 move = Vector3.zero;

        // ---------- option 1 (bitte nicht so)

        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            move += Vector3.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            move += Vector3.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move += Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move += Vector3.right;
        }*/

        // ---------- option 2 (so is besser)

        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        transform.position += move * Speed * .01f;
    }
}
