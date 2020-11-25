using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAndShoot : MonoBehaviour
{
    public GameObject Projectile = null;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Projectile, transform.position + transform.up * 2, this.transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        this.transform.up = (this.transform.position - mousePos).normalized * -1;
    }
}
