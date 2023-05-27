using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public GameObject reStartPanel;

    public Text score;

    private bool asLost;    //false

     void Update()
    {
        if (asLost == false)
        {
            score.text = Time.time.ToString("F0");    // F0 virgüllü kýsmý almamak için
        }        
    }
    public void GameOver()
    {
        asLost = true;  
        Invoke("Delay",0.5f);
    }
    void Delay()
    {
        reStartPanel.SetActive(true);
    }
  
    public void goToGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void reStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void goToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
