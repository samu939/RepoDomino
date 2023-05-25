using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MensajesJugadas : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    public string mensaje;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = mensaje;
    }
}
