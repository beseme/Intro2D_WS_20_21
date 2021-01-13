using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float HPmax = 0;

    public Image Bar = null;

    private float hp = 0;

    private void Awake()
    {
        hp = HPmax;
    }

    private void OnEnable()
    {
        hp = HPmax;
        Bar.fillAmount = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "damage")
        {
            hp -= 1;
            Bar.fillAmount = getPercentage();
            if(hp <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    private float getPercentage()
    {
        return hp / HPmax;
    }
}
