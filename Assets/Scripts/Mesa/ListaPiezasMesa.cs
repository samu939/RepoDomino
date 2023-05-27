using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaPiezasMesa : MonoBehaviour
{
    public GameObject[] listaFichasMesa = new GameObject[25];
    public int Fichas0 = 0;
    public int Fichas1 = 0;
    public int Fichas2 = 0;
    public int Fichas3 = 0;
    public int Fichas4 = 0;
    public int Fichas5 = 0;
    public int Fichas6 = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        listaFichasMesa = GameObject.FindGameObjectsWithTag("FichaColocada");
    }

    public bool Trancada()
    {
        Fichas0 = 0; Fichas1 = 0; Fichas2 = 0; Fichas3 = 0; Fichas4 = 0; Fichas5 = 0; Fichas6 = 0;
        for (int i = 0; i < listaFichasMesa.Length; i++)
        {

            if (listaFichasMesa[i].GetComponent<PiezaDomino>().numeroIzq == 0 || listaFichasMesa[i].GetComponent<PiezaDomino>().numeroDer == 0)
            {
                Fichas0++;
            }
            if (listaFichasMesa[i].GetComponent<PiezaDomino>().numeroIzq == 1 || listaFichasMesa[i].GetComponent<PiezaDomino>().numeroDer == 1)
            {
                Fichas1++;
            }
            if (listaFichasMesa[i].GetComponent<PiezaDomino>().numeroIzq == 2 || listaFichasMesa[i].GetComponent<PiezaDomino>().numeroDer == 2)
            {
                Fichas2++;
            }
            if (listaFichasMesa[i].GetComponent<PiezaDomino>().numeroIzq == 3 || listaFichasMesa[i].GetComponent<PiezaDomino>().numeroDer == 3)
            {
                Fichas3++;
            }
            if (listaFichasMesa[i].GetComponent<PiezaDomino>().numeroIzq == 4 || listaFichasMesa[i].GetComponent<PiezaDomino>().numeroDer == 4)
            {
                Fichas4++;
            }
            if (listaFichasMesa[i].GetComponent<PiezaDomino>().numeroIzq == 5 || listaFichasMesa[i].GetComponent<PiezaDomino>().numeroDer == 5)
            {
                Fichas5++;
            }
            if (listaFichasMesa[i].GetComponent<PiezaDomino>().numeroIzq == 6 || listaFichasMesa[i].GetComponent<PiezaDomino>().numeroDer == 6)
            {
                Fichas6++;
            }


        }

        if (Fichas0 == 7 || Fichas1 == 7 || Fichas2 == 7 || Fichas3 == 7 || Fichas4 == 7 || Fichas5 == 7 || Fichas6 == 7)
            return true;

        return false;
    }

}
