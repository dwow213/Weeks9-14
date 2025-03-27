using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroKnightScript : MonoBehaviour
{
    public int speed;
    public Animator anim;

    public List<AudioClip> footsteps;
    public AudioSource audSource;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        pos.y += Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        if (pos.x != transform.position.x || pos.y != transform.position.y)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }

        transform.position = pos;

        
    }

    public void footstep()
    {
        audSource.clip = footsteps[Random.Range(0, 9)];
        audSource.Play();
    }
}
