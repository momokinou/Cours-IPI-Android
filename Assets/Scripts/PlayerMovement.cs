using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 5;
    public float jumpForce = 5;

    public bool isGrounded;

    private bool moveLeft;
    private bool moveRight;

    public Button ButtonJump;

    private Vector3 initialPosition;

    public Text score;
    public int scoreValue;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Button btnJump = ButtonJump.GetComponent<Button>();
        btnJump.onClick.AddListener(TaskOnJump);
        initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        moveLeft = false;
        moveRight = false;
        scoreValue = PlayerPrefs.GetInt("score");
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        moveRight = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }

    private void TaskOnJump()
    {
        if (isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.D) || moveRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A) || moveLeft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        score.text = "Deaths: " + scoreValue.ToString();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Respawn"))
        {
            this.gameObject.transform.position = initialPosition;
            scoreValue += 1;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
        {
            isGrounded = false;
        }

    private void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit");
        PlayerPrefs.SetInt("score", scoreValue);
        PlayerPrefs.Save();
    }
    private void OnApplicationPause(bool pause)
    {
        Debug.Log("OnApplicationPause " + pause);
        PlayerPrefs.SetInt("score", scoreValue);
        PlayerPrefs.Save();
    }
}