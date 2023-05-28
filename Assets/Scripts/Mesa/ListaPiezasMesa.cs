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

        if (GameObject.FindGameObjectWithTag("jugarDer") != null && GameObject.FindGameObjectWithTag("jugarIzq") != null)
        {
            int fichaDer = GameObject.FindGameObjectWithTag("jugarDer").GetComponentInParent<PiezaDomino>().numeroDer;
            int fichaIzq = GameObject.FindGameObjectWithTag("jugarIzq").GetComponentInParent<PiezaDomino>().numeroIzq;


            if ((Fichas0 == 7 && (fichaIzq == 0 && fichaDer == 0)) || (Fichas1 == 7 && (fichaIzq == 1 && fichaDer == 1)) ||
                (Fichas2 == 7 && (fichaIzq == 2 && fichaDer == 2)) || (Fichas3 == 7 && (fichaIzq == 3 && fichaDer == 3)) ||
                (Fichas4 == 7 && (fichaIzq == 4 && fichaDer == 4)) || (Fichas5 == 7 && (fichaIzq == 5 && fichaDer == 5)) ||
                (Fichas6 == 7 && (fichaIzq == 6 && fichaDer == 6)))
                return true;
        }

        return false;
    }

}
