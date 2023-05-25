using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaPiezasMesa : MonoBehaviour
{
    public GameObject[] listaFichasMesa = new GameObject[25];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        listaFichasMesa = GameObject.FindGameObjectsWithTag("FichaColocada");
    }
}
