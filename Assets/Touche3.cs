using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touche3 : MonoBehaviour
{
    public Color tuileColor;
    public Color pressedColor;
    public int number;
    public MainMenu demo;
    //bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (!isPlaying)
        float i;
        if (collision.transform.gameObject.transform.localScale.x == 0.1f)
        {
            i = collision.transform.gameObject.GetComponent<SpriteRenderer>().color.r;
        }
        else
        {
            i = collision.transform.gameObject.GetComponent<SpriteRenderer>().color.b;
        }
        demo.OnTuileEnter(number, i);
        GetComponent<SpriteRenderer>().color = tuileColor;
        //isPlaying = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        demo.OnTuileExit(number);
        GetComponent<SpriteRenderer>().color = Color.clear;
        //isPlaying = false;
    }*/
    public void Pressed()
    {
        GetComponent<SpriteRenderer>().color = pressedColor;
    }
}
