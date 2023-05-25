using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ColocarPiezaOtro : MonoBehaviour
{
    listaPiezas listaPiezas;
    Jugada jugarDerecha;
    Jugada jugarIzquierda;
    PrimeraJugada jugarCentro;
    private bool yaJugoCentro = false;

    public void ColocarPieza(string data)
    {
        listaPiezas = GameObject.FindGameObjectWithTag("tablero").GetComponent<listaPiezas>();
        if (GameObject.FindGameObjectWithTag("jugarDer") != null)
            jugarDerecha = GameObject.FindGameObjectWithTag("jugarDer").GetComponent<Jugada>();
        if (GameObject.FindGameObjectWithTag("jugarIzq") != null)
            jugarIzquierda = GameObject.FindGameObjectWithTag("jugarIzq").GetComponent<Jugada>();

        if (GameObject.FindGameObjectWithTag("inicio1") != null)
            jugarCentro = GameObject.FindGameObjectWithTag("inicio1").GetComponent<PrimeraJugada>();
        else
        {
            yaJugoCentro = true;
        }

        if (data.Substring(3, 2) == "10" && yaJugoCentro)
        {
            GameObject.FindGameObjectWithTag("mensaje").GetComponent<MensajesJugadas>().mensaje = "";
            GameObject.FindGameObjectWithTag("Comunicacion").GetComponent<RS232>().Send("010");
        }
        if (data.Substring(3, 2) == "00") jugarIzquierda.hacerJugadaIzq(listaPiezas.listaFichasCompleta[binarioDecimal(Int32.Parse(data.Substring(5, 5)))], false);
        if (data.Substring(3, 2) == "01") jugarDerecha.hacerJugadaDer(listaPiezas.listaFichasCompleta[binarioDecimal(Int32.Parse(data.Substring(5, 5)))], false);
        if (data.Substring(3, 2) == "10" && !yaJugoCentro) jugarCentro.hacerJugada(listaPiezas.listaFichasCompleta[binarioDecimal(Int32.Parse(data.Substring(5, 5)))], false);

        if (GameObject.FindGameObjectWithTag("mensaje").GetComponent<MensajesJugadas>().mensaje != "")
            GameObject.FindGameObjectWithTag("mensaje").GetComponent<MensajesJugadas>().mensaje = "Jugada el jugador " + binarioDecimal(Int32.Parse(data.Substring(10, 2)));

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
