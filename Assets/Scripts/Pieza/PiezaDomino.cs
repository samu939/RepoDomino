using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaDomino : MonoBehaviour
{

    public int numeroIzq;
    public int numeroDer;
    public bool turno;
    public bool colocada = false;
    private string nombre;


    public float dragSpeed = 100f;

    private Vector3 mouseDownPosition;
    private Vector3 newPosition;
    public Vector3 initialPosition;
    private bool isDragging;
    private Camera gameCamera = null;

    private bool CanPlay()
    {

        return false;

    }

    public void ShowBorder(bool show)
    {
        if (GameObject.FindGameObjectWithTag("inicio1") == null)
        {
            if (this.numeroDer == GameObject.FindGameObjectWithTag("jugarIzq").GetComponentInParent<PiezaDomino>().numeroIzq || this.numeroIzq == GameObject.FindGameObjectWithTag("jugarIzq").GetComponentInParent<PiezaDomino>().numeroIzq)
            {
                if (GameObject.FindGameObjectWithTag("jugarIzq").transform.parent.transform.GetChild(2).gameObject.tag == "bordeIzq")
                    GameObject.FindGameObjectWithTag("jugarIzq").transform.parent.transform.GetChild(2).gameObject.SetActive(show);
                else
                    GameObject.FindGameObjectWithTag("jugarIzq").transform.parent.transform.GetChild(3).gameObject.SetActive(show);
            }

            if (this.numeroDer == GameObject.FindGameObjectWithTag("jugarDer").GetComponentInParent<PiezaDomino>().numeroDer || this.numeroIzq == GameObject.FindGameObjectWithTag("jugarDer").GetComponentInParent<PiezaDomino>().numeroDer)
            {

                if (GameObject.FindGameObjectWithTag("jugarDer").transform.parent.transform.GetChild(2).gameObject.tag == "bordeIzq")
                    GameObject.FindGameObjectWithTag("jugarDer").transform.parent.transform.GetChild(3).gameObject.SetActive(show);
                else
                    GameObject.FindGameObjectWithTag("jugarDer").transform.parent.transform.GetChild(2).gameObject.SetActive(show);
            }
        }
    }

    void OnMouseDown()
    {
        if (turno)
        {

            isDragging = true;
            ShowBorder(true);
        }
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            if (turno && !colocada)
            {

                if (transform.position.x > gameCamera.transform.position.x - 17.7 && transform.position.x < gameCamera.transform.position.x + 17.7 &&
                    transform.position.y > gameCamera.transform.position.y - 8.3 && transform.position.y < gameCamera.transform.position.y + 8.3)
                {

                    newPosition = gameCamera.ScreenToWorldPoint(Input.mousePosition);
                    newPosition.z = -1;
                    transform.position = newPosition;
                }
                else
                {
                    isDragging = false;
                    if (transform.position.x <= gameCamera.transform.position.x - 17.7)
                        transform.position = new Vector3(gameCamera.transform.position.x - 17.5f, transform.position.y, -1);
                    if (transform.position.x >= gameCamera.transform.position.x + 17.7)
                        transform.position = new Vector3(gameCamera.transform.position.x + 17.5f, transform.position.y, 0);
                    if (transform.position.y <= gameCamera.transform.position.y - 8.3)
                        transform.position = new Vector3(transform.position.x, gameCamera.transform.position.y - 8.22f, 0);
                    if (transform.position.y >= gameCamera.transform.position.y + 8.3)
                        transform.position = new Vector3(transform.position.x, gameCamera.transform.position.y + 8.22f, 0);
                }
            }
        }
    }


    void OnMouseUp()
    {

        if (turno)
        {
            isDragging = false;
            ShowBorder(false);
            //transform.position = initialPosition;
        }
    }

    void Start()
    {

        gameCamera = Camera.main;

        initialPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("inicio1"))
        {
            ShowBorder(false);
            collision.GetComponent<PrimeraJugada>().hacerJugada(this.gameObject, true, 0);

        }
        if (collision.CompareTag("jugarIzq"))
        {
            if (this.numeroDer == collision.GetComponentInParent<PiezaDomino>().numeroIzq || this.numeroIzq == collision.GetComponentInParent<PiezaDomino>().numeroIzq)
            {
                ShowBorder(false);
                collision.GetComponent<Jugada>().hacerJugadaIzq(this.gameObject, true, 0);

            }
        }
        if (collision.CompareTag("jugarDer"))
        {
            if (this.numeroDer == collision.GetComponentInParent<PiezaDomino>().numeroDer || this.numeroIzq == collision.GetComponentInParent<PiezaDomino>().numeroDer)
            {
                ShowBorder(false);
                collision.GetComponent<Jugada>().hacerJugadaDer(this.gameObject, true, 0);

            }
        }
    }

}
