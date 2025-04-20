using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaEnemigos : MonoBehaviour
{

    public int MonedasPorKill;
    [SerializeField] int MonedasPorKillDificil;

    public ContadorMuertes contador;

    public float vida;
    public float vidaDificil; 

    public Slider vidaSlider;

    public int damage;
    public int damageDificil; 

    [SerializeField] VidaPlayer player;

    [SerializeField] bool boss; 

    // Start is called before the first frame update
    void Start()
    {
        //Cambio Dificultad
        if (BotoneMenu.dificultad == 1) 
        {
            vida = vidaDificil;
            damage = damageDificil;
            MonedasPorKill = MonedasPorKillDificil;
        }

        vidaSlider.maxValue = vida;
    }

    // Update is called once per frame
    void Update()
    {

        if (vida <= 0) 
        {

            VidaPlayer.monedas += MonedasPorKill;

            if (GeneraraEnemigos.ApareceBoss > GeneraraEnemigos.contBoss) GeneraraEnemigos.contBoss++;

            contador.cont++;

            if (boss) { PlayerControl.Victoria(); }

            if (VidaPlayer.Habilidad < VidaPlayer.MaxHabilidad)
            {
                VidaPlayer.Habilidad++;
            }

            Destroy(gameObject);

        }

        vidaSlider.value = vida; 
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bala")
        {

            vida -= other.GetComponent<EfectoBala>().damage;

        }

        if (other.tag == "Limite" && tag == "Enemigo") 
        {
            Destroy(gameObject);
        }
    }

}
