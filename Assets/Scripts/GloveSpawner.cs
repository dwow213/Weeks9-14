using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GloveSpawner : MonoBehaviour
{
    //glove prefab 
    public GameObject prefab;
    //list that holds all the gloves
    public List<GameObject> gloves = new List<GameObject>();
    //list that holds the images for the gloves (could just be an array but whatever)
    public List<Sprite> images = new List<Sprite>();
    //unity event that will handle the failure of pressing the glove correctly or in time
    public UnityEvent failure;

    //int variable that handles combo
    public int combo;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnGlove());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //coroutine that spawns gloves
    private IEnumerator SpawnGlove()
    {
        while (true)
        {
            //instantiates a glove and adds it to the glove
            GameObject gloveObj = Instantiate(prefab);

            //set its position randomly within the screen
            Vector2 pos = transform.position;
            pos.x = Random.Range(-7, 8);
            pos.y = Random.Range(-3, 3);
            gloveObj.transform.position = pos;

            //randomly decide if it's a white or red glove (50%)
            //picks a white glove
            if (Random.Range(0, 2) == 0)
            {
                gloveObj.GetComponent<SpriteRenderer>().sprite = images[0];
            }
            //picks a red glove
            else
            {
                gloveObj.GetComponent<SpriteRenderer>().sprite = images[1];
            }

            //add the glove to the array list
            gloves.Add(gloveObj);
            yield return new WaitForSecondsRealtime(2 - combo * 0.1f);
        }
    }
}
