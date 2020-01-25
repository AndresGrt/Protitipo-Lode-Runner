using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroidCofre : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D item)
    {
        if (item.GetComponent<Player>())
        {
            Destroy(this.gameObject);
        }
    }

}
