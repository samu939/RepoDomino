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
        SceneManager.UnloadSceneAsync("SampleScene");
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("puntosEquipo1", 0);
        PlayerPrefs.SetInt("puntosEquipo2", 0);
        PlayerPrefs.SetInt("Jugador", 0);
    }

    public void Reiniciar()
    {
        if (PlayerPrefs.GetInt("puntosEquipo1", 0) >= 100 || PlayerPrefs.GetInt("puntosEquipo2", 0) >= 100)
        {
            PlayerPrefs.SetInt("puntosEquipo1", 0);
            PlayerPrefs.SetInt("puntosEquipo2", 0);
            PlayerPrefs.SetInt("Jugador", 0);
        }
        SceneManager.LoadScene("SampleScene");
    }
    // Update is called once per frame
    void Update()
    {


        textMesh1.text = "Equipo 1: " + PlayerPrefs.GetInt("puntosEquipo1", 0).ToString("0");
        textMesh2.text = "Equipo 2: " + PlayerPrefs.GetInt("puntosEquipo2", 0).ToString("0");
    }
}
