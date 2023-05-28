using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaFichasRestantes : MonoBehaviour
{
    public GameObject[] listaFichasRestantes = new GameObject[7];
    private bool generado = false;
    
    // Start is called before the first frame update
    void Start()
    {




    }

    public void Generado()
    {
        listaFichasRestantes = this.GetComponent<GeneradorMano>().mano;

        generado = true;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public bool Ganada(){
        if (CountNotNull() == 0 && generado)
        {
            return true;        
        }
        return false;
    }

    public int CountNotNull()
    {
        int i = 0;

        for (int j = 0; j < 7; j++)
        {

            if (listaFichasRestantes[j] != null)
            {

                i++;
            }
        }
        return i;
    }

    public int conteoPuntos()
    {
        int puntos = 0;

        for (int j = 0; j < 7; j++)
        {

            if (listaFichasRestantes[j] != null)
            {

                puntos += listaFichasRestantes[j].GetComponent<PiezaDomino>().numeroDer + listaFichasRestantes[j].GetComponent<PiezaDomino>().numeroIzq;
            }
        }

        return puntos;

    }

    public int FindIndex(GameObject ficha)
    {


        for (int j = 0; j < 7; j++)
        {
            if (listaFichasRestantes[j] != null)
            {
                if (ficha.name.Contains(listaFichasRestantes[j].name))
                {
                    return j;
                }
            }
        }
        return 10;
    }

    public void Delete(GameObject ficha)
    {
        int i = 0;
        if (FindIndex(ficha) != 10)
        {

            i = FindIndex(ficha);
            listaFichasRestantes[i] = null;
        }

    }
}
