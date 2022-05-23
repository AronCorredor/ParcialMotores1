using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LloronaAnimacion : MonoBehaviour
{

    public Animator Puerta;
    public GameObject llorona;
    public AudioSource controlSonido;
    public AudioClip sonidoGrito;

    private bool enZona;
    private bool activa;

    void Start()
    {

    }

    private void Update()
    {
        if (enZona == true)
        {
            activa = !activa;

            if (activa == true)
            {
                Puerta.SetBool("lloronaPiso", true);
                Destroy(llorona, 3);
                controlSonido.PlayOneShot(sonidoGrito);
            }

            if (activa == false)
            {
                Puerta.SetBool("lloronaPiso", false);
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