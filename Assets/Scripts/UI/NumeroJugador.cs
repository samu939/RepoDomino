using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NumeroJugador : MonoBehaviour
{
    private TextMeshProUGUI textMesh1;
    // Start is called before the first frame update
    void Start()
    {
        textMesh1 = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("modo", 0) == 2)
            textMesh1.text = "Pila= "+ GameObject.FindGameObjectWithTag("tablero").GetComponent<ListaPiezasPila>().CountNotNull();
        else
            textMesh1.text = "Jugador " + PlayerPrefs.GetInt("Jugador", 0).ToString("0");
    }
}
