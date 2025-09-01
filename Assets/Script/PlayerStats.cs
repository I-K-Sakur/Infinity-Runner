using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
public class PlayerStats : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI healthText;
    [SerializeField] private Animator animator;
    [Header("Player Stats")]
    private int points;
    public bool playerIsDead;
    [SerializeField] private TextMeshProUGUI deathText;
    private SceneController sceneController;
    [SerializeField] private AudioSource pickupSound;
    [SerializeField] private AudioSource hitSound;
    public int Points
    {
        get => points;
        set
        {
            points = value;
            if (pointText != null)
                pointText.text = "Points: " + points;
        }
    }

    private int health;
    public int Health
    {
        get => health;
        set
        {
            health = value;
            if (healthText != null)
                healthText.text = "Health: " + health;
            
            if (health <= 0)
            {
                PlayerDeath();
            }
        }
    }
    private void Start()
    {
        // Initialize UI
        if (pointText != null) pointText.text = "Points: " + Points;
        if (healthText != null && health>=0) healthText.text = "Health: " + Health;
        sceneController = FindObjectOfType<SceneController>();
       
    }

    private void Update()
    {
        
    }

    // Methods to update stats
    public void AddPoints(int amount)
    {
        Points += amount;
        pickupSound.Play();
        Debug.Log("Points updated: " + Points);
    }

    public void AddHealth(int amount)
    {
        Health += amount;
        pickupSound.Play();
        Debug.Log("Health updated: " + Health);
    }

    private void PlayerDeath()
    {

            //death of player
            if (health < 0)
            {
                animator.SetTrigger("Death");
                playerIsDead = true;
                hitSound.Play();
                Debug.Log("Player is dead");
                deathText.text = "Your Score is " +points+ " Press R To Restart";
                Time.timeScale = 0f;
                if (sceneController != null)
                {
                    sceneController.SetDead(); // Mark as dead for restart
                }
            }


    }

}