using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GeneraraEnemigos : MonoBehaviour
{

    float cont;

    public static int contBoss;

    public List<GameObject> enemigo;

    [SerializeField] public GameObject boss;

    public static int ApareceBoss;

    [SerializeField] int ApareceBossInput;
    [SerializeField] int ApareceBossDificil;

    [SerializeField] int TiempoAparicion;
    [SerializeField] int TiempoAparicionDificil; 

    [SerializeField] List<Transform> enemySpawns;
    [SerializeField] Transform bossSpawn;

    [SerializeField] Light mainLight;

    // Start is called before the first frame update
    void Start()
    {

        cont = 0;

        contBoss = 0;

        //Condicion Dificultad
        if (BotoneMenu.dificultad == 1) 
        {
            ApareceBoss += ApareceBossDificil;
            TiempoAparicion = TiempoAparicionDificil;
            mainLight.color = Color.red;
        }

        ApareceBoss = ApareceBossInput;

    }

    // Update is called once per frame
    void Update()
    {


        
    }

    private void FixedUpdate()
    {

        cont += Time.deltaTime;

        if (cont > TiempoAparicion && contBoss < ApareceBoss) //segudos por generacion
        {

            int S = Random.Range(0, enemySpawns.Count); 

            int rnd = Random.Range(0, enemigo.Count);

            Vector3 pos = new Vector3(enemySpawns[S].position.x, 1.2f, enemySpawns[S].position.z);

            cont = 0;
            
            GameObject _enemigo = Instantiate(enemigo[rnd]);
            _enemigo.SetActive(true);

            _enemigo.transform.position = pos;
            _enemigo.tag = "Enemigo";

        }

        if (contBoss == ApareceBoss) 
        {
            Vector3 pos = new Vector3(bossSpawn.position.x, 1.2f, bossSpawn.position.z);

            GameObject _boss = Instantiate(boss);
            _boss.SetActive(true);

            _boss.transform.position = pos;
            _boss.tag = "Enemigo";

            contBoss++;

        }

        else
        {

            cont += Time.deltaTime;

        }
    }
}
