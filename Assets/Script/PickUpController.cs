using UnityEngine;
using System.Collections.Generic;
public class PickUpController : MonoBehaviour
{
    [SerializeField]private Pickup pickup;
    [SerializeField] private GameObject environmentParent;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PickupObjectsPooling();
        ObjectInstantiation();
    }

    // Update is called once per frame
    void Update()
    {
        ObjectInstantiation();
    }
    public void PickupObjectsPooling()
    {
        if (pickup.PickupsList == null || pickup.ObstaclesList == null )
        {
            pickup.PickupsList = new List<GameObject>();
            pickup.ObstaclesList = new List<GameObject>();
            for (int i = 0; i < 20; i++)
            {
                int randomObject = Random.Range(0, pickup.pickUpObject.Length);
                int randomObstacle = Random.Range(0,pickup.obstacleObject.Length);
                pickup.PickupsList.Add(pickup.pickUpObject[randomObject]);
                pickup.ObstaclesList.Add(pickup.obstacleObject[randomObstacle]);
                pickup.numberOfObjects+=2;
            }
        }
    }
    private void ObjectInstantiation()
    {
        if (pickup.numberOfObjects < Random.Range(1,7))
        {
            pickup.startPosition.z = -100f;
            pickup.endPosition.z = 300f;
            Vector3 randomPosition = new Vector3(Random.Range(-30f, 30f), 4f, Random.Range(-100f, 100f));
            Vector3 randomObstaclePosition = new Vector3(Random.Range(-30f, 30f), 0.5f, Random.Range(-100f, 100f));
           //pickup and Obstacles 
            int randomObject = Random.Range(0, pickup.pickUpObject.Length);
            int randomObstacle = Random.Range(0, pickup.obstacleObject.Length);
            GameObject randomObj = pickup.pickUpObject[randomObject];
            GameObject randomObstacleObj = pickup.obstacleObject[randomObstacle];
            GameObject instance = Instantiate(randomObj, randomPosition, Quaternion.identity);
            GameObject instanceObstacle = Instantiate(randomObstacleObj, randomObstaclePosition, Quaternion.identity);
            instance.transform.SetParent(environmentParent.transform);
            instanceObstacle.transform.SetParent(instance.transform);
            pickup.numberOfObjects+=2;
        }

    }

     public void ClearAllObjects()
    {

        pickup.PickupsList.Clear();
        pickup.ObstaclesList.Clear();
        pickup.numberOfObjects = 0;
    }
}
