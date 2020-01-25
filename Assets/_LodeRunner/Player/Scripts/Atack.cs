using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour {

    public LayerMask Ladrillos;
    public Vector3 posCollLadrillosR;
    public Vector3 posCollLadrillosL;
    public float radioCollLadrillos;
    public DestroyLadrillos ladrilloDetroy;
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Collider2D collisionLadrillos = Physics2D.OverlapCircle(transform.position + posCollLadrillosL, radioCollLadrillos, Ladrillos);
            if (collisionLadrillos)
            {
                ladrilloDetroy = collisionLadrillos.gameObject.GetComponent<DestroyLadrillos>();
                if (ladrilloDetroy.activador == false)
                {
                    ladrilloDetroy.rend.enabled = !ladrilloDetroy.rend.enabled;
                    ladrilloDetroy.edgeCollider2D.enabled = !ladrilloDetroy.edgeCollider2D.enabled;
                    ladrilloDetroy.boxCollider2D.enabled = !ladrilloDetroy.boxCollider2D.enabled;
                    ladrilloDetroy.activador = true;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D collisionLadrillos = Physics2D.OverlapCircle(transform.position + posCollLadrillosR, radioCollLadrillos, Ladrillos);
            if (collisionLadrillos)
            {
                ladrilloDetroy = collisionLadrillos.gameObject.GetComponent<DestroyLadrillos>();
                if (ladrilloDetroy.activador == false)
                {
                    ladrilloDetroy.rend.enabled = !ladrilloDetroy.rend.enabled;
                    ladrilloDetroy.edgeCollider2D.enabled = !ladrilloDetroy.edgeCollider2D.enabled;
                    ladrilloDetroy.boxCollider2D.enabled = !ladrilloDetroy.boxCollider2D.enabled;
                    ladrilloDetroy.activador = true;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + posCollLadrillosL, radioCollLadrillos);
        Gizmos.DrawWireSphere(transform.position + posCollLadrillosR, radioCollLadrillos);
    }
}
