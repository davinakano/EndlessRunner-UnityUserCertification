using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] Text distanceTraveled;
    [SerializeField] Text collectedCoins;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Player player;
    [SerializeField] GameObject gameMusic;
    [SerializeField] GameObject ambienceMusic;

    public void ShowGameOverScreen()
    {
        gameMusic.SetActive(false);
        ambienceMusic.SetActive(false);

        gameOverScreen.SetActive(true);
        distanceTraveled.text = Mathf.Ceil(player.distanceTraveled).ToString();
        collectedCoins.text = player.coinsCollected.ToString();
    }

    public void GameRestart()
    {
        SceneManager.LoadScene("EndlessRunner");
    }
}
