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

    // Update is called once per frame
    void Update()
    {

        textMesh1.text = cantFichas + " Fichas";

    }
}
