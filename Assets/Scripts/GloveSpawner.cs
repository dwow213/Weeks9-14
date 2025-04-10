using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class GloveSpawner : MonoBehaviour
{
    //glove prefab 
    public GameObject prefab;
    //cosmetic glove prefab
    public GameObject cosmeticPrefab;
    //reference the life and score scipt
    public GameObject LifeAndScore;

    //list that holds all the gloves
    public List<GameObject> gloves = new List<GameObject>();
    //list that holds the images for the gloves (could just be an array but whatever)
    public List<Sprite> images = new List<Sprite>();

    //unity event that will handle the failure of pressing the glove correctly or in time
    public UnityEvent failure;

    //unity event that will handle the succeeding of pressing a glove
    public UnityEvent success;

    //int variable that handles combo
    public int combo;


    // Start is called before the first frame update
    void Start()
    {
        //start a coroutine that spawns gloves
        StartCoroutine(SpawnGlove());

        //add functions to failure
        failure.AddListener(clearGloves);
        failure.AddListener(decreaseLife);
        failure.AddListener(resetCombo);

        //add functions to success
        success.AddListener(increaseScore);
        success.AddListener(removeGlove);
        success.AddListener(increaseCombo);
    }

    // Update is called once per frame
    void Update()
    {
        if (gloves[0].GetComponent<Glove>().timer <= 0) 
        {
            failure.Invoke();

            if (LifeAndScore.GetComponent<LifeAndScoreScript>().life == 0)
            {
                failure.AddListener(stopGame);
            }
        }

        if (gloves[0].GetComponent<Glove>().pressed == true)
        {
            success.Invoke();
        }

        if (gloves[0].GetComponent<Glove>().failed == true)
        {
            failure.Invoke();
        }

        //if there are at least two gloves in the glove list
        if (gloves.Count > 1)
        {
            //for loop that goes through each glove except the first one in the glove list
            for (int i = 1; i < gloves.Count; i++)
            {
                if (gloves[i].GetComponent<Glove>().pressed || gloves[i].GetComponent<Glove>().failed)
                {
                    failure.Invoke();
                }
            }
        }
  
    }

    //coroutine that spawns gloves
    private IEnumerator SpawnGlove()
    {
        //spawn gloves until said otherwise (stopCoroutine)
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
            //pmakes it a white glove
            if (Random.Range(0, 2) == 0)
            {
                gloveObj.GetComponent<Glove>().whiteGlove = true;
                gloveObj.GetComponent<SpriteRenderer>().sprite = images[0];
            }
            //makes it a red glove
            else
            {
                gloveObj.GetComponent<Glove>().whiteGlove = true;
                gloveObj.GetComponent<SpriteRenderer>().sprite = images[1];
            }


            //instantiate a cosmetic glove
            GameObject cosmeticGlove = Instantiate(cosmeticPrefab);

            //set its position and sprite to the same as the glove obj 
            cosmeticGlove.transform.position = pos;
            cosmeticGlove.GetComponent<SpriteRenderer>().sprite = gloveObj.GetComponent<SpriteRenderer>().sprite;

            //connect the cosmetic glove and the glove object
            gloveObj.GetComponent<Glove>().cosmeticGlove = cosmeticGlove;

            //add the glove to the array list
            gloves.Add(gloveObj);

            //wait an amount of time based on combo
            //if combo is less than 10
            if (combo < 10)
            {
                yield return new WaitForSecondsRealtime(2 - combo * 0.1f);
            }
            //if combo is over 10, decrease the combo scaling to not reach 0 as quickly
            else
            {
                yield return new WaitForSecondsRealtime(1.1f - combo * 0.01f);
            }
            
        }
    }

    //function that clears gloves
    public void clearGloves()
    {
        //for loop that destroys every glove object and their cosmetic glove
        for (int i = 0; i < gloves.Count; i++)
        {
            Destroy(gloves[i].GetComponent<Glove>().cosmeticGlove);
            Destroy(gloves[i]);
        }

        gloves.Clear();
    }

    //function that decreases life
    public void decreaseLife()
    {
        LifeAndScore.GetComponent<LifeAndScoreScript>().life--;
    }

    public void resetCombo()
    {
        combo = 0;
    }

    //function that stops the game when losing
    public void stopGame()
    {
        StopCoroutine(SpawnGlove());
    }

    //function that increases score
    public void increaseScore()
    {
        LifeAndScore.GetComponent<LifeAndScoreScript>().score++;
    }

    //function that increases score
    public void increaseCombo()
    {
        combo++;
    }

    //function that removes the first glove in the list
    public void removeGlove()
    {
        Destroy(gloves[0].GetComponent<Glove>().cosmeticGlove);
        Destroy(gloves[0]);
        gloves.RemoveAt(0);
    }
}
