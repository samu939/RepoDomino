using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RecibirPuntuacion : MonoBehaviour
{
    public GameObject winWindow;
    public void Puntos(string data){
        
        int puntosEquipo1=PlayerPrefs.GetInt("puntosEquipo1",0);
        int puntosEquipo2=PlayerPrefs.GetInt("puntosEquipo2",0);
        int puntos= binarioDecimal(Int32.Parse(data.Substring(4,8)));
        if(data.Substring(3,1)=="0")
            puntosEquipo1+=puntos;
        else
            puntosEquipo2+=puntos;
        PlayerPrefs.SetInt("puntosEquipo1",puntosEquipo1);
        PlayerPrefs.SetInt("puntosEquipo2",puntosEquipo2);        
        winWindow.SetActive(true);
        if(GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaFichasRestantes>().CountNotNull()!=0)
                this.gameObject.GetComponent<RS232>().Send(data);

    }

    public static int binarioDecimal(long binario)
    {

        int numero = 0;
        int digito = 0;
        const int DIVISOR = 10;

        for (long i = binario, j = 0; i > 0; i /= DIVISOR, j++)
        {
            digito = (int)i % DIVISOR;
            if (digito != 1 && digito != 0)
            {
                return -1;
            }
            numero += digito * (int)Math.Pow(2, j);
        }

        return numero;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("puntosEquipo1",0);
        PlayerPrefs.SetInt("puntosEquipo2",0);
    }
    private void OnClose()
    {
        PlayerPrefs.SetInt("puntosEquipo1",0);
        PlayerPrefs.SetInt("puntosEquipo2",0);
    }
}
