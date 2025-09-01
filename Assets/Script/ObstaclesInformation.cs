using System;
using UnityEngine;

public class ObstaclesInformation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStats playerStats = other.gameObject.GetComponent<PlayerStats>();
            if (playerStats != null )
            {
                playerStats.Health -= 1; // Proper instance access
            }
        }
    }
}
