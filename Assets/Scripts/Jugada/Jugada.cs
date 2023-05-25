using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugada : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void hacerJugadaIzq(GameObject fichaSeleccionada, bool jugadaPropia)
    {

        if (!FichaYaJugada(fichaSeleccionada))
        {
            this.gameObject.SetActive(false);
            if (jugadaPropia)
            {
                GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaFichasRestantes>().Delete(fichaSeleccionada);
                this.Turno(false);
            }
            else
            {

                fichaSeleccionada.tag = "fichaContrario";
                Instantiate(fichaSeleccionada, fichaSeleccionada.transform.position, fichaSeleccionada.transform.rotation);
                fichaSeleccionada = GameObject.FindGameObjectWithTag("fichaContrario");
            }

            Quaternion rotation = transform.localRotation;
            if (fichaSeleccionada.GetComponent<PiezaDomino>().numeroDer == fichaSeleccionada.GetComponent<PiezaDomino>().numeroIzq)
            {
                rotation.z = 0;
                fichaSeleccionada.transform.GetChild(0).gameObject.SetActive(true);
                fichaSeleccionada.transform.GetChild(0).gameObject.tag = "jugarIzq";
                if(GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaFichasRestantes>())
                GameObject.FindGameObjectWithTag("Comunicacion").GetComponent<EnviarFichaColocada>().ColocarPieza(fichaSeleccionada, 0);
            }
            else
            {
                if (fichaSeleccionada.GetComponent<PiezaDomino>().numeroDer == this.GetComponentInParent<PiezaDomino>().numeroIzq)
                {
                    rotation.z = 1;
                    GameObject.FindGameObjectWithTag("Comunicacion").GetComponent<EnviarFichaColocada>().ColocarPieza(fichaSeleccionada, 0);
                    fichaSeleccionada.transform.GetChild(0).gameObject.SetActive(true);
                    fichaSeleccionada.transform.GetChild(0).gameObject.tag = "jugarIzq";

                }
                else
                {
                    rotation.z = -1;

                    fichaSeleccionada.transform.GetChild(1).gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("Comunicacion").GetComponent<EnviarFichaColocada>().ColocarPieza(fichaSeleccionada, 0);
                    int numeroIzq = fichaSeleccionada.GetComponentInParent<PiezaDomino>().numeroIzq;
                    fichaSeleccionada.GetComponentInParent<PiezaDomino>().numeroIzq = fichaSeleccionada.GetComponentInParent<PiezaDomino>().numeroDer;
                    fichaSeleccionada.GetComponentInParent<PiezaDomino>().numeroDer = numeroIzq;
                    fichaSeleccionada.transform.GetChild(1).gameObject.tag = "jugarIzq";
                    fichaSeleccionada.transform.GetChild(0).gameObject.tag = "jugarDer";

                }
            }
            fichaSeleccionada.transform.localRotation = rotation;

            Vector3 posicionColocada = this.GetComponentInParent<Transform>().position;
            //Debug.Log(posicionColocada);
            posicionColocada.y = 0;
            if (this.GetComponentInParent<Transform>().transform.localRotation.z != 0 && rotation.z == 0 || this.GetComponentInParent<Transform>().transform.localRotation.z == 0)
            {

                posicionColocada.x -= 1f;
            }
            else
            {
                posicionColocada.x -= 1.4f;
            }
            posicionColocada.z = -1;
            fichaSeleccionada.transform.position = posicionColocada;

            fichaSeleccionada.tag = "FichaColocada";
            fichaSeleccionada.GetComponent<PiezaDomino>().colocada = true;
            fichaSeleccionada.GetComponent<BoxCollider2D>().size = Vector2.zero;
            PlayerPrefs.SetInt("Pases", 0);



        }
        else
        {
            GameObject.FindGameObjectWithTag("Comunicacion").GetComponent<RS232>().Send("010");
            GameObject.FindGameObjectWithTag("mensaje").GetComponent<MensajesJugadas>().mensaje = "";
        }



    }

    public void hacerJugadaDer(GameObject fichaSeleccionada, bool jugadaPropia)
    {
        if (!FichaYaJugada(fichaSeleccionada))
        {
            this.gameObject.SetActive(false);
            if (jugadaPropia)
            {

                GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaFichasRestantes>().Delete(fichaSeleccionada);
                this.Turno(false);
            }
            else
            {

                fichaSeleccionada.tag = "fichaContrario";
                Instantiate(fichaSeleccionada, fichaSeleccionada.transform.position, fichaSeleccionada.transform.rotation);
                fichaSeleccionada = GameObject.FindGameObjectWithTag("fichaContrario");
            }

            Quaternion rotation = transform.localRotation;
            if (fichaSeleccionada.GetComponent<PiezaDomino>().numeroDer == fichaSeleccionada.GetComponent<PiezaDomino>().numeroIzq)
            {
                rotation.z = 0;
                fichaSeleccionada.transform.GetChild(1).gameObject.SetActive(true);
                fichaSeleccionada.transform.GetChild(1).gameObject.tag = "jugarDer";
                GameObject.FindGameObjectWithTag("Comunicacion").GetComponent<EnviarFichaColocada>().ColocarPieza(fichaSeleccionada, 1);
            }
            else
            {
                if (fichaSeleccionada.GetComponent<PiezaDomino>().numeroDer == this.GetComponentInParent<PiezaDomino>().numeroDer)
                {

                    rotation.z = -1;
                    GameObject.FindGameObjectWithTag("Comunicacion").GetComponent<EnviarFichaColocada>().ColocarPieza(fichaSeleccionada, 1);
                    fichaSeleccionada.transform.GetChild(0).gameObject.SetActive(true);
                    int numeroIzq = fichaSeleccionada.GetComponentInParent<PiezaDomino>().numeroIzq;
                    fichaSeleccionada.GetComponentInParent<PiezaDomino>().numeroIzq = fichaSeleccionada.GetComponentInParent<PiezaDomino>().numeroDer;
                    fichaSeleccionada.GetComponentInParent<PiezaDomino>().numeroDer = numeroIzq;
                    fichaSeleccionada.transform.GetChild(1).gameObject.tag = "jugarIzq";
                    fichaSeleccionada.transform.GetChild(0).gameObject.tag = "jugarDer";

                }
                else
                {
                    GameObject.FindGameObjectWithTag("Comunicacion").GetComponent<EnviarFichaColocada>().ColocarPieza(fichaSeleccionada, 1);
                    rotation.z = 1;
                    fichaSeleccionada.transform.GetChild(1).gameObject.SetActive(true);
                    fichaSeleccionada.transform.GetChild(1).gameObject.tag = "jugarDer";

                }
            }
            fichaSeleccionada.transform.localRotation = rotation;
            Vector3 posicionColocada = this.GetComponentInParent<Transform>().transform.position;
            posicionColocada.y = 0;
            if (this.GetComponentInParent<Transform>().transform.localRotation.z != 0 && rotation.z == 0 || this.GetComponentInParent<Transform>().transform.localRotation.z == 0)
                posicionColocada.x += 1f;
            else
                posicionColocada.x += 1.37f;
            posicionColocada.z = -1;
            fichaSeleccionada.transform.position = posicionColocada;
            fichaSeleccionada.tag = "FichaColocada";
            fichaSeleccionada.GetComponent<PiezaDomino>().colocada = true;
            fichaSeleccionada.GetComponent<BoxCollider2D>().size = Vector2.zero;
            PlayerPrefs.SetInt("Pases", 0);

        }
        else
        {
            GameObject.FindGameObjectWithTag("Comunicacion").GetComponent<RS232>().Send("010");
            GameObject.FindGameObjectWithTag("mensaje").GetComponent<MensajesJugadas>().mensaje = "";
        }



    }

    public bool FichaYaJugada(GameObject ficha)
    {
        GameObject[] listaFichasMesa = new GameObject[28];
        listaFichasMesa = GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaPiezasMesa>().listaFichasMesa;
        for (int i = 0; i < listaFichasMesa.Length; i++)
        {

            if (listaFichasMesa[i].name.Contains(ficha.name))
            {

                return true;
            }
        }
        return false;
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
