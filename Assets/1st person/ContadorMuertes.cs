using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContadorMuertes : MonoBehaviour
{

    TextMeshProUGUI text;

    public int cont;

    // Start is called before the first frame update
    void Start()
    { 
        cont = 0;
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        text.text = cont.ToString();
        
    }
}
