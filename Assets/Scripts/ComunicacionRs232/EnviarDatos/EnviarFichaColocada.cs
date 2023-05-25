using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnviarFichaColocada : MonoBehaviour
{
    listaPiezas listaPiezas;
    Jugada jugarDerecha;
    Jugada jugarIzquierda;
    PrimeraJugada jugarCentro;

    public void ColocarPieza(GameObject ficha, int lado)
    {
          //Debug.Log(decimalBinario(FindIndex(ficha),5) + decimalBinario(PlayerPrefs.GetInt("Jugador",0),2));
        if (lado == 0)
            this.gameObject.GetComponent<RS232>().Send("00100" + decimalBinario(FindIndex(ficha),5) + decimalBinario(PlayerPrefs.GetInt("Jugador",0),2));
        if (lado == 1)
            this.gameObject.GetComponent<RS232>().Send("00101" + decimalBinario(FindIndex(ficha),5) + decimalBinario(PlayerPrefs.GetInt("Jugador",0),2));
        if (lado == 2)
            this.gameObject.GetComponent<RS232>().Send("00110" + decimalBinario(FindIndex(ficha),5) + decimalBinario(PlayerPrefs.GetInt("Jugador",0),2));

        

    }

    public string decimalBinario(int numero, int Length)
    {

        long binario = 0;

        int DIVISOR = 2;
        long digito = 0;

        for (int i = numero % DIVISOR, j = 0; numero > 0; numero /= DIVISOR, i = numero % DIVISOR, j++)
        {
            digito = i % DIVISOR;
            binario += digito * (long)Math.Pow(10, j);
        }

        string binarioString = binario.ToString();


        while (binarioString.Length < Length)
        {
            binarioString = "0" + binarioString;

        }



        return binarioString;
    }

    public int FindIndex(GameObject ficha)
    {

        listaPiezas listaFichas = GameObject.FindGameObjectWithTag("tablero").GetComponent<listaPiezas>();
        for (int j = 0; j < listaFichas.listaFichasCompleta.Length; j++)
        {
            if (listaFichas.listaFichasCompleta[j] != null)
            {
                if (ficha.name.Contains(listaFichas.listaFichasCompleta[j].name))
                {
                    
                    return j;
                }
            }
        }
        return 10;
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
