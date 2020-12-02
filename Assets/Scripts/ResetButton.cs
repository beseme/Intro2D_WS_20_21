using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    public GameObject Enemy = null;

    public Button Resetter = null;

    private void Awake()
    {
        Resetter.onClick.AddListener(DoReset);
    }

    public void DoReset()
    {
        Enemy.SetActive(true);
    }
}
