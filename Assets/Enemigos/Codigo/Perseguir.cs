using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguir : MonoBehaviour
{

    [SerializeField] float velocidadEnemigo;
    [SerializeField] float velocidadEnemigoDificil; 

    public Transform player;

    public bool ataque;
    float cont;

    Rigidbody rb;

    public float TiempoEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        ataque = false;

        cont = 0;

        rb = GetComponent<Rigidbody>();

        if (BotoneMenu.dificultad == 1) 
        {
            velocidadEnemigo = velocidadEnemigoDificil;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cont < TiempoEnemigo) { cont += Time.deltaTime; } else ataque = false;

        Vector3 direccion = player.position - transform.position;

        direccion.y = 0;

        direccion.Normalize();

        Vector3 velocity = direccion * velocidadEnemigo;

        rb.velocity = velocity;

        if (!ataque)
        {
            rb.AddForce(direccion * velocidadEnemigo * Time.deltaTime, ForceMode.Impulse);
        }

    }

    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cont = 0;

        }
    }
}
