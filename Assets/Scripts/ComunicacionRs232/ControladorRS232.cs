using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorRS232 : MonoBehaviour
{
    public void ReadController()
    {

        string data = "";

        data = this.gameObject.GetComponent<RS232>().input;

        
        if (data.Length > 2)
        {
            
            switch (data.Substring(0, 3))
            {

                case "000":
                    
                    this.gameObject.GetComponent<RecibirPiezasEscogidas>().PiezasYaEscogidas(data);
                    break;
                case "001":

                    this.gameObject.GetComponent<ColocarPiezaOtro>().ColocarPieza(data);

                    break;
                case "010":
                    this.Turno(true);
                    GameObject.FindGameObjectWithTag("mensaje").GetComponent<MensajesJugadas>().mensaje = "Es tu turno";
                    break;
                case "011":
                    this.gameObject.GetComponent<RecibirPase>().RecibirPasar(data);
                    break;
                case "100":
                    this.gameObject.GetComponent<RecibirVictoria>().Victoria(data);
                    break;
                case "101":
                    this.gameObject.GetComponent<RecibirTranca>().Tranca(data);
                    break;
                case "110":
                    this.gameObject.GetComponent<RecibirPuntuacion>().Puntos(data);
                    break;
                case "111":
                    this.gameObject.GetComponent<RecibirAgarrarPila>().AgarrarPila(data);
                    break;

            }
        }
        
        this.gameObject.GetComponent<RS232>().input = "";
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

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ReadController();
    }
}
