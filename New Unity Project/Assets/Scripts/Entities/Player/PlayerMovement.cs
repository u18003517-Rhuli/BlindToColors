using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{

    public FixedJoystick joyStick;
    public Rigidbody2D playerRigidBody;
    public SpriteRenderer playerSprite;
    public GameObject DestroyPlayerEffect;
    public GameOverScreen gameOverScreen;

    public Text scorePoint;

    //MOVEMENT
    private Vector2 movement;
    public float movementSpeed;

    //PROPERTIES
    public Color CyanColor;
    public Color MagentaColor;
    public Color PinkColor;
    public Color YellowColor;
    public Color WhiteColor;
    private string playerColor;

    //GAMEPLAY
    private bool colorIsSet;
    private int gameScore;






    // Start is called before the first frame update
    void Start()
    {
        colorIsSet = false;
        //playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = joyStick.Horizontal;
        movement.y = joyStick.Vertical;

        //Debug.Log(movement.x + " - " + movement.y);

        /*rotate player
        float hAxis = movement.x;
        float vAxis = movement.y;
        float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0f, 0f, -zAxis);*/




    }

    private void FixedUpdate()
    {

        //Debug.Log(playerRigidBody.position + movement * movementSpeed * Time.fixedDeltaTime);
        playerRigidBody.MovePosition(playerRigidBody.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == null)
            return;

        if (colorIsSet == false)
        {

            //Debug.Log("Collision False");
            if (collision.tag.Equals(playerColor) == false)
            {
                //Debug.Log(collision.tag + " ----- " +  playerColor);

                gameScore = gameScore + 1;
                ChangeGameScore(gameScore);

                SetColor(collision.tag);
                colorIsSet = true;
            }
            else
            {
                //Debug.Log(collision.tag + " ----- " + playerColor);

                gameScore = gameScore + 2;
                ChangeGameScore(gameScore);
            }

        }
        else if (colorIsSet == true)
        {
            //Debug.Log("Collision True");
            if (collision.tag.Equals(" WhiteColor") == true)
            {
                Debug.Log("Reset!!!");

                gameScore = gameScore + 10;
                ChangeGameScore(gameScore);

                SetColor(" WhiteColor");
                colorIsSet = false;
            }

            else if (collision.tag.Equals(playerColor) == true)
            {
                gameScore = gameScore + 5;
                ChangeGameScore(gameScore);
            }
            else
            {
                //Debug.Log("Game Over!!!");
                gameOver();
                colorIsSet = false;
            }


        }

    }



    private void SetColor(string inputColor)
    {
        //int index = Random.Range(0, 3);

        //Color randomColor;

        //Debug.Log("INPUT COLOR HERE - " + inputColor);

        gameObject.tag = inputColor;

        switch (inputColor) {

            case "CyanColor":
                playerColor = "CyanColor";
                playerSprite.color = CyanColor;
                break;

            case "YellowColor":
                playerColor = "YellowColor";
                playerSprite.color = YellowColor;
                break;

            case "MagentaColor":
                playerColor = "MagentaColor";
                playerSprite.color = MagentaColor;
                break;

            case "PinkColor":
                playerColor = "PinkColor";
                playerSprite.color = PinkColor;
                break;

            case " WhiteColor":
                playerColor = " WhiteColor";
                playerSprite.color = WhiteColor;
                break;

                /*default:
                    playerColor = "WhiteColor";
                    playerSprite.color = WhiteColor;
                    break;*/
        }

        //playerSprite.color = randomColor;
    }



    private void gameOver()
    {
        CameraShaker.Instance.ShakeOnce(4f, 4f, -1f, 1f);
        //Destroy(gameObject);

        playerSprite.enabled = false;
        Instantiate(DestroyPlayerEffect, transform.position, Quaternion.identity);


        FindObjectOfType<AudioManager>().Play("PlayerDeath");

        //FindObjectOfType<AudioManager>().StopPlaying("Theme"); // very specif to this

        //FindObjectOfType<AudioManager>().Play("Theme2");
            

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        StartCoroutine(waitTwoSeconds());


        Destroy(gameObject);
        gameOverScreen.Setup(gameScore);
    }


    void ChangeGameScore(int Gamescore)
    {
        //Text ScoreText = GameObject.//GameObject.FindWithTag("Score"); //GameObject.FindGameObjectWithTag<Text>();
        scorePoint.text = Gamescore.ToString();
    }

    public IEnumerator waitTwoSeconds()
    {

        //Debug.Log("waited secounds here2!");
        yield return new WaitForSeconds(3f);
        Debug.Log("waited secounds here!!!!!");

    }




}
