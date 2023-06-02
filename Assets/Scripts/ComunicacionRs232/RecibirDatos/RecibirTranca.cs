using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RecibirTranca : MonoBehaviour
{
    public void Tranca(string data)
    {
        int veces = binarioDecimal(Int32.Parse(data.Substring(19, 2)));
        veces++;

        if (veces == 4 && PlayerPrefs.GetInt("modo", 0) == 1)
        {

            int llevaE1 = binarioDecimal(Int32.Parse(data.Substring(3, 8)));
            int llevaE2 = binarioDecimal(Int32.Parse(data.Substring(11, 8)));
            if (PlayerPrefs.GetInt("modo", 0) == 2)
            {
                GameObject[] listaFichasPila = GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaPiezasPila>().listaFichasPila;
                foreach (GameObject ficha in listaFichasPila)
                {
                    if(ficha!=null)
                        GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaFichasRestantes>().AgregarFicha(ficha);
                }
                if (PlayerPrefs.GetInt("Jugador", 0) == 2)
                    llevaE2 = GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaFichasRestantes>().conteoPuntos();
                else
                    llevaE1 = GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaFichasRestantes>().conteoPuntos();    
                    
                if (llevaE1 > llevaE2)
                    this.gameObject.GetComponent<RS232>().Send("1101" + decimalBinario(llevaE1-llevaE2, 8));
                else if (llevaE2 > llevaE1)
                    this.gameObject.GetComponent<RS232>().Send("1100" + decimalBinario(llevaE2-llevaE1, 8));
                else if (llevaE1 == llevaE2)
                    this.gameObject.GetComponent<RS232>().Send("110100000000");
            }
            else
            {
                if (llevaE1 > llevaE2)
                    this.gameObject.GetComponent<RS232>().Send("1101" + data.Substring(3, 8));
                else if (llevaE2 > llevaE1)
                    this.gameObject.GetComponent<RS232>().Send("1100" + data.Substring(11, 8));
                else if (llevaE1 == llevaE2)
                    this.gameObject.GetComponent<RS232>().Send("110100000000");
            }
        }
        else
        {


            if ((PlayerPrefs.GetInt("Jugador", 0) == 1 || PlayerPrefs.GetInt("Jugador", 0) == 3))
            {


                int llevaE1 = binarioDecimal(Int32.Parse(data.Substring(3, 8)));
                int conteo1 = GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaFichasRestantes>().conteoPuntos();
                conteo1 = conteo1 + llevaE1;
                this.gameObject.GetComponent<RS232>().Send("101" + decimalBinario(conteo1, 8) + data.Substring(11, 8) + decimalBinario(veces, 2));
            }
            else
            {

                int llevaE2 = binarioDecimal(Int32.Parse(data.Substring(11, 8)));
                int conteo1 = GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaFichasRestantes>().conteoPuntos();
                conteo1 = conteo1 + llevaE2;
                this.gameObject.GetComponent<RS232>().Send("101" + data.Substring(3, 8) + decimalBinario(conteo1, 8) + decimalBinario(veces, 2));


            }
        }


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
}
