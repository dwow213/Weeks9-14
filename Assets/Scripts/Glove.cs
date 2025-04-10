using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Glove : MonoBehaviour
{

    //boolean that determines whether it's a white or red globe
    public bool whiteGlove;
    //float for time left to press correctly
    public float timer;
    //game object for the cosmetic glove
    public GameObject cosmeticGlove;

    //bool that determines whether the glove is pressed
    public bool whitePressed;
    //another bool that automatically determines the glove is failed
    public bool whiteFailed;
    public bool redPressed;
    public bool redFailed;

    //bools for determining whether a specific key is pressed
    bool mousePressed;
    bool qPressed;
    bool ePressed;

    

    // Start is called before the first frame update
    void Start()
    {
        //timer runs out after 5 seconds
        timer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //get the size of the cosmetic glove
        Vector2 cosmeticGloveSize = cosmeticGlove.transform.localScale;

        //shrink the cosmetic glove based on timer
        cosmeticGloveSize.x = 0.5f * timer / 5;
        cosmeticGloveSize.y = 0.5f * timer / 5;
        cosmeticGlove.transform.localScale = cosmeticGloveSize;

        //decrease timer by 1 every second
        timer -= 1 * Time.deltaTime;

        //get the position of the mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        //white glove
        //check if the mouse is within the glove and left mouse button pressed
        if (mousePos.x > transform.position.x - 1.25 && mousePos.x < transform.position.x + 1.25 && mousePos.y > transform.position.y - 1.3 && mousePos.y < transform.position.y + 1.3 && Input.GetMouseButtonDown(0) && !mousePressed)
        {
            //check if it is a white glove
            if (whiteGlove)
            {
                //passes the first check for the white glove, second check is done in the spawner where its index is checked
                whitePressed = true;
            }
            //automatically fails if the glove is not white
            else
            {
                whiteFailed = true;
            }
        }

        //red glove
        //check if either q or e is pressed, not pressed last frame and is a red glove
        if ((Input.GetKeyDown(KeyCode.Q) && !qPressed) || (Input.GetKeyDown(KeyCode.E) && !ePressed))
        {
            //if q is pressed and the red glove is on the left side
            if ((Input.GetKeyDown(KeyCode.Q) && transform.position.x <= 0))
            {
                //passes the first check for the white glove, second check is done in the spawner where its index is checked
                redPressed = true;
            }
            //if e is pressed and the red glove is on the right side
            else if ((Input.GetKeyDown(KeyCode.E) && transform.position.x >= 0))
            {
                //passes the first check for the white glove, second check is done in the spawner where its index is checked
                redPressed = true;
            }
            //automatically fails if the wrong key is pressed for a certain side
            else
            {
                redFailed = true;
            }
        }

        //check if the keys are pressed
        checkKeyPressed();


    }

    //function that allows keys to be registered as an input once until it is released instead of being registered every frame
    void checkKeyPressed()
    {
        //if either q, e or left mouse button is pressed, disallow them from being registered until it is released
        if (Input.GetKeyDown(KeyCode.Q))
        {
            qPressed = true;
        }
        else
        {
            qPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ePressed = true;
        }
        else
        {
            ePressed = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            mousePressed = true;
        }
        else
        {
            mousePressed = false;
        }

    }

    //function that destroys the cosmetic glove then itself
    public void destroyGlove()
    {
        Destroy(cosmeticGlove);
        Destroy(gameObject);
    }
}
