using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonGenerarMano : MonoBehaviour
{

    public void Generar(){
        GameObject.FindGameObjectWithTag("tablero").GetComponent<GeneradorMano>().GenerarMano();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
