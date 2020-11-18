using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInteraction : MonoBehaviour
{
    private SpriteRenderer sprite = null;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeColour(Color color)
    {
        sprite.color = color;
    }
}
