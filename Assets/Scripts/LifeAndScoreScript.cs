using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LifeAndScoreScript : MonoBehaviour
{

    public int life;
    public int score;

    public UnityEditor.UI.TextEditor lifeText;
    public TextMesh scoreText;
    
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
