﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Overland.Scripts.Players;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public LayerMask groundLayer;
    public bool AutoMove = false;
    public float TimeToWait = 1f;

    [HideInInspector]
    public bool InputEnabled = true;

    private float JumpPower = 400;
    private Rigidbody2D rigidbody2d;
    private float speed = 3;
    private bool jump;
    private float jumpButtonElapsed = 0;
    private float move;
    private float castBottomOffset = 0.9f;
    private Vector3 leftEdge;
    private Vector3 rightEdge;
    private bool flying = false;
    private bool takingOff = false;
    private float waitElapsed = 0f;

    // Use this for initialization
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        this.JumpPower = GetComponent<PlayerCore>().parameters.JumpPower;
    }

    // Update is called once per frame
    private void Update()
    {
        leftEdge = transform.position - Vector3.right * 0.5f;
        rightEdge = transform.position + Vector3.right * 0.5f;

        Debug.DrawLine(leftEdge, leftEdge - transform.up * this.castBottomOffset);
        Debug.DrawLine(transform.position, transform.position - transform.up * this.castBottomOffset);
        Debug.DrawLine(rightEdge, rightEdge - transform.up * this.castBottomOffset);

        this.jump = Input.GetButton("Jump") && jumpButtonElapsed < 0.19f;
        this.move = Input.GetAxisRaw("Horizontal");

        if (!this.jump)
        {
            this.jump = Input.GetMouseButton(0) && jumpButtonElapsed < 0.19f;
        }

        if (waitElapsed <= this.TimeToWait)
        {
            waitElapsed += Time.deltaTime;
            this.InputEnabled = false;
        }
        else
        {
            this.InputEnabled = true;
        }
    }

    private void FixedUpdate()
    {
        var velocity = rigidbody2d.velocity;
        var castLeft = Physics2D.Linecast(leftEdge, leftEdge - transform.up * this.castBottomOffset, groundLayer);
        var castCenter = Physics2D.Linecast(transform.position, transform.position - transform.up * this.castBottomOffset, groundLayer);
        var castRight = Physics2D.Linecast(rightEdge, rightEdge - transform.up * this.castBottomOffset, groundLayer);

        jumpButtonElapsed += Time.deltaTime;

        if (this.jump && this.InputEnabled)
        {
            this.rigidbody2d.AddForce(Vector2.up * this.JumpPower, ForceMode2D.Force);
        }

        if (castLeft.collider || castCenter || castRight.collider)
        {
            this.jumpButtonElapsed = 0;
            //    this.flying = false;
            //    if (/*"!this.takingOff && */this.jump)
            //    {
            //        //transform.position = new Vector2(transform.position.x, transform.position.y + this.castBottomOffset);
            //        this.rigidbody2d.AddForce(Vector2.up * this.JumpPower);
            //        this.takingOff = true;
            //    }
        }
        //else
        //{
        //    this.takingOff = false;
        //    this.flying = true;
        //}

        var x = 0f;
        var y = 0f;
        //if (!flying && (move > 0 || move < 0))
        //{
        //    var hit = castRight.collider ? castRight : castLeft;
        //    var slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
        //    x = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * Mathf.Sign(this.move) * this.speed;
        //    y = Mathf.Sin(slopeAngle * Mathf.Deg2Rad) * Mathf.Sign(this.move) * this.speed;
        //}
        //else if (flying)
        //{
        if (this.InputEnabled)
        {
            if (AutoMove)
            {
                x = +1 * this.speed;
            }
            else
            {
                x = this.move * this.speed;
            }
        }
        y = velocity.y;
        //}

        var v = transform.position + new Vector3(x, y, transform.position.z);
        Debug.DrawLine(transform.position, v);

        this.rigidbody2d.velocity = new Vector2(x, y);
    }
}
