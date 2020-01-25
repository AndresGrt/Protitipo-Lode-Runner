using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationWin : MonoBehaviour
{
    public float radioCollEscaleras;
    public Vector3 posCollEscalas;
    public LayerMask escaleras;
    public bool s;
    private void Update()
    {
        Collider2D colisionEscaleras = Physics2D.OverlapCircle(transform.position + posCollEscalas, radioCollEscaleras, escaleras);
        if (colisionEscaleras)
        {
            FindObjectOfType<Player>().valorGravedad = 0;
            FindObjectOfType<Player>().gravedad = 0;
            if ((Input.GetKeyDown(KeyCode.UpArrow)))
            {
                s = true;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + posCollEscalas, radioCollEscaleras);
    }
}
