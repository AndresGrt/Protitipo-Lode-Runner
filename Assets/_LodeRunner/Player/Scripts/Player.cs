using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Collisions")]
    public LayerMask ground;
    public LayerMask escaleras;
    public LayerMask cuerda;
    public LayerMask choque;
    [Header("Collisions Positions")]
    public Vector3 posCollSuelo;
    public Vector3 posCollEscalas;
    public Vector3 posCollCuerda;
    [Header("Collisions Area")]
    public float radioCollGround;
    public float radioCollEscaleras;
    public float radioCollCuerda;
    [Header("Geavity Data")]
    public float gravedad;
    public float valorGravedad;
    [Header("Collision Activators")]
    public bool tocaSuelo;
    public bool tocaEscalas;
    public bool tocaCuerda;
    [Header("Animations")]
    public Animator anim;
    void Start ()
    {
        this.gameObject.AddComponent<Moving>();
	}
	
	void Update ()
    {
        Colisiones();
	}

    public void Colisiones()
    {
        Collider2D colisionSuelo = Physics2D.OverlapCircle(transform.position + posCollSuelo, radioCollGround, ground);
        Collider2D colisionEscaleras = Physics2D.OverlapCircle(transform.position + posCollEscalas, radioCollEscaleras, escaleras);
        Collider2D colisionCuerda = Physics2D.OverlapCircle(transform.position + posCollCuerda, radioCollCuerda, cuerda);

        if (!colisionSuelo)
        {
            transform.position -= transform.up * gravedad * Time.deltaTime;
            tocaSuelo = false;
            gravedad = valorGravedad;
        }
        else if (colisionSuelo)
        {
            gravedad = 0;
            tocaSuelo = true;
        }

        if (colisionEscaleras)
        {
            gravedad = 0;
            tocaEscalas = true;
        }
        else if (colisionCuerda)
        {
            gravedad = 0;
            tocaCuerda = true;
        }
        else
        {
            tocaEscalas = false;
            tocaCuerda = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + posCollSuelo, radioCollGround);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + posCollEscalas, radioCollEscaleras);
        Gizmos.DrawWireSphere(transform.position + posCollCuerda, radioCollCuerda);
    }
}
