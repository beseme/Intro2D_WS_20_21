using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionInteraction inter = collision.gameObject.GetComponent<CollisionInteraction>();
        if (inter != null)
        {
            inter.ChangeColour(Color.green);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CollisionInteraction inter = collision.gameObject.GetComponent<CollisionInteraction>();
        if (inter != null)
        {
            inter.ChangeColour(Color.red);
        }
    }
}
