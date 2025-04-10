using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class LifeAndScoreScript : MonoBehaviour
{

    public int life;
    public int score;

    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "Lives: " + life;
        scoreText.text = "Score: " + score;
    }

}
