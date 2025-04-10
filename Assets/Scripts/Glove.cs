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
    public GameObject cosmeticGlove;

    public bool pressed;
    public bool failed;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 5;
        //StartCoroutine(DecreaseTimer());
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

        Debug.Log(timer);

        //get the position of the mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //check if the mouse is within the glove and left mouse button pressed
        if (mousePos.x > transform.position.x - 1.25 && mousePos.x < transform.position.x + 1.25 && mousePos.y > transform.position.y - 1.3 && mousePos.y < transform.position.y + 1.3 && Input.GetMouseButtonDown(0))
        {
            if (whiteGlove)
            {
                pressed = true;
            }
            else
            {
                failed = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

        }
        else if (Input.GetKeyDown(KeyCode.E))
        {

        }
    }



}
