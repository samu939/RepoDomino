using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RecibirPiezasEscogidas : MonoBehaviour
{
    GeneradorMano generadorMano;
    public GameObject fichasIzq;
    public GameObject fichasDer;
    public GameObject fichasFrent;
    public void PiezasYaEscogidas(string data)
    {
        if (GameObject.FindGameObjectWithTag("tablero").GetComponent<GeneradorMano>().piezasUsadas.Count == 0)
        {
            List<int> piezasUsadas = new List<int>();
            string[] piezas = new string[21];
            //Application.Quit();
            int j = 3;
            for (int i = 0; i < 21; i++)
            {
                piezas[i] = data.Substring(j, 5);
                j += 5;
            }
            j = 0;
            for (int i = 0; i < 21; i++)
            {

                if (piezas[i] == "11111")
                    j++;
                else
                    piezasUsadas.Add(binarioDecimal(Int32.Parse(piezas[i])));


            }
            

            if (j == 0 && PlayerPrefs.GetInt("Jugador", 0) == 0)
                PlayerPrefs.SetInt("Jugador", 4);
            if (j == 7 && PlayerPrefs.GetInt("Jugador", 0) == 0)
                PlayerPrefs.SetInt("Jugador", 3);
            if (j == 14 && PlayerPrefs.GetInt("Jugador", 0) == 0)
                PlayerPrefs.SetInt("Jugador", 2);

            if (PlayerPrefs.GetInt("modo", 0) == 1)
            {
                fichasDer.GetComponent<FichasContrarios>().ActualizarJugadores();
                fichasIzq.GetComponent<FichasContrarios>().ActualizarJugadores();
                fichasFrent.GetComponent<FichasContrarios>().ActualizarJugadores();
            } 

            GameObject.FindGameObjectWithTag("tablero").GetComponent<GeneradorMano>().piezasUsadas = piezasUsadas;
            GameObject.FindGameObjectWithTag("tablero").GetComponent<GeneradorMano>().GenerarMano();
        }
        else
        {
            if (PlayerPrefs.GetInt("modo", 0) == 2)
            {

                List<int> piezasUsadas = new List<int>();
                string[] piezas = new string[21];
                //Application.Quit();
                int j = 3;
                for (int i = 0; i < 21; i++)
                {
                    piezas[i] = data.Substring(j, 5);
                    j += 5;
                }

                for (int i = 0; i < 21; i++)
                {
                    if (piezas[i] != "11111")
                        piezasUsadas.Add(binarioDecimal(Int32.Parse(piezas[i])));

                }
                GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaPiezasPila>().GenerarPila(piezasUsadas);

            }
            if (PlayerPrefs.GetInt("Jugador", 0) == 0)
                PlayerPrefs.SetInt("Jugador", 1);

            if (PlayerPrefs.GetInt("modo", 0) == 1)
            {
                fichasDer.GetComponent<FichasContrarios>().ActualizarJugadores();
                fichasIzq.GetComponent<FichasContrarios>().ActualizarJugadores();
                fichasFrent.GetComponent<FichasContrarios>().ActualizarJugadores();
            }     
            GameObject.FindGameObjectWithTag("mensaje").GetComponent<MensajesJugadas>().mensaje = "Es tu turno";
            Turno(true);
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

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Jugador", 0);
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
        generadorMano = GameObject.FindGameObjectWithTag("tablero").GetComponent<GeneradorMano>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
