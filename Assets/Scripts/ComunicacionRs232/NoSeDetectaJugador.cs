using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSeDetectaJugador : MonoBehaviour
{
    public GameObject VentanaError;
    public GameObject Canva1;
    public GameObject Canva2;
    public void ErrorDeteccion()
    {

        VentanaError.SetActive(true);
        Canva1.SetActive(false);
        Canva2.SetActive(false);
        BloquearPiezas(false);
    }
    public void Detectado()
    {


        VentanaError.SetActive(false);
        Canva1.SetActive(true);
        Canva2.SetActive(true);
        BloquearPiezas(true);
    }

    public void BloquearPiezas(bool activa)
    {
        GameObject[] listaFichasRestantes = GameObject.FindGameObjectsWithTag("pieza");
        if (listaFichasRestantes != null)
        {
            for (int j = 0; j < listaFichasRestantes.Length; j++)
            {


            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
