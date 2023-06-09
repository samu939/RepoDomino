using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMano : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] mano= new GameObject[21];
    private listaPiezas listaPiezasCompletas;
    public List<int> piezasUsadas = new List<int>();
    private int rand;
    private int i = 0;
    public float initialPositionFicha;
    private Vector3 posicionPieza;
    private void Start()
    {

        

    }

    public void GenerarMano()
    {
        listaPiezasCompletas = GameObject.FindGameObjectWithTag("tablero").GetComponent<listaPiezas>();
        GameObject.FindGameObjectWithTag("inicio1").SetActive(true);
        while (i < 7)
         {
             rand = Random.Range(0, listaPiezasCompletas.listaFichasCompleta.Length);
             if (!piezasUsadas.Contains(rand))
             {
                 mano[i]=listaPiezasCompletas.listaFichasCompleta[rand];
                 this.ArreglarFicha(mano[i]);
                 piezasUsadas.Add(rand);
                 i++;
             }
         }
        
        /*mano[0] = listaPiezasCompletas.listaFichasCompleta[1];
        mano[1] = listaPiezasCompletas.listaFichasCompleta[2];
        mano[2] = listaPiezasCompletas.listaFichasCompleta[3];
        mano[3] = listaPiezasCompletas.listaFichasCompleta[0];
        mano[4] = listaPiezasCompletas.listaFichasCompleta[14];
        mano[5] = listaPiezasCompletas.listaFichasCompleta[15];
        mano[6] = listaPiezasCompletas.listaFichasCompleta[18];
        piezasUsadas.Add(1);
        piezasUsadas.Add(2);
        piezasUsadas.Add(3);
        piezasUsadas.Add(0);
        piezasUsadas.Add(14);
        piezasUsadas.Add(15);
        piezasUsadas.Add(18);
        mano[0].tag = "pieza";
        mano[0].transform.GetChild(0).tag = "jugarIzq";
        mano[0].transform.GetChild(1).tag = "jugarDer";
        mano[1].tag = "pieza";
        mano[1].transform.GetChild(0).tag = "jugarIzq";
        mano[1].transform.GetChild(1).tag = "jugarDer";
        mano[2].tag = "pieza";
        mano[2].transform.GetChild(0).tag = "jugarIzq";
        mano[2].transform.GetChild(1).tag = "jugarDer";
        mano[3].tag = "pieza";
        mano[3].transform.GetChild(0).tag = "jugarIzq";
        mano[3].transform.GetChild(1).tag = "jugarDer";
        mano[4].tag = "pieza";
        mano[4].transform.GetChild(0).tag = "jugarIzq";
        mano[4].transform.GetChild(1).tag = "jugarDer";
        mano[5].tag = "pieza";
        mano[5].transform.GetChild(0).tag = "jugarIzq";
        mano[5].transform.GetChild(1).tag = "jugarDer";
        mano[6].tag = "pieza";
        mano[6].transform.GetChild(0).tag = "jugarIzq";
        mano[6].transform.GetChild(1).tag = "jugarDer";*/
        this.gameObject.GetComponent<ListaFichasRestantes>().Generado();
    
        if(PlayerPrefs.GetInt("modo",0)==2)
            GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaPiezasPila>().GenerarPila(piezasUsadas);
        
        GameObject.FindGameObjectWithTag("Comunicacion").GetComponent<EnviaFichasAgarradas>().EnviarFichasAgarradas(); 
        GameObject.FindGameObjectWithTag("botonGenerar").SetActive(false);
        Invoke("crearMano", 0);
    }

    public void ArreglarFicha(GameObject ficha)
    {
        ficha.tag = "pieza";
        ficha.transform.GetChild(0).tag = "jugarIzq";
        ficha.transform.GetChild(1).tag = "jugarDer";
        ficha.transform.GetChild(3).gameObject.tag="bordeDer";
        ficha.transform.GetChild(2).gameObject.tag="bordeIzq";
        
        ficha.transform.GetChild(0).gameObject.SetActive(false);
        ficha.transform.GetChild(1).gameObject.SetActive(false);
        ficha.transform.GetChild(2).gameObject.SetActive(false);
        ficha.transform.GetChild(3).gameObject.SetActive(false);
        ficha.transform.rotation = new Quaternion(0, 0, 0, 0);
        ficha.GetComponent<BoxCollider2D>().size = new Vector2(4.75f, 8.55f);
        ficha.GetComponent<PiezaDomino>().turno = false;
        ficha.GetComponent<PiezaDomino>().colocada = false;
    }

    private void Update()
    {

    }
    public void crearMano()
    {
        i = 0;
        posicionPieza.y = -6.5f;
        posicionPieza.z = -1;
        while (i < 7)
        {
            posicionPieza.x = -initialPositionFicha + (((initialPositionFicha * 2) / 6) * i);

            Instantiate(mano[i], posicionPieza, mano[i].transform.rotation);
            i++;
        }
    }

    public void deleteFromMano()
    {

    }

}
