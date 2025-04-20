using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VidaPlayer : MonoBehaviour
{
    [SerializeField] ContadorMuertes contadorMonedas;
    [SerializeField] ContadorMuertes contadorVida; 

    [SerializeField] int Intentos;

    public Slider sliderVida;
    public Slider sliderHabilidad;

    public static int MaxHabilidad;
    public static int Habilidad;
    public int Vida;

    [SerializeField] int MaxHabilidadInput; 

    [SerializeField] int MaxVida;
    public static int VidaMaxP; 

    float cont;

    public static int monedas;

    // Start is called before the first frame update
    void Start()
    {

        MaxHabilidad = MaxHabilidadInput;

        Habilidad = 0;

        for (int i = 0; i < Inventario.items.Count; i++)
        {
            MaxVida += Inventario.items[i].vidaExtra;
        }

        cont = 0;

        sliderVida.maxValue = MaxVida;
        sliderHabilidad.maxValue = MaxHabilidad;

        if (Vida != MaxVida) Vida = MaxVida;

        if (Niveles.MaxLevel == 0) monedas = 0;

    }

    // Update is called once per frame
    void Update()
    {

        VidaMaxP = MaxVida;

        sliderVida.value = Vida;
        sliderHabilidad.value = Habilidad;

        contadorMonedas.cont = monedas;
        contadorVida.cont = Vida;

        if (Vida <= 0)  
        {

            SceneManager.LoadScene("MenuPrincipal");
            Cursor.lockState = CursorLockMode.None;
            
        }

        if (cont < 0.5f) 
        {
            cont += Time.deltaTime;
        } 
        else cont = 0;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {

            VidaEnemigos vidaEnemigo = collision.gameObject.GetComponent<VidaEnemigos>();

            if (vidaEnemigo != null && cont == 0)
            {
                Vida -= vidaEnemigo.damage;
                collision.gameObject.GetComponent<Perseguir>().ataque = true; 
            }
        }
    }
}
