using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirCeleste : MonoBehaviour
{
    [Header("Informacion Animator")]
    public Animator palancaArriba;
    public Animator palancaAbajo;

    [Header("Informacion Paredes")]
    public GameObject Pared1;
    public GameObject Pared2;

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
                palancaArriba.SetBool("celesteActiva", true);
                palancaAbajo.SetBool("celesteActiva", false);
            }

            if (activa == false)
            {
                palancaArriba.SetBool("celesteActiva", false);
                palancaAbajo.SetBool("celesteActiva", true);
            }
        }
        if (activa == true)
        {
            Pared1.SetActive(false);
            Pared2.SetActive(false);
        }
        if (activa == false)
        {
            Pared1.SetActive(true);
            Pared2.SetActive(true);
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
