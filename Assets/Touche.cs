using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touche : MonoBehaviour
{
    public Color tuileColor;
    public Color pressedColor;
    public int number;
    public DemoScript demo;
    public bool type;
    public bool isTuiled;
    public bool isPressed;
    //bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (demo.isTraining && !isPressed && GetComponent<SpriteRenderer>().color == Color.yellow)
        {
            GetComponent<SpriteRenderer>().color = Color.clear;
        }
        /*if(!isTuiled && !isPressed)
        {
            GetComponent<SpriteRenderer>().color = Color.clear;
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Tuile")
        {
            isTuiled = false;
            demo.OnTuileExit(number);
            GetComponent<SpriteRenderer>().color = Color.clear;
            //isPlaying = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tuile")
        {
            isTuiled = true;
            //if (!isPlaying)
            float i;
            if (collision.transform.gameObject.transform.localScale.x == 0.08f)
            {
                i = (collision.transform.gameObject.GetComponent<SpriteRenderer>().color.r - 0.5f) * 255f;
            }
            else
            {
                i = (collision.transform.gameObject.GetComponent<SpriteRenderer>().color.b - 0.5f) * 255f;
            }
            GetComponent<SpriteRenderer>().color = tuileColor;
            demo.OnTuileEnter(number, i);
            //isPlaying = true;
        }

    }
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isPressed)
        {
            GetComponent<SpriteRenderer>().color = tuileColor;
        }
        
    }*/
    public void Pressed()
    {
        Debug.Log("lolmdroui");

        if (!isTuiled && GetComponent<SpriteRenderer>().color != Color.yellow)
        {
            GetComponent<SpriteRenderer>().color = pressedColor;

        }
        isPressed = true;

    }
}
