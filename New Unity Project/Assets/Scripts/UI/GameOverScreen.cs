using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text gameScoreText;
    
    public void Setup(int gameScore)
    {

        gameObject.SetActive(true);
   

        //StartCoroutine(waitTwoSeconds());


      

        gameScoreText.text = "Score: " + gameScore.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //FindObjectOfType<AudioManager>().StopPlaying("Theme2"); // very specif to this

        //FindObjectOfType<AudioManager>().Play("Theme");

        //SceneManager.LoadScene("Menu);
    }


    public void ExitButton()
    {
        Application.Quit();
    }

    public void HighscoreButton()
    {

    }


    public IEnumerator waitTwoSeconds()
    {


        yield return new WaitForSeconds(3f);

    
    }


}
