using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PantallaVictoria : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void Reiniciar()
    {
        int i = PlayerPrefs.GetInt("puntuacion", 0);
        SceneManager.LoadScene("SampleScene");
        PlayerPrefs.SetInt("puntuacion", i + 1);
    }
    // Update is called once per frame
    void Update()
    {
        textMesh.text = "Victorias: " + PlayerPrefs.GetInt("puntuacion", 0).ToString("0");
    }
}
