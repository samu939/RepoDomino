using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RecibirVictoria : MonoBehaviour
{

    public void Victoria(string data){

        
        if ((data.Substring(3, 1) == "1" && (PlayerPrefs.GetInt("Jugador",0)==1 || PlayerPrefs.GetInt("Jugador",0)==3)) || 
            (data.Substring(3, 1) == "0" && (PlayerPrefs.GetInt("Jugador",0)==2 || PlayerPrefs.GetInt("Jugador",0)==4)))
        {
            int lleva=binarioDecimal(Int32.Parse(data.Substring(4,8)));
            int conteo=GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaFichasRestantes>().conteoPuntos();
            conteo=conteo+lleva;
            this.gameObject.GetComponent<RS232>().Send("100"+ data.Substring(3, 1) + decimalBinario(conteo,8));
        }else{
            if(GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaFichasRestantes>().CountNotNull()!=0)
                this.gameObject.GetComponent<RS232>().Send(data);
            else
                this.gameObject.GetComponent<RS232>().Send("110"+ data.Substring(3, 9));    
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
