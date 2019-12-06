using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float score = 0;
    public int buildingsRemaining = 3;
    public Text gameOverText;
    public GameObject returnB;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameOverText.gameObject.SetActive(false);
        returnB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        score += 1 * Time.deltaTime;
        if (buildingsRemaining <= 0)
        {
            gameOverText.text = "The last buildings on Earth have been destroyed. You managed to fend off the invasion for " + Math.Round(score).ToString() + " seconds, giving the survivors valuable time to escape!";
            GameOver();
        }
    }

    public void ReturnToMM()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        returnB.SetActive(true);
        player.allowInput = false;
        Time.timeScale = 0;
    }
}