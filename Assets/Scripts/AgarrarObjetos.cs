using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarObjetos : MonoBehaviour
{
    [Header("Agarrar Objetos")]
    public GameObject handpoint;

    private GameObject objetoagarrado = null;

    void Start()
    {
        
    }


    void Update()
    {
        if (objetoagarrado != null)
        {
            if (Input.GetKey("f"))
            {
                objetoagarrado.GetComponent<Rigidbody>().useGravity = true;

                objetoagarrado.GetComponent<Rigidbody>().isKinematic = false;

                objetoagarrado.gameObject.transform.SetParent(null);

                objetoagarrado = null;
            }
        }   
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("moverCaja"))
        {
            if (Input.GetKey("e") && objetoagarrado == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;

                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position = handpoint.transform.position;

                other.gameObject.transform.SetParent(handpoint.gameObject.transform);

                objetoagarrado = other.gameObject;
            }
        }
    }
}
