using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RecibirAgarrarPila : MonoBehaviour
{
    listaPiezas listaPiezas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AgarrarPila(string data)
    {
        listaPiezas = GameObject.FindGameObjectWithTag("tablero").GetComponent<listaPiezas>();
        GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaPiezasPila>().Delete(listaPiezas.listaFichasCompleta[binarioDecimal(Int32.Parse(data.Substring(3, 5)))]);
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
