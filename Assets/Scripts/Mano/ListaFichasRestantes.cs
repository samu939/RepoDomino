using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaFichasRestantes : MonoBehaviour
{
    public GameObject[] listaFichasRestantes = new GameObject[21];
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

    public bool Ganada()
    {
        if (CountNotNull() == 0 && generado)
        {
            return true;
        }
        return false;
    }

    public void AgregarFicha(GameObject ficha)
    {
        int index = this.FindFirstNull();
        if (index != 100)
        {
            listaFichasRestantes[index] = ficha;
        }
        
        ArreglarFicha(ficha);
        Instantiate(ficha, new Vector3(EncontrarUltima() + 0.6f,-6.5f,-1), ficha.transform.rotation);

    }

    public float EncontrarUltima(){

        float ultima = 0;
        GameObject[] FichasRestantes = GameObject.FindGameObjectsWithTag("pieza");
        for (int j = 0; j < FichasRestantes.Length; j++)
        {
            if (FichasRestantes[j] != null)
            {
                
                if (FichasRestantes[j].transform.position.x>ultima){
                    ultima = FichasRestantes[j].transform.position.x;
                    
                    }
            }
        }
        return ultima;

    }

    public void ArreglarFicha(GameObject ficha)
    {
        ficha.tag = "pieza";
        ficha.transform.GetChild(0).tag = "jugarIzq";
        ficha.transform.GetChild(1).tag = "jugarDer";
        ficha.transform.GetChild(0).gameObject.SetActive(false);
        ficha.transform.GetChild(1).gameObject.SetActive(false);
        ficha.transform.rotation = new Quaternion(0, 0, 0, 0);
        ficha.GetComponent<BoxCollider2D>().size = new Vector2(4.75f, 8.55f);
        ficha.GetComponent<PiezaDomino>().turno = true;
        ficha.GetComponent<PiezaDomino>().colocada = false;
    }

    public int CountNotNull()
    {
        int i = 0;

        for (int j = 0; j < 21; j++)
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

        for (int j = 0; j < 21; j++)
        {

            if (listaFichasRestantes[j] != null)
            {

                puntos += listaFichasRestantes[j].GetComponent<PiezaDomino>().numeroDer + listaFichasRestantes[j].GetComponent<PiezaDomino>().numeroIzq;
            }
        }

        return puntos;

    }

    public int FindFirstNull()
    {


        for (int j = 0; j < 21; j++)
        {
            if (listaFichasRestantes[j] == null)
            {
                return j;
            }
        }
        return 100;
    }

    public int FindIndex(GameObject ficha)
    {


        for (int j = 0; j < 21; j++)
        {
            if (listaFichasRestantes[j] != null)
            {
                if (ficha.name.Contains(listaFichasRestantes[j].name))
                {
                    return j;
                }
            }
        }
        return 100;
    }

    public void Delete(GameObject ficha)
    {
        int i = 0;
        if (FindIndex(ficha) != 100)
        {

            i = FindIndex(ficha);
            listaFichasRestantes[i] = null;
        }
    }
}
