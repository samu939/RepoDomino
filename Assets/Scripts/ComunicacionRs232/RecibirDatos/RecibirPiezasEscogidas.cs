using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecibirPiezasEscogidas : MonoBehaviour
{
    GeneradorMano generadorMano;
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

                switch (piezas[i])
                {
                    case "00000": piezasUsadas.Add(0); break;
                    case "00001": piezasUsadas.Add(1); break;
                    case "00010": piezasUsadas.Add(2); break;
                    case "00011": piezasUsadas.Add(3); break;
                    case "00100": piezasUsadas.Add(4); break;
                    case "00101": piezasUsadas.Add(5); break;
                    case "00110": piezasUsadas.Add(6); break;
                    case "00111": piezasUsadas.Add(7); break;
                    case "01000": piezasUsadas.Add(8); break;
                    case "01001": piezasUsadas.Add(9); break;
                    case "01010": piezasUsadas.Add(10); break;
                    case "01011": piezasUsadas.Add(11); break;
                    case "01100": piezasUsadas.Add(12); break;
                    case "01101": piezasUsadas.Add(13); break;
                    case "01110": piezasUsadas.Add(14); break;
                    case "01111": piezasUsadas.Add(15); break;
                    case "10000": piezasUsadas.Add(16); break;
                    case "10001": piezasUsadas.Add(17); break;
                    case "10010": piezasUsadas.Add(18); break;
                    case "10011": piezasUsadas.Add(19); break;
                    case "10100": piezasUsadas.Add(20); break;
                    case "10101": piezasUsadas.Add(21); break;
                    case "10110": piezasUsadas.Add(22); break;
                    case "10111": piezasUsadas.Add(23); break;
                    case "11000": piezasUsadas.Add(24); break;
                    case "11001": piezasUsadas.Add(25); break;
                    case "11010": piezasUsadas.Add(26); break;
                    case "11011": piezasUsadas.Add(27); break;

                }



            }
            if (j == 0  && PlayerPrefs.GetInt("Jugador", 0) == 0)
                PlayerPrefs.SetInt("Jugador", 4);
            if (j == 7 && PlayerPrefs.GetInt("Jugador", 0) == 0)
                PlayerPrefs.SetInt("Jugador", 3);
            if (j == 14 && PlayerPrefs.GetInt("Jugador", 0) == 0)
                PlayerPrefs.SetInt("Jugador", 2);
            GameObject.FindGameObjectWithTag("tablero").GetComponent<GeneradorMano>().piezasUsadas = piezasUsadas;
            GameObject.FindGameObjectWithTag("tablero").GetComponent<GeneradorMano>().GenerarMano();
        }
        else
        {
            if (PlayerPrefs.GetInt("Jugador", 0) == 0)
                PlayerPrefs.SetInt("Jugador", 1);
            GameObject.FindGameObjectWithTag("mensaje").GetComponent<MensajesJugadas>().mensaje = "Es tu turno";
            Turno(true);
        }

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
