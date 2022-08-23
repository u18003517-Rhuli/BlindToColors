using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentEnemyDestroy : MonoBehaviour
{
    public GameObject respawnStartStopPointColor;

    //public EnemySpawner enemySpawner;

    //public GameObject[] roomObjects;




    public void DestroyObject()
    {
        if(gameObject.CompareTag("SSPointWhite") == true)
        {

            EnemyDestoy[] scripts = GetComponentsInChildren<EnemyDestoy>();
            foreach (EnemyDestoy foundScript in scripts)
            {
                foundScript.DestroyEnemy();
            }


            //CLEAN UP
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("SSPointColor");

            for(int i =0; i < gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }
            //CLEAN UP


            Instantiate(respawnStartStopPointColor, transform.position, Quaternion.identity);

            DestroyRoom();
            Destroy(gameObject);

        }
        else if (gameObject.CompareTag("SSPointColor") == true)
        {
            /*foreach (Transform child in transform)
                print("Foreach loop: " + child);
        

            int children = transform.childCount;
            for (int i = 0; i < children; ++i)
                print("For loop: " + transform.GetChild(i));*/

            EnemyDestoy[] scripts = GetComponentsInChildren<EnemyDestoy>();
            foreach (EnemyDestoy foundScript in scripts)
            {
                foundScript.DestroyEnemy();
            }

            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Enemy") == true)
        {

            //Debug.Log("checinkign 123....");
           
            EnemyDestoy[] scripts = GetComponentsInChildren<EnemyDestoy>();
            foreach (EnemyDestoy foundScript in scripts)
            {
                foundScript.DestroyEnemy();
            }


            Destroy(gameObject);    
        }
    }

    private void DestroyRoom()
    {
        //string[] RoomNames = enemySpawner.getRoomObjectNames();

       

        //bool notFound = true;
        //int index = 0;

        GameObject oldRoom = GameObject.Find("SquareRoomUp");
        if (oldRoom)
        {
            Destroy(oldRoom);

        }
        else
        {
            //while (index < roomObjects.Length && notFound == true)
            //{
                //Debug.Log("Understaning here + " + roomObjects);
                //string name = roomObjects[index].name;

                oldRoom = GameObject.FindGameObjectWithTag("Room");
                if (oldRoom)
                {
                    //Debug.Log("CHECNOING HEREE FOR CLEAN UP");
                    //notFound = false;

                    Destroy(oldRoom);
                }
                //index = index + 1;
            //}
        }

        /*for (int i = 0; i < RoomNames.Length; i++)
        {
            newArray[i] = roomObjects[i].name;
        }*/
    } 


    
}
