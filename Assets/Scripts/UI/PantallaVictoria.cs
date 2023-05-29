using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PantallaVictoria : MonoBehaviour
{
    private TextMeshProUGUI textMesh1;
    private TextMeshProUGUI textMesh2;
    private GameObject reiniciar;
    private GameObject salir;
    // Start is called before the first frame update
    void Start()
    {
        textMesh1 = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        textMesh2 = this.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        reiniciar = this.transform.GetChild(2).gameObject;
        salir = this.transform.GetChild(3).gameObject;
    }

    public void Salir()
    {
        Application.Quit();
    }   

    public void Reiniciar()
    {
        SceneManager.LoadScene("SampleScene");
    }
    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("puntosEquipo1", 0)>=100 || PlayerPrefs.GetInt("puntosEquipo2", 0)>=100){

            reiniciar.SetActive(false);
            salir.SetActive(true);

        }else{
            reiniciar.SetActive(true);
            salir.SetActive(false);
        }

        textMesh1.text = "Equipo 1: " + PlayerPrefs.GetInt("puntosEquipo1", 0).ToString("0");
        textMesh2.text = "Equipo 2: " + PlayerPrefs.GetInt("puntosEquipo2", 0).ToString("0");
    }
}
