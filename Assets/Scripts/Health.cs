using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HP = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "damage")
        {
            HP -= 1;
            if(HP <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
