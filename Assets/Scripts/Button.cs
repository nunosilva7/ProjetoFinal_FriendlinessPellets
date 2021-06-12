using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator controlador;
    public GameObject porta;
    Animator controladorPorta;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnRayHit()
    {
        controlador.SetTrigger("Pressionado");
        controladorPorta = porta.GetComponent<Animator>();
        controladorPorta.SetTrigger("Abrir");
        porta.GetComponent<BoxCollider>().enabled = false;

    }
}
