using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RecibirPase : MonoBehaviour
{


    public void RecibirPasar(string data)
    {
        PlayerPrefs.SetInt("Pases", binarioDecimal(Int32.Parse(data.Substring(6, 2))));
        if (PlayerPrefs.GetInt("Pases", 0) == 4)
        {
            Debug.Log("se acabo");
            GameObject.FindGameObjectWithTag("mensaje").GetComponent<MensajesJugadas>().mensaje = "Fin";
        }
        else
        {
            if (binarioDecimal(Int32.Parse(data.Substring(6, 2))) != PlayerPrefs.GetInt("Jugador", 0))
                GameObject.FindGameObjectWithTag("mensaje").GetComponent<MensajesJugadas>().mensaje = "Paso el jugador " + binarioDecimal(Int32.Parse(data.Substring(6, 2)));

            if (data.Substring(3, 1) == "0")
            {
                Turno(true);
                GameObject.FindGameObjectWithTag("mensaje").GetComponent<MensajesJugadas>().mensaje = "Es tu turno";
                data = data.Substring(0, 3) + "1" + data.Substring(4);
            }

            if (binarioDecimal(Int32.Parse(data.Substring(6, 2))) != PlayerPrefs.GetInt("Jugador", 0))
            {
                this.gameObject.GetComponent<RS232>().Send(data);
            }
        }
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

    public void Turno(bool turno)
    {
        GameObject[] listaFichasRestantes = GameObject.FindGameObjectsWithTag("pieza");
        for (int j = 0; j < listaFichasRestantes.Length; j++)
        {

            listaFichasRestantes[j].GetComponent<PiezaDomino>().turno = turno;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Pases", 0);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
