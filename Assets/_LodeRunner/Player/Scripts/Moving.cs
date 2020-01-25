using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {

    private float speedPlayer;
    Player player;
    private int verifica;
    private void Start()
    {
        verifica = 0;
        player = FindObjectOfType<Player>();
        speedPlayer = 20f;
        player.anim.SetTrigger("Idle");
    }
    void Update () {
        Movimiento();
	}
    public void Movimiento()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && player.tocaEscalas == true)
        {
            transform.position += transform.up * speedPlayer * Time.deltaTime;
            player.anim.SetTrigger("Escale");
            player.anim.StopPlayback();
            verifica = 1;
        }
        else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.position -= transform.right * speedPlayer * Time.deltaTime;
            transform.localScale = new Vector3(-1f, 1f, 1f);
            if (player.tocaCuerda == true)
            {
                player.anim.SetTrigger("Cuerda");
                player.anim.StopPlayback();
                verifica = 2;
            }
            else if (player.tocaEscalas == true && verifica == 1)
            {
                player.anim.SetTrigger("Escale");
                player.anim.StopPlayback();
            }
            else
            {
                player.anim.SetTrigger("Walking");
                player.anim.StopPlayback();
                verifica = 0;
            }
        }
        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            transform.position += transform.right * speedPlayer * Time.deltaTime;
            transform.localScale = new Vector3(1f, 1f, 1f);
            if (player.tocaCuerda == true)
            {
                player.anim.SetTrigger("Cuerda");
                player.anim.StopPlayback();
                verifica = 2;
            }
            else if (player.tocaEscalas == true && verifica == 1)
            {
                player.anim.SetTrigger("Escale");
                player.anim.StopPlayback();
            }
            else
            {
                player.anim.SetTrigger("Walking");
                player.anim.StopPlayback();
                verifica = 0;
            }
        }
        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && player.tocaSuelo == false)
        {
            transform.position -= transform.up * speedPlayer * Time.deltaTime;
            if (player.tocaEscalas == true)
            {
                player.anim.SetTrigger("Escale");
                player.anim.StopPlayback();
                verifica = 1;
            }
            else if (player.tocaCuerda == true)
            {
                player.tocaCuerda = false;
                player.gravedad = player.valorGravedad;
                player.anim.SetTrigger("Salto");
                player.anim.StopPlayback();
                verifica = 0;
            }
        }
        else if (verifica == 2)
        {
            player.anim.SetTrigger("Cuerda");
            if (player.tocaCuerda == true)
            {
                player.anim.StartPlayback();
            }
        }
        else if (verifica == 1)
        {
            player.anim.SetTrigger("Escale");
            if (player.tocaEscalas == true)
            {
                player.anim.StartPlayback();
            }
        }
        else if (player.gravedad > 0)
        {
            player.anim.SetTrigger("Salto");
            player.anim.StopPlayback();
        }
        else if (FindObjectOfType<AnimationWin>().s == true)
        {
            FindObjectOfType<Player>().anim.SetTrigger("Winner");
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            player.anim.SetTrigger("Idle");
            player.anim.StopPlayback();
            verifica = 0;
        }
    }
}
