using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirTecho : MonoBehaviour
{
    public GameObject Box1;
    public GameObject Box2;
    public GameObject Box3;
    public GameObject Techo;

    void Start()
    {
        
    }


    void Update()
    {
        if (Box1 == null && Box2 == null && Box3 == null)
        {
            Destroy(Techo);
        }
    }
}
