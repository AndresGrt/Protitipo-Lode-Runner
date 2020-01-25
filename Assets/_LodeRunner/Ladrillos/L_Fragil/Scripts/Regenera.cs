using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regenera : MonoBehaviour {

    public bool rg;
    public GameObject ld;
    public float correT = 0f;
    public float maximoT;
    void Start () {
        maximoT = 2;
    }
	
    public void Acciones()
    {
        if (correT >= maximoT)
        {
            ld.gameObject.SetActive(true);
            correT = 0f;
            rg = false;
        }
    }
}
