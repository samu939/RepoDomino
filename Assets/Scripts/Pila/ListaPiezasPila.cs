using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaPiezasPila : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] listaFichasPila = new GameObject[14];
    private listaPiezas listaPiezasCompletas;
    
    // Start is called before the first frame update
    void Start()
    {




    }

    public void GenerarPila(List<int> piezasUsadas)
    {
        int i=0;
        int rand;
        listaFichasPila = new GameObject[14];
        listaPiezasCompletas = GameObject.FindGameObjectWithTag("tablero").GetComponent<listaPiezas>();
        List<int> piezasUsadas2= new List<int>();
        for(int j=0; j<piezasUsadas.Count;j++)
            piezasUsadas2.Add(piezasUsadas[j]);
        
        while (i < 14)
         {
             rand = Random.Range(0, listaPiezasCompletas.listaFichasCompleta.Length);
             if (!piezasUsadas2.Contains(rand))
             {
                 listaFichasPila[i]=listaPiezasCompletas.listaFichasCompleta[rand];
                 piezasUsadas2.Add(rand);
                 i++;
             }
         }
         
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public GameObject PiezaRandom(){
        int rand = Random.Range(0, 14);
        while(true){
            if(listaFichasPila[rand]!=null)
                break;
            else
                rand = Random.Range(0, 14);
        }     
        return listaFichasPila[rand];
    }

    public int CountNotNull()
    {
        int i = 0;

        for (int j = 0; j < 14; j++)
        {

            if (listaFichasPila[j] != null)
            {

                i++;
            }
        }
        return i;
    }


    public int FindIndex(GameObject ficha)
    {


        for (int j = 0; j < 14; j++)
        {
            if (listaFichasPila[j] != null)
            {
                if (ficha.name.Contains(listaFichasPila[j].name))
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
            listaFichasPila[i] = null;
        }

    }
}
