using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragonController : MonoBehaviour
{
    
    Text scoreText;
    Text gameOver;
    Rigidbody myBod;
    Animator flap;
    AudioSource crashAudio;
    AudioSource flapAudio;
    AudioSource pointAudio;


    public float speed;
    public float jump;
    public int score;

    public AudioClip Crash;
    public AudioClip Flap;
    public AudioClip Point;

    // Start is called before the first frame update
    void Start()
    {
        flap = GetComponent<Animator>();
        myBod = GetComponent<Rigidbody>();
        myBod.velocity = new Vector3(10, 0, 0);

        gameOver = GameObject.Find("GameOver").GetComponent<Text>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();

        crashAudio = GetComponent<AudioSource>();
        flapAudio = GetComponent<AudioSource>();
        pointAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Vertical");
        float vx = speed * h;
        float vy = myBod.velocity.y;
        myBod.velocity = new Vector3(vx, vy);
        if (Input.GetButtonDown("Jump"))
        {
            vy = jump;
            myBod.velocity = new Vector3(10, 15, 0);
            Time.timeScale = 1;
            flap.SetBool("Flap", true);
            flapAudio.PlayOneShot(Flap);
            gameOver.text = "";

        }
        else
        {
            flap.SetBool("Flap", false);
        }
        if (Time.timeScale == 1)
        {
            
        }
        if (Time.timeScale <= 0)
        { 
            gameOver.text = "Game Over";
        }
        else
        {
            Time.timeScale = 1;
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherGo = collision.gameObject;

        if (otherGo.tag == "Floor")
        {
            crashAudio.PlayOneShot(Crash);
            SceneManager.LoadScene(0);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Column")
        {
            pointAudio.PlayOneShot(Point);
            score += 1;
            scoreText.text = "Score: " + score;
        }
    }
}