using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{

    public GameObject spaceOne;
    public GameObject spaceTwo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChnageBackgorunf()
    {
        spaceOne.SetActive(false);
        spaceTwo.SetActive(true);
    }
}
