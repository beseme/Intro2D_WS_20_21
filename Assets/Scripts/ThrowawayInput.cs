using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowawayInput : MonoBehaviour
{
    private PlayerMovement _player = null;

    private void Awake()
    {
        this._player = this.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            this._player.AddJump();

        if (Input.GetButtonDown("Fire1"))
            Debug.Log("found");
    }

    private void FixedUpdate()
    {
        this._player.Direction = Input.GetAxis("Horizontal");
    }
}
