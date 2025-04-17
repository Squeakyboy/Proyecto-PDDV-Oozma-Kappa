using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    [SerializeField] List<Item> items;

    [SerializeField] ContadorMuertes ContadorMonedas;
    [SerializeField] ContadorMuertes ContadorVida;
    [SerializeField] ContadorMuertes ContadorDamage;
    [SerializeField] private SpeechBubblePopWiggle tendero;

    // Start is called before the first frame update
    void Start()
    {
        tendero = FindObjectOfType<SpeechBubblePopWiggle>();
    }

    // Update is called once per frame
    void Update()
    {

        ContadorMonedas.cont = VidaPlayer.monedas;
        ContadorVida.cont = VidaPlayer.VidaMaxP;
        ContadorDamage.cont = Disparar.damageExtra;

        bool salir = Input.GetButtonDown("Cancel");

        if (salir)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("MenuPrincipal");
        }
    }

    public void comprar(int producto) 
    {

        if (!items[producto].comprado)
        {
            if (VidaPlayer.monedas >= items[producto].precio)
            {

                VidaPlayer.monedas -= items[producto].precio;

                ContadorMonedas.cont = VidaPlayer.monedas;
                ContadorVida.cont = VidaPlayer.VidaMaxP;
                ContadorDamage.cont = Disparar.damageExtra;

                Inventario.items.Add(items[producto]);  

                //items[producto].comprado = true;

                print("comprado " + Inventario.items.Count);

            }
            else tendero.ShowBubble();

        }
        
    }
}
