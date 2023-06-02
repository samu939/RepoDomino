using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BotonPasar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Pass()
    {
        GameObject[] listaFichasRestantes = GameObject.FindGameObjectsWithTag("pieza");
        if (PlayerPrefs.GetInt("modo", 0) == 2 && GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaPiezasPila>().CountNotNull()>0 && GameObject.FindGameObjectWithTag("inicio1")==null)
        {
            if (listaFichasRestantes.Length > 0)
            {
                if (CanPass() && listaFichasRestantes[0].GetComponent<PiezaDomino>().turno)
                {
                    GameObject ficha= this.AgarrarPila();
                    GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaFichasRestantes>().AgregarFicha(ficha);
                    
                    GameObject.FindGameObjectWithTag("Comunicacion").GetComponent<RS232>().Send("111" + decimalBinario(FindIndex(ficha),5));
                }
            }
        }
        else
        {
            if (listaFichasRestantes.Length > 0)
            {
                if (CanPass() && listaFichasRestantes[0].GetComponent<PiezaDomino>().turno)
                {

                    for (int j = 0; j < listaFichasRestantes.Length; j++)
                    {

                        listaFichasRestantes[j].GetComponent<PiezaDomino>().turno = false;

                    }
                    GameObject.FindGameObjectWithTag("mensaje").GetComponent<MensajesJugadas>().mensaje = "";
                    GameObject.FindGameObjectWithTag("Comunicacion").GetComponent<RS232>().Send("0110" + decimalBinario(PlayerPrefs.GetInt("Jugador", 0), 2));


                }
            }
        }
    }

    public GameObject AgarrarPila(){
        GameObject ficha=GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaPiezasPila>().PiezaRandom();
        GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaPiezasPila>().Delete(ficha);
        return ficha;

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

    public bool CanPass()
    {
        if (GameObject.FindGameObjectWithTag("inicio1") == null)
        {
            PiezaDomino FichaDerecha = GameObject.FindGameObjectWithTag("jugarDer").GetComponentInParent<PiezaDomino>();
            PiezaDomino FichaIzquierda = GameObject.FindGameObjectWithTag("jugarIzq").GetComponentInParent<PiezaDomino>();
            GameObject[] listaFichasRestantes = GameObject.FindGameObjectsWithTag("pieza");

            for (int j = 0; j < listaFichasRestantes.Length; j++)
            {

                if (listaFichasRestantes[j].GetComponent<PiezaDomino>().numeroDer == FichaDerecha.numeroDer || listaFichasRestantes[j].GetComponent<PiezaDomino>().numeroDer ==
                    FichaIzquierda.numeroIzq || listaFichasRestantes[j].GetComponent<PiezaDomino>().numeroIzq == FichaDerecha.numeroDer ||
                    listaFichasRestantes[j].GetComponent<PiezaDomino>().numeroIzq == FichaIzquierda.numeroIzq)
                {
                    return false;
                }

            }
        }

        return true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
