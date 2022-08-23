using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class EnemySpawner : MonoBehaviour
{
    public Transform player;
    public Transform spawn;

    //[SerializeField]
    public GameObject[] coloredEnemy;
    //[SerializeField]
    public  GameObject[] roomObjects;

    //public GameObject startStopObjectColor;
    public GameObject startStopObjectWhite;
    public ArrowControl arrowControl;



    private float coloredEnemyInterval;
    //private float spawnRange = 20f;

    private GameObject newSpawnPoint;
    private Vector3 oldSpawnPoint;

    private GameObject newRoomPoint;
    public GameObject oldRoomPoint;

    private bool oldNotSetup = false;


    private float spawnRate = 2.25f;
    private float spawnCount = 1;
    private float spawnRateMax = 5f;
    // Start is called before the first frame update
    void Awake()
    {
        newSpawnPoint = getNewSSPointSpawn();
        arrowControl.setTarget(newSpawnPoint.transform.position);

        oldSpawnPoint = spawn.position;
    }

    private void Start()
    {
         

       // StartCoroutine(spawnEnemy(coloredEnemy));
    }


    public string[] getRoomObjectNames()
    {
        string[] newArray = new string[roomObjects.Length];


        for (int i =0; i < roomObjects.Length; i++){
            newArray[i] = roomObjects[i].name;
        }

        return newArray;
    }

    public GameObject[] getRoomObject()
    {
        return roomObjects;


    }

    private GameObject getNewSSPointSpawn()
    {

        float minRadius = 15f;

        float spawnRange = 27f;

        float xRangeLow = player.position.x - spawnRange;
        float xRangeHigh = player.position.x + spawnRange;
        float yRangeLow = player.position.x - spawnRange;
        float yRangeHigh = player.position.x + spawnRange;

        float xRange = Random.Range(xRangeLow, xRangeHigh);
        while (xRange <= minRadius)
            xRange = Random.Range(xRangeLow, xRangeHigh);

        float yRange = Random.Range(yRangeLow, yRangeHigh);
        while (yRange <= minRadius)
            yRange  = Random.Range(xRangeLow, xRangeHigh);


        GameObject output = Instantiate(startStopObjectWhite, new Vector3(xRange, yRange, 0), Quaternion.identity);
        if(output)
            arrowControl.setTarget(output.transform.position);

        return output;


    }


    public GameObject getNewRoomSpawn()
    {

       // float xRangeLow = newSpawnPoint.transform.position.x - spawnRange;
        //float xRangeHigh = newSpawnPoint.transform.position.x + spawnRange;
        //float yRangeLow = newSpawnPoint.transform.position.x - spawnRange;
       // float yRangeHigh = newSpawnPoint.transform.position.x + spawnRange;




        int randomIndex = Random.Range(0, roomObjects.Length); 

        return Instantiate(roomObjects[randomIndex], new Vector3(oldSpawnPoint.x, oldSpawnPoint.y, 0), Quaternion.identity);

    }

    private void Update()
    {
        if (!newSpawnPoint)
        {
            newSpawnPoint = getNewSSPointSpawn();

            
        }
        else
        {
            if (oldNotSetup == false)
            {
                oldSpawnPoint = newSpawnPoint.transform.position;
                //Debug.Log("OLD : " + oldSpawnPoint);
                oldNotSetup = true;
            }
            
        }

        if (!oldRoomPoint)
        {
            newRoomPoint = getNewRoomSpawn(); //uses oldSpawn
            oldRoomPoint = newRoomPoint;
            oldNotSetup = false;
        }

        if (spawnCount >= spawnRateMax)
        {
            spawnRate = Random.Range(0.1f, 2f);
            spawnCount = 1f;
            spawnEnemy(coloredEnemy);
            setSpawnNewRateMax();


            
        }

        spawnCount = spawnCount + spawnRate * Time.deltaTime;


        /*if (Input.GetKey("escape"))
        {
            Application.Quit();
        }*/
    }

    private void setSpawnNewRateMax()
    {
        spawnRateMax = Random.Range(3.5f, 7.5f);
    }


    // Update is called once per frame
    private void spawnEnemy( GameObject[] enemies)
    {
        float interval = Random.Range(0.5f, 3f);

        //yield return new WaitForSeconds(interval);


        //float spawnRange = 0.25f;

        /*float xRangeLow = oldSpawnPoint.x - spawnRange;
        float xRangeHigh = oldSpawnPoint.x + spawnRange;
        float yRangeLow = oldSpawnPoint.x - spawnRange;
        float yRangeHigh = oldSpawnPoint .x + spawnRange;// spawn.position.x + spawnRange;*/

        if (player == null)
            return;

        float spawnRange = 12f;
        float minRadius = 9.5f;


        float xRangeLow = player.position.x - spawnRange;
        float xRangeHigh = player.position.x + spawnRange;
        float yRangeLow = player.position.x - spawnRange;
        float yRangeHigh = player.position.x + spawnRange;


        float xRange = Random.Range(xRangeLow, xRangeHigh);
        while (xRange <= minRadius)
            xRange = Random.Range(xRangeLow, xRangeHigh);
     
        float yRange = Random.Range(yRangeLow, yRangeHigh);
        while (yRange <= minRadius)
            yRange = Random.Range(xRangeLow, xRangeHigh);

        int randomIndex = Random.Range(0, enemies.Length);
        GameObject output = Instantiate(enemies[randomIndex], new Vector3(xRange, yRange, 0), Quaternion.identity);

        if (output == null)
            return;

        //Debug.Log(output.transform.position + " - " + output.name);
        //Debug.Log("SPAWN");

    }


    void OnApplicationQuit()
    {
        //TODO : SHOW POPUP CONTAINING A YES BUTTON WITH 
        //Application.Quit() + change allowQuitting to true.

        bool allowQuitting = EditorUtility.DisplayDialog(
      "Exit Game", // title
      "Are you sure want to exit the game?", // description
      "Yes", // OK button
      "No" // Cancel button
    );


        Debug.Log("isExited : " + allowQuitting );

        if (!allowQuitting)
            Application.CancelQuit();

    }
}
