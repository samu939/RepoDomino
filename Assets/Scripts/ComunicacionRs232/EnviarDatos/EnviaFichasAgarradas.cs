using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviaFichasAgarradas : MonoBehaviour
{


    public void EnviarFichasAgarradas()
    {
        List<int> fichasAgarradas = GameObject.FindGameObjectWithTag("tablero").GetComponent<GeneradorMano>().piezasUsadas;
        
        string envio = "000";
        int veces = 0;
        foreach (int ficha in fichasAgarradas)
        {
            envio = envio + decimalBinario(ficha);
            veces++;
        }
        while (veces < 21)
        {
            envio = envio + "11111";
            veces++;
        }
        
        this.gameObject.GetComponent<RS232>().Send(envio);
        
    }

    public string decimalBinario(int numero)
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


        while (binarioString.Length < 5)
        {
            binarioString = "0" + binarioString;

        }



        return binarioString;
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
