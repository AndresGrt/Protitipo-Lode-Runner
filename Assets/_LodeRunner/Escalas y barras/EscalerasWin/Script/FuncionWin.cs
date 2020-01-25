using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionWin : MonoBehaviour
{
    public Animator animEscalasEnd;
    GameObject [] items;
    GameObject este;
    SortingLayer layer;
    private void Start()
    {
        este = this.gameObject;
    }
    private void Update()
    {
        items = GameObject.FindGameObjectsWithTag("Cofre");
        if (items.Length <= 0)
        {
            este.layer = LayerMask.NameToLayer("EscalasWin");
            animEscalasEnd.SetTrigger("Rearmar");
        }
    }
}
