﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int count;
    private int lives;
    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;
    public Text loseText;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        winText.text = "";
        loseText.text = "";
        SetCountText ();
        SetLivesText ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel(0);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }
        if (other.gameObject.CompareTag ("Enemy"))
        {
            other.gameObject.SetActive (false);
            lives = lives - 1;
            SetLivesText ();
        }
    }

    void SetCountText ()
    {
        countText.text = "Score: " + count.ToString ();
        if (count >= 4)
        {
            winText.text = "You Win!";
        }
    }

    void SetLivesText ()
    {
        livesText.text = "Lives: " + lives.ToString ();
        if (lives <= 0)
        {
            loseText.text = "You Lose! Press 'space' to restart";
        }
    }
}
