using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PickupInformation : MonoBehaviour
{
    [SerializeField] private PicupData picupData;
    private PlayerParticle playerParticle;
    public bool playerDeath = false;
    void Awake()
    {
        playerParticle = FindObjectOfType<PlayerParticle>();

    }

    private void Update()
    {
        // pickupPoint = picupData.points;
        // healthCount = picupData.lifeCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyPickupEffect(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void ApplyPickupEffect(GameObject player)
    {
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        if (playerStats == null) return;

        switch (picupData.pickupType)
        {
            case PickupType.Points:
                playerStats.AddPoints(picupData.points); // use picupData directly
                Debug.Log("Player obtained a point");
                break;

            case PickupType.ExtraLife:
                playerStats.AddHealth(picupData.lifeCount); // use picupData directly
                Debug.Log("Player got an extra life");
                break;

            case PickupType.SpeedBoost:
                EnvironmentChange[] environments = FindObjectsOfType<EnvironmentChange>();
                foreach (var env in environments)
                    env.ApplySpeedBoost(5f, playerParticle?.particlePrefab);
                Debug.Log("Player got extra boost");
                break;
        }
    }


}