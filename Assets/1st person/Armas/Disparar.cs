using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public ContadorMuertes contBalas; 

    public List<GameObject> armasPlayer; 

    public GameObject balaInicio;

    public GameObject balaPrefab;

    public Transform cam;

    Renderer ren;

    MeshFilter meshFilter;

    int ArmaActual;

    float cont;

    bool cambio;

    float contRecBala;

    Arma armaActual;

    public static int damageExtra;

    // Start is called before the first frame update
    void Start()
    {

        meshFilter = GetComponent<MeshFilter>();

        ren = GetComponent<Renderer>();

        armaActual = armasPlayer[ArmaActual].GetComponent<Arma>();

        ArmaActual = 0;

        cont = 0;

        ren.material = armasPlayer[ArmaActual].GetComponent<Renderer>().material;

        meshFilter.mesh = armasPlayer[ArmaActual].GetComponent<MeshFilter>().mesh;

        contRecBala = 0;

        contBalas.cont = armaActual.balas;
    }

    private void Update()
    {
        transform.rotation = cam.rotation;

        bool fire = Input.GetButton("Disparar");

        cambio = Input.GetButtonDown("CambioArma");

        if (fire && cont >= armaActual.tiempoEntreBalas) 
        {

            if (armaActual.balas > 0)
            {

                GameObject balaTemporal = Instantiate(balaPrefab, transform.position, transform.rotation);

                Rigidbody rb = balaTemporal.GetComponent<Rigidbody>();

                float velocidadRnd = armaActual.VelocidadBala - Random.Range(0, 1000);

                rb.AddForce(transform.forward * velocidadRnd);

                balaTemporal.GetComponent<EfectoBala>().damage = armaActual.damageBala + damageExtra;

                Destroy(balaTemporal, 1.0f);

                cont = 0;

                armaActual.balas--;

                contBalas.cont = armaActual.balas;

            }

        }

        if (cambio) { CambioArmaFunc(); }

        bool recarga = Input.GetButton("Recargar");

        if (fire || cambio) { recarga = false; }

        Recargar(recarga);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (ArmaActual >= 0)
        if (cont < armaActual.tiempoEntreBalas) cont += Time.deltaTime; 

    }

    void CambioArmaFunc() 
    {

        if (ArmaActual < armasPlayer.Count -1) ArmaActual++; else ArmaActual = 0;

        armaActual = armasPlayer[ArmaActual].GetComponent<Arma>();

        ren.material = armasPlayer[ArmaActual].GetComponent<Renderer>().material;

        meshFilter.mesh = armasPlayer[ArmaActual].GetComponent<MeshFilter>().mesh;

        contBalas.cont = armaActual.balas;

        print(ArmaActual + " / " + armaActual.tiempoEntreBalas+ " / " + armaActual.VelocidadBala);
        
    }

    void Recargar(bool rec) 
    {
        if (rec && armaActual.balas < armaActual.BalasPorRafaga)
        {
            if (armaActual.balaABala)
            {
                if (contRecBala <= armaActual.tiempoRecargaBala) { contRecBala += Time.deltaTime; }
                else { contRecBala = 0; armaActual.balas++; print(armaActual.balas); }

            }

            else
            {
                if (contRecBala <= armaActual.tiempoRecarga) { contRecBala += Time.deltaTime; }
                else { contRecBala = 0; armaActual.balas = armaActual.BalasPorRafaga; print("recargado full" + armaActual.balas); }
            }

            contBalas.cont = armaActual.balas;
        }
        else { contRecBala = 0; }
    } 
}
