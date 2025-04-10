using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Glove : MonoBehaviour
{

    //boolean that determines whether it's a white or red globe
    bool whiteGlove;
    //float for time left to press correctly
    public float timer;
    public bool pressable;
    public GameObject cosmeticGlove;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cosmeticGloveSize = cosmeticGlove.transform.localScale;
        cosmeticGloveSize.x = 0.5f * timer / 5;
        cosmeticGloveSize.y = 0.5f * timer / 5;
        cosmeticGlove.transform.localScale = cosmeticGloveSize;

        StartCoroutine(DecreaseTimer());

        Debug.Log(timer);
    }

    private IEnumerator DecreaseTimer()
    {
        timer -= 1 * Time.deltaTime;
        yield return null;
    }

}
