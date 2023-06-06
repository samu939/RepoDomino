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

    public void hacerJugada(GameObject fichaSeleccionada, bool jugadaPropia, int jugador)
    {

        if (fichaSeleccionada.GetComponent<PiezaDomino>().numeroIzq == 6 && fichaSeleccionada.GetComponent<PiezaDomino>().numeroDer == 6 ||
            (PlayerPrefs.GetInt("puntosEquipo1", 0) > 0 || PlayerPrefs.GetInt("puntosEquipo2", 0) > 0) ||
            PlayerPrefs.GetInt("modo", 0) == 2)
        {
            if (jugadaPropia)
            {
                GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaFichasRestantes>().Delete(fichaSeleccionada);
                this.Turno(false);
            }
            else
            {
                if (PlayerPrefs.GetInt("modo", 0) == 2)
                {
                    GameObject.FindGameObjectWithTag("FichasJug3").GetComponent<FichasContrarios>().cantFichas--;
                }
                else
                {
                    switch (jugador)
                    {
                        case 1: GameObject.FindGameObjectWithTag("FichasJug1").GetComponent<FichasContrarios>().cantFichas--; break;

                        case 2: GameObject.FindGameObjectWithTag("FichasJug2").GetComponent<FichasContrarios>().cantFichas--; break;

                        case 3: GameObject.FindGameObjectWithTag("FichasJug3").GetComponent<FichasContrarios>().cantFichas--; break;

                        case 4: GameObject.FindGameObjectWithTag("FichasJug4").GetComponent<FichasContrarios>().cantFichas--; break;
                    }
                }

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
