using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
   

    public Transform player;
    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }

    /*public IEnumerator ShakeCamera( float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float xVsalue = Random.Range(-1f, 1f) * magnitude;
            float yVsalue = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(xVsalue, yVsalue, originalPosition.z);


            yield return null;
               
        }

        transform.localPosition = originalPosition;

    }*/
}
