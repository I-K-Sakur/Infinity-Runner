using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    private bool isPaused;
    private bool isDead ;
    [SerializeField] private GameObject pauseObject;

    private void Start()
    {
        pauseObject.SetActive(false);
    }

    private void Update()
    {
        RestartScene();
        PauseGame();
    }

    public void RestartScene()
    {
        if ( isDead  && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f; 
            SceneManager.LoadScene("GameScene");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void SetDead()
    {
        isDead = true;
    }
    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0f  : 1f;
            if (pauseObject != null)
                pauseObject.SetActive(isPaused);
        }
    }
}
