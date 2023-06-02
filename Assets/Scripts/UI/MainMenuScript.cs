using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Salir()
    {
        Application.Quit();
        
    }

    public void Jugar(int modo){
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadScene("SampleScene");
        PlayerPrefs.SetInt("modo",modo);
    }
}
