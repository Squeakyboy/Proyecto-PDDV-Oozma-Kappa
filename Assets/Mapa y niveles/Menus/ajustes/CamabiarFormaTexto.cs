using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SlidersActivos 
{
    [SerializeField] public Slider slider;
    [SerializeField] public TextMeshProUGUI text; 
};

public class CamabiarFormaTexto : MonoBehaviour
{

    [SerializeField] ajustes aj;

    [SerializeField] List<GameObject> CalidadURP;
    [SerializeField] List<GameObject> AntiAliasing; 
    [SerializeField] List<GameObject> Sombras; 
    [SerializeField] List<GameObject> CalidadTexturas;

    [SerializeField] List<GameObject> SonidoGeneral;

    [SerializeField] List<SlidersActivos> Scrollbars;

    // Start is called before the first frame update
    void Start()
    {
        CalidadURP[aj.CalidadURPInicial].GetComponent<TextMeshProUGUI>().color = Color.red;
        AntiAliasing[aj.AntiAliasingInicial].GetComponent<TextMeshProUGUI>().color = Color.red;
        Sombras[aj.SombrasInicial].GetComponent<TextMeshProUGUI>().color = Color.red;
        CalidadTexturas[aj.SombrasInicial].GetComponent<TextMeshProUGUI>().color = Color.red;

        SonidoGeneral[aj.sonidoGeneralInicial].GetComponent<TextMeshProUGUI>().color = Color.red;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CambiarColorCalidadURP(int num)
    {

        for (int i = 0; i < CalidadURP.Count; i++)
        {
            CalidadURP[i].GetComponent<TextMeshProUGUI>().color = Color.white;
        }

        CalidadURP[num].GetComponent<TextMeshProUGUI>().color = Color.red;
    }

    public void CambiarColorAntiAliasing(int num)
    {

        for (int i = 0; i < AntiAliasing.Count; i++)
        {
            AntiAliasing[i].GetComponent<TextMeshProUGUI>().color = Color.white;
        }

        AntiAliasing[num].GetComponent<TextMeshProUGUI>().color = Color.red;
    }

    public void CambiarColorSombras(int num)
    {

        for (int i = 0; i < Sombras.Count; i++)
        {
            Sombras[i].GetComponent<TextMeshProUGUI>().color = Color.white;
        }

        Sombras[num].GetComponent<TextMeshProUGUI>().color = Color.red;
    }

    public void CambiarColorCalidadTexturas(int num) 
    {

        for (int i = 0; i < CalidadTexturas.Count; i++)
        {
            CalidadTexturas[i].GetComponent<TextMeshProUGUI>().color = Color.white;
        }

        CalidadTexturas[num].GetComponent<TextMeshProUGUI>().color = Color.red;
    }

    public void CambiarColorSonidoGeneral(int num) 
    {

        for (int i = 0; i < SonidoGeneral.Count; i++) 
        {
            SonidoGeneral[i].GetComponent<TextMeshProUGUI>().color = Color.white;
        }

        SonidoGeneral[num].GetComponent<TextMeshProUGUI>().color = Color.red;
    }

    public void ComprobarValor(int scrollBar)
    {
        Scrollbars[scrollBar].text.text = Scrollbars[scrollBar].slider.value.ToString();
    }
}
