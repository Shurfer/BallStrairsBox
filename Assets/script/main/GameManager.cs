using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int tapScore;

    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject endMenu;
    [SerializeField] private Text[] scoreTexts;
    private void Awake()
    {
        EventManager.OnTapScreen.AddListener(ScoreTapChange);
        EventManager.OnPlayerDied.AddListener(EndGame);
        
        StaticScript.endGame = false;
        StaticScript.isJumping = false;
        StaticScript.isJumping = false;
        StaticScript.isSideMoving = false;
        
    }

    void ScoreTapChange()
    {
        tapScore++;
        scoreText.text = tapScore.ToString();
    }

    void EndGame()
    {
        StaticScript.endGame = true;
        int bestScore = PlayerPrefs.GetInt("bestScore", 0);
        if (tapScore > bestScore)
            PlayerPrefs.SetInt("bestScore", tapScore);
        scoreTexts[0].text= scoreText.text = tapScore.ToString();
        scoreTexts[1].text = PlayerPrefs.GetInt("bestScore", 0).ToString();
        endMenu.SetActive(true);
        StartCoroutine(timerToPalyerDied());
    }
    IEnumerator timerToPalyerDied()
    {
        yield return new WaitForSeconds(3);
        LoadScene();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Play");
    }
}