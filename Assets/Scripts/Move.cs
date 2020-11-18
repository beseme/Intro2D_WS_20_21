using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed = 0;
    public float JumpHeight = 0; //Für das Platformer Beispiel

    private Rigidbody2D _physics = null;

    private void Start()
    {
        _physics = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 move = Vector3.zero;      

        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        _physics.velocity = move * Speed;

        // Für Platformer zb.

        /*if (Input.GetButtonDown("Jump"))
        {
            _physics.AddForce(Vector2.up * JumpHeight);
        }

        _physics.velocity = new Vector2(move.x * Speed, _physics.velocity.y);*/
    }
}
