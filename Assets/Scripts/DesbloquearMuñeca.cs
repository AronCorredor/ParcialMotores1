using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloquearMuñeca : MonoBehaviour
{

    public GameObject Box;

    private bool enZona;
    private bool activa;

    void Start()
    {

    }

    private void Update()
    {
        if (enZona == true)
        {
            Destroy(Box);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "moverCaja")
        {
            enZona = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "moverCaja")
        {
            enZona = false;
        }
    }

}
