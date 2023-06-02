using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
   
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
        SceneManager.UnloadSceneAsync("SampleScene");
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("puntosEquipo1", 0);
        PlayerPrefs.SetInt("puntosEquipo2", 0);
        PlayerPrefs.SetInt("Jugador", 0);
    }   
    public void Pause()
    {  
            
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        
        
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        
    }
}
