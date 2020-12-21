using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum Playerstates
    {
        grounded,
        airborne
    }

    [Header("Horizontal Speed")]
    public float MaxHorizontalSpeed = 0;

    public float RunningAcceleration = 0;
    public float RunningDeceleration = 0;

    public float AirAcceleration = 0;
    public float AirDeceleration = 0;

    public float DashForce = 0;

    [Header("VerticalSpeed")]
    public float JumpHeight = 0;

    private Rigidbody2D _physics = null;
    private BoxCollider2D _collision = null;
    private float _currentSpeed = 0;
    private float _direction = 0;
    public float Direction { get => this._direction; set => this._direction = value; }
    private Playerstates _currentState = Playerstates.grounded;

    private void Awake()
    {
        this._physics = this.GetComponent<Rigidbody2D>();
        this._collision = this.GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        this._collisionChecks();

        this._currentSpeed = this._physics.velocity.x;

        switch (this._currentState)
        {
            case Playerstates.grounded:
                this._updateGrounded();
                break;
            case Playerstates.airborne:
                this._updateAirborne();
                break;
        }

        this._physics.velocity = new Vector2(this._currentSpeed, this._physics.velocity.y);
    }

    private void _collisionChecks()
    {
        var check = Physics2D.BoxCast(this._collision.bounds.min + (Vector3.right * this._collision.size.x / 2),
            new Vector2(this._collision.size.x, .1f),
            0, Vector2.zero,
            LayerMask.GetMask("ground"));

        if (check)
            this._currentState = Playerstates.grounded;
        else
            this._currentState = Playerstates.airborne;
    }

    private void _updateGrounded()
    {
        if(this._physics.velocity.x > this.MaxHorizontalSpeed)
        {
            Mathf.MoveTowards(this._currentSpeed, this.MaxHorizontalSpeed * this._direction, -this.RunningDeceleration);
        }
        else
        {
            Mathf.MoveTowards(this._currentSpeed, this.MaxHorizontalSpeed * this._direction, this.RunningAcceleration);
            Debug.Log(this._currentSpeed);
        }
    }

    private void _updateAirborne()
    {
        if (this._physics.velocity.x > this.MaxHorizontalSpeed)
        {
            Mathf.MoveTowards(this._currentSpeed, this.MaxHorizontalSpeed * this._direction, -this.AirDeceleration);
        }
        else
        {
            Mathf.MoveTowards(this._currentSpeed, this.MaxHorizontalSpeed * this.Direction, this.AirAcceleration);
        }
    }

    public void AddJump()
    {
        if(this._currentState == Playerstates.grounded)
            this._physics.AddForce(Vector2.up * this.JumpHeight);
    }

    public void AirDash()
    {
        if(this._currentState == Playerstates.airborne)
        {
            var dir = this._physics.velocity.x > 0 ? 1 : -1;

            this._physics.AddForce(Vector2.right * dir * this.DashForce);
        }
    }
}
