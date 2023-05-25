using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMover : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public GameObject[] ficha;

    private void Start()
    {
        
    }
    void Update()
    {
        ficha = GameObject.FindGameObjectsWithTag("pieza");
        
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x<26)
        {
            for(int i = 0; i < ficha.Length; i++)
            {
                ficha[i].transform.Translate(speed * Time.deltaTime, 0, 0);
                ficha[i].GetComponent<PiezaDomino>().initialPosition += new Vector3(speed * Time.deltaTime, 0, 0);
                
            }
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -26)
        {
            for (int i = 0; i < ficha.Length; i++)
            {
                ficha[i].transform.Translate(-speed * Time.deltaTime, 0, 0);
                ficha[i].GetComponent<PiezaDomino>().initialPosition += new Vector3(-speed * Time.deltaTime, 0, 0);
            }
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
    }
}
