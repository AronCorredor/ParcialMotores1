using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{

    public Animator Puerta;

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
                Puerta.SetBool("puertaAbierta", true);
            }

            if (activa == false)
            {
                Puerta.SetBool("puertaAbierta", false);
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
