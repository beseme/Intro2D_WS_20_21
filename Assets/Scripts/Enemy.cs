using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float FireRate = 0;
    public GameObject Projectile = null;

    private float cooldown = 0;
    private Move player = null;

    private void Awake()
    {
        cooldown = 1 / FireRate;
        player = FindObjectOfType<Move>();
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            cooldown = 1 / FireRate;
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        var dir = player.transform.position - transform.position;
        dir = dir.normalized;

        transform.up = dir;
    }

    private void Shoot()
    {
        Instantiate(Projectile, transform.position + transform.up * 2, this.transform.rotation);
    }
}
