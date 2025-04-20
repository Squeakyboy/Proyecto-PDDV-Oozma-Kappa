using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActivarShaders : MonoBehaviour
{

    Renderer ren;


    // Start is called before the first frame update
    void Start()
    {

        string encendida = "_Encender";

        ren = GetComponent<Renderer>();

        Material[] materials = ren.materials; 

        for (int i = 0; i < materials.Length; i++)
        {
            if (ren.materials[i].HasProperty(encendida))
            {
                ren.materials[i].SetFloat(encendida, 1.0f);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
