using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioTexturaEnemigo : MonoBehaviour
{
    public Material normal;

    public Material dado;

    Renderer ren;

    bool dadoBool;

    float cont;

    bool cambio;

    // Start is called before the first frame update
    void Start()
    {

        ren = GetComponent<Renderer>();

        dadoBool = false;

        cambio = false;

        cont = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (dadoBool) 
        {
            ren.material = dado;
            dadoBool = false;
        }
        else if (cambio)
        { 
            ren.material = normal;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bala") dadoBool = true;

    }

    private void FixedUpdate()
    {
        cont += Time.deltaTime;

        if (cont > 1)
        {

            cont = 0;
            cambio = true;

        }

        else 
        {

            cambio = false;
            cont += Time.deltaTime;

        }
    }
}
