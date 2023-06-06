using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FichasContrarios : MonoBehaviour
{
    private TextMeshProUGUI textMesh1;
    public int cantFichas = 7;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("modo", 0) == 2)
        {
            if (this.CompareTag("FichasJug2"))
                this.gameObject.SetActive(false);
            if (this.CompareTag("FichasJug4"))
                this.gameObject.SetActive(false);
        }
        
        textMesh1 = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void ActualizarJugadores()
    {
        if (PlayerPrefs.GetInt("modo", 0) == 1)
        {
            Debug.Log(PlayerPrefs.GetInt("Jugador", 0));
            Debug.Log(this.gameObject.tag);
            switch (PlayerPrefs.GetInt("Jugador", 0))
            {

                case 2:
                    if (this.CompareTag("FichasJug2"))
                        this.gameObject.tag = "FichasJug3";
                    else if (this.CompareTag("FichasJug3"))
                        this.gameObject.tag = "FichasJug4";
                    else if (this.CompareTag("FichasJug4"))
                        this.gameObject.tag = "FichasJug1";

                    break;
                case 3:
                    if (this.CompareTag("FichasJug2"))
                        this.gameObject.tag = "FichasJug4";
                    else if (this.CompareTag("FichasJug3"))
                        this.gameObject.tag = "FichasJug1";
                    else if (this.CompareTag("FichasJug4"))
                        this.gameObject.tag = "FichasJug2";

                    break;
                case 4:
                    if (this.CompareTag("FichasJug2"))
                        this.gameObject.tag = "FichasJug1";
                    else if (this.CompareTag("FichasJug3"))
                        this.gameObject.tag = "FichasJug2";
                    else if (this.CompareTag("FichasJug4"))
                        this.gameObject.tag = "FichasJug3";

                    break;
            }
            Debug.Log("luego: "+this.gameObject.tag);
        }
    }

    // Update is called once per frame
    void Update()
    {

        textMesh1.text = cantFichas + " Fichas";

    }
}
