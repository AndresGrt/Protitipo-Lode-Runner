using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLadrillos : MonoBehaviour
{
    public float correT = 0f;
    public float maximoT;
    public SpriteRenderer rend;
    public bool activador;
    public EdgeCollider2D edgeCollider2D;
    public BoxCollider2D boxCollider2D;
    private void Start()
    {
        maximoT = 5;
        rend = this.gameObject.GetComponent<SpriteRenderer>();
        edgeCollider2D = this.gameObject.GetComponent<EdgeCollider2D>();
        boxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (activador)
        {
            correT += Time.deltaTime;
            Acciones();
        }
    }
    public void Acciones()
    {
        if (correT >= maximoT)
        {
            rend.enabled = !rend.enabled;
            edgeCollider2D.enabled = !edgeCollider2D.enabled;
            boxCollider2D.enabled = !boxCollider2D.enabled;
            correT = 0f;
            activador = false;
        }
    }
}
