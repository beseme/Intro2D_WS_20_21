using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttachedHPBar : MonoBehaviour
{
   public Image Bar = null;
   public float Offset = 1;
   
   private void Update()
   {
      Bar.transform.position = Camera.main.WorldToScreenPoint(transform.position) + Vector3.up * Offset;
   }
}
