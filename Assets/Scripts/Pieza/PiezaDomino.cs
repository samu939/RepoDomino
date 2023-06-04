using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaDomino : MonoBehaviour
{

    public int numeroIzq;
    public int numeroDer;
    public bool turno;
    public bool colocada=false;
    private string nombre;
    
    
    public float dragSpeed = 100f;

    private Vector3 mouseDownPosition;
    private Vector3 newPosition;
    public Vector3 initialPosition;
    private bool isDragging;
    private Camera gameCamera = null;

    void OnMouseDown()
    {
        if (turno) { 
            
            isDragging = true;
        }
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            if (turno && !colocada)
            {
                
                if(transform.position.x>gameCamera.transform.position.x-17.7 && transform.position.x < gameCamera.transform.position.x + 17.7 &&
                    transform.position.y > gameCamera.transform.position.y - 8.3 && transform.position.y < gameCamera.transform.position.y + 8.3) { 

                    newPosition = gameCamera.ScreenToWorldPoint(Input.mousePosition); 
                    newPosition.z = -1;
                    transform.position = newPosition;
                }
                else
                {
                    isDragging = false;
                    if(transform.position.x <= gameCamera.transform.position.x - 17.7)
                        transform.position = new Vector3 (gameCamera.transform.position.x - 17.5f,transform.position.y,-1);
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
            collision.GetComponent<PrimeraJugada>().hacerJugada(this.gameObject,true,0);
            
        }
        if (collision.CompareTag("jugarIzq"))
        {
            if(this.numeroDer == collision.GetComponentInParent<PiezaDomino>().numeroIzq || this.numeroIzq == collision.GetComponentInParent<PiezaDomino>().numeroIzq)
            {
                collision.GetComponent<Jugada>().hacerJugadaIzq(this.gameObject,true,0);
            }
        }
        if (collision.CompareTag("jugarDer"))
        {
            if (this.numeroDer == collision.GetComponentInParent<PiezaDomino>().numeroDer || this.numeroIzq == collision.GetComponentInParent<PiezaDomino>().numeroDer)
            {
                collision.GetComponent<Jugada>().hacerJugadaDer(this.gameObject,true,0);
            }
        }
    }

}
