using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerEvents : MonoBehaviour
{

    public Sprite spriteOn;
    public Sprite spriteOff;
    public GameObject prefab;
    public Image image;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mouseOnSprite()
    {
        image.sprite = spriteOn;
    }

    public void mouseOffSprite()
    {
        image.sprite = spriteOff;
    }

    public void spawn()
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.position = new Vector2(Random.Range(-8, 8), Random.Range(-4, 4));
        obj.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
    }
}
