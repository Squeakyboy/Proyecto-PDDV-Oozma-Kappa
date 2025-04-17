using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{

    public static List<Item> items = new List <Item> { };

    // Start is called before the first frame update
    void Start()
    {

        Disparar.damageExtra = 0;

        for (int i = 0; i < items.Count; i++)
            Disparar.damageExtra += items[i].ataqueExtra;
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
}
