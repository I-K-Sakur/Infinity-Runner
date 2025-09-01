using UnityEngine;
using TMPro;
public class PlayerParticle : MonoBehaviour
{
    //[SerializeField] private PickupInformation pickupInformation;
    public GameObject particlePrefab;

     private PickupInformation pickupInformation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickupInformation = FindObjectOfType<PickupInformation>();
        particlePrefab.SetActive(false);
    }




}
