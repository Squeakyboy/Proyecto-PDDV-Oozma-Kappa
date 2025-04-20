using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Arma : MonoBehaviour
{
    public float VelocidadBala;
    public float damageBala;
    public float tiempoEntreBalas;
    public int BalasPorRafaga;
    public int balas;
    public int tiempoRecarga;
    public bool balaABala;
    public float tiempoRecargaBala;

    // Start is called before the first frame update
    void Start()
    {
        balas = BalasPorRafaga;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
