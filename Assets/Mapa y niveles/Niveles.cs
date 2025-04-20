using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Niveles : MonoBehaviour
{

    public static int nivel;

    public static int MaxLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void NivelVencido() 
    {
        if (nivel < MaxLevel) 
        {
            MaxLevel++;
        }
        SceneManager.LoadScene("Menu");
    }
}
