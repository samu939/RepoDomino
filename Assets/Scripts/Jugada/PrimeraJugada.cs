using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimeraJugada : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {




    }

    public void hacerJugada(GameObject fichaSeleccionada, bool jugadaPropia)
    {


        if (jugadaPropia)
        {
            GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaFichasRestantes>().Delete(fichaSeleccionada);
            this.Turno(false);
        }
        else
        {
            fichaSeleccionada.transform.GetChild(0).tag = "jugarIzq";
            fichaSeleccionada.transform.GetChild(1).tag = "jugarDer";
            fichaSeleccionada.tag = "fichaContrario";
            Instantiate(fichaSeleccionada, fichaSeleccionada.transform.position, fichaSeleccionada.transform.rotation);
            fichaSeleccionada = GameObject.FindGameObjectWithTag("fichaContrario");
        }



        Quaternion rotation = transform.localRotation;
        if (fichaSeleccionada.GetComponent<PiezaDomino>().numeroDer == fichaSeleccionada.GetComponent<PiezaDomino>().numeroIzq)
        {
            rotation.z = 0;
        }
        else
            rotation.z = 1;

        fichaSeleccionada.transform.localRotation = rotation;
        Vector3 posicionColocada = Vector3.zero;
        posicionColocada.z = -1;
        fichaSeleccionada.transform.position = posicionColocada;
        fichaSeleccionada.transform.GetChild(0).gameObject.SetActive(true);
        fichaSeleccionada.transform.GetChild(1).gameObject.SetActive(true);
        fichaSeleccionada.tag = "FichaColocada";
        GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaPiezasMesa>().ActualizarLista();
        fichaSeleccionada.GetComponent<PiezaDomino>().colocada = true;
        fichaSeleccionada.GetComponent<BoxCollider2D>().size = Vector2.zero;

        GameObject.FindGameObjectWithTag("Comunicacion").GetComponent<EnviarFichaColocada>().ColocarPieza(fichaSeleccionada, 2);
        this.gameObject.SetActive(false);
        PlayerPrefs.SetInt("Pases", 0);
    }

    
    public void Turno(bool turno)
    {
        GameObject[] listaFichasRestantes = GameObject.FindGameObjectsWithTag("pieza");
        for (int j = 0; j < listaFichasRestantes.Length; j++)
        {

            listaFichasRestantes[j].GetComponent<PiezaDomino>().turno = turno;

        }
    }



}
