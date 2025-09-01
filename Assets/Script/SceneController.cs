using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    private bool isPaused;
    private bool isDead ;

    private void Update()
    {
        RestartScene();
        PauseGame();
    }

    public void RestartScene()
    {
        if ( isDead  && Input.GetKeyDown(KeyCode.Space))
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
            Time.timeScale = isPaused ? 0f : 1f;
        }
    }
}
