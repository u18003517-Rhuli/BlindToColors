using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    //public Rigidbody2D enemyRigidBody;
    private float rotateSpreed = 3.5f;
    private float rateOfChange = 2.75f;
    private float maxRotateSpeed = 40f;

    //MOVEMENT

    public Rigidbody2D rb;
    private GameObject target;


    float moveSpeed = 1f;
    private float maxMoveSpeed = 2.75f;
    private float rateOFMoveChange = 0.1f;

    Vector3 directionToTarget;



    float maxLiveTime = 12.5f;
    float countLiveNess = 0f;
    float deathrate = 0.4f;
        

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            rotateSpreed = 1.5f;
            target = GameObject.FindGameObjectWithTag("Player");

           
            if (target == false)
                Debug.Log("HEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEREW");

            //rb = GetComponent<Rigidbody2D>();
            maxRotateSpeed = Random.Range(10f, maxRotateSpeed);

            maxMoveSpeed = Random.Range(0.75f, maxMoveSpeed);
            maxLiveTime = Random.Range(6.5f, maxLiveTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.CompareTag("Enemy") + " && " + rotateSpreed +" < " + maxSpeed);


        if (gameObject.CompareTag("Enemy")  ) {
            //Debug.Log("Yes sir MOVING ALONG");

            if(rotateSpreed < maxRotateSpeed)
                rotateSpreed = rotateSpreed + rateOfChange * Time.deltaTime;


            if (moveSpeed < maxMoveSpeed)
                moveSpeed = moveSpeed + rateOFMoveChange * Time.deltaTime;


            if (countLiveNess > maxLiveTime)
            {
                //Debug.Log("LAST THINGHEREEEE");
                Destroy(gameObject);

                //transform

                return;
            }


            MoveEnemy();

            countLiveNess = countLiveNess +  deathrate * Time.deltaTime;
            //Debug.Log(gameObject.name + " - ALIVE : "+ countLiveNess);
        }

        //rotate
        transform.Rotate(0f, 0f, rotateSpreed * Time.deltaTime);



    }

    void MoveEnemy()
    {

        if (target != null){

            //Debug.Log("Player position : " + target.transform.position);

            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y  * moveSpeed);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
