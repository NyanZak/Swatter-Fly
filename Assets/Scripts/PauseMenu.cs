using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject strike1, strike2, strike3;
    public static int strikes;
    public GameObject pauseMenu, gameoverMenu;
    public bool isGameOver = false;
    public static bool isPaused;

    private void Awake()
    {
        pauseMenu.SetActive(false);
        gameoverMenu.SetActive(false);
    }

    private void Start()
    {
        strikes = 0;
        strike1.gameObject.SetActive(true);
        strike2.gameObject.SetActive(true);
        strike3.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if (strikes < 0)
        {
            strikes = 0;
        }
        switch (strikes)
        {
            case 0:
                strike1.gameObject.SetActive(true);
                strike2.gameObject.SetActive(true);
                strike3.gameObject.SetActive(true);
                break;
            case 1:
                strike1.gameObject.SetActive(true);
                strike2.gameObject.SetActive(true);
                strike3.gameObject.SetActive(false);
                break;
            case 2:
                strike1.gameObject.SetActive(true);
                strike2.gameObject.SetActive(false);
                strike3.gameObject.SetActive(false);
                break;
            case 3:
                strike1.gameObject.SetActive(false);
                strike2.gameObject.SetActive(false);
                strike3.gameObject.SetActive(false);
                isGameOver = true;
                StartCoroutine("Wait");
                break;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        gameoverMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenu?.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResumeGame();
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        isPaused = false;
    }

    public void QuitGame()
    {
    Application.Quit();
    }
}