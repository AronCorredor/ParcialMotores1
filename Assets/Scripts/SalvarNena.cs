using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalvarNena : MonoBehaviour
{

    public GameObject nena;
    public GameObject nenaCuerpo;

    private bool enZona;
    private bool activa;

    void Start()
    {
        nena.SetActive(true);
        nena.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && enZona == true)
        {
                nena.SetActive(false);
                nenaCuerpo.SetActive(true);
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
