using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestoy : MonoBehaviour
{

    public SpriteRenderer enemySprite;
    public GameObject destroyEnemyEffect;
    private string enemyColor;

    public ParentEnemyDestroy parentEnemyDestroy;

    private string WhiteColor = " WhiteColor";

    // Start is called before the first frame update
    void Start()
    {
        enemyColor = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyEnemy()
    {

        //Debug.Log("Destoy enemy!!!!!!");
        enemySprite.enabled = false;
        Instantiate(destroyEnemyEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        int playerLayer = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer != playerLayer)
        {
            if (collision.gameObject.GetComponent<Collider>() && GetComponent<Collider>())
            {
                Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
                
            }
            return;
        }

        //Debug.Log("Player collsion - " + collision.gameObject.tag + " -- " + collision.gameObject.tag.CompareTo(WhiteColor));

        if (collision.gameObject.CompareTag(WhiteColor) == true)//(collision.gameObject.tag.CompareTo("WhiteColor") == 0 || collision.gameObject.tag.CompareTo("WhiteColor") == -1) //true
        {
            //Debug.Log("destroy 1 white : " + gameObject.tag + gameObject.tag.Equals(WhiteColor));

            if (gameObject.CompareTag(WhiteColor) == true) //(gameObject.tag.CompareTo("WhiteColor") == 0 || collision.gameObject.tag.CompareTo("WhiteColor") == -1)
            {
                FindObjectOfType<AudioManager>().Play("PlayerDeath");
                parentEnemyDestroy.DestroyObject();
            }
            else
            {
                DestroyEnemy();
            }
            return;
        }

        //Debug.Log("destroy 2 color : " + gameObject.tag + "  -- " + gameObject.CompareTag(WhiteColor));

        //ELSE: Player is colored

        if (gameObject.CompareTag(WhiteColor) == false) { //false
            if (collision.CompareTag(enemyColor) == true)//(collision.tag.CompareTo(enemyColor)==0 || collision.tag.CompareTo(enemyColor) == -1)
            {
                FindObjectOfType<AudioManager>().Play("EnemyDeath");
                DestroyEnemy();
            }
            else
            {
                //GAME OVER...already handled playermovement
            }
        }
        
        else 
        {
            //DestroyEnemy();
            FindObjectOfType<AudioManager>().Play("EnemyDeath");
            parentEnemyDestroy.DestroyObject();
        }



    }
}
