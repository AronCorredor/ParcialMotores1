using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuertasInternas2 : MonoBehaviour
{

    public Animator Puerta1;

    private bool enZona;
    private bool activa;

    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && enZona == true)
        {

            activa = !activa;

            if (activa == true)
            {
                Puerta1.SetBool("puertaActivada", true);
            }

            if (activa == false)
            {
                Puerta1.SetBool("puertaActivada", false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enZona = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enZona = false;
        }
    }

}