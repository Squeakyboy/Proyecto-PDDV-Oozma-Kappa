using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ajustes : MonoBehaviour
{
    [SerializeField] List<GameObject> gameplay;
    [SerializeField] List<GameObject> graficos;
    [SerializeField] List<GameObject> sonidos;

    [SerializeField] Slider DistanciaSombras;

    public int CalidadURPInicial;
    public int AntiAliasingInicial;
    public int SombrasInicial;
    public int CalidadTexturaInicial;

    public int sonidoGeneralInicial;

    // Start is called before the first frame update
    void Start()
    {

        AudioListener.volume = sonidoGeneralInicial / 100;

        //CalidadURPInicial = QualitySettings.GetQualityLevel();
        AntiAliasingInicial = QualitySettings.antiAliasing;
        //SombrasInicial = QualitySettings.shadowmaskMode;

        QualitySettings.SetQualityLevel(CalidadURPInicial);
        QualitySettings.antiAliasing = AntiAliasingInicial;
        CambiarTipoSombras(SombrasInicial);
        QualitySettings.globalTextureMipmapLimit = CalidadTexturaInicial;

        // Cerrar Pestañas
        CambiarMenuAjustes(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarMenuAjustes(int tipo) 
    {
        //Desactivar el resto
        for (int i = 0; i < gameplay.Count; i++)
        {
            gameplay[i].SetActive(false);
        }
        for (int i = 0; i < graficos.Count; i++)
        {
            graficos[i].SetActive(false);
        }
        for (int i = 0; i < sonidos.Count; i++)
        {
            sonidos[i].SetActive(false);
        }

        switch (tipo) 
        {
            case 0:           
                for (int i = 0; i < gameplay.Count; i++) 
                {
                    gameplay[i].SetActive(true);
                }
                break;
            case 1:
                for (int i = 0; i < graficos.Count; i++)
                {
                    graficos[i].SetActive(true);
                }
                break;
            case 2:
                for (int i = 0; i < sonidos.Count; i++)
                {
                    sonidos[i].SetActive(true);
                }
                break;
        }
    }

    // Gameplay

    // Graficos

    public void CalidadURP(int tipo) 
    {
        QualitySettings.SetQualityLevel(tipo);
    }

    public void CambiarAntiAliasing(int quality) 
    {
        QualitySettings.antiAliasing = quality;
    }

    public void CambiarTipoSombras(int tipo) 
    {
        switch (tipo) 
        {
            case 0:
                QualitySettings.shadows = UnityEngine.ShadowQuality.Disable;
                break;

            case 1:
                QualitySettings.shadows = UnityEngine.ShadowQuality.HardOnly;
                break;

            case 2:
                QualitySettings.shadows = UnityEngine.ShadowQuality.All;
                break;
        }
    }

    public void CambiarDistanciaSombras() 
    {
        QualitySettings.shadowDistance = DistanciaSombras.value;
    }

    public void CambiarCalidadTexturas(int valor) 
    {

        QualitySettings.globalTextureMipmapLimit = valor;
    }

    public void CambiarSonidoGeneral(float valor) 
    {
        AudioListener.volume = valor;
    }
}
