using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Pickup", menuName = "Scriptable Objects/Pickup")]
public class Pickup : ScriptableObject
{
    public List<GameObject> PickupsList= new List<GameObject>();
    public List<GameObject> ObstaclesList= new List<GameObject>();
    public GameObject[] pickUpObject;
    public GameObject[] obstacleObject;
    public int numberOfObjects=0;
    public Vector3 startPosition, endPosition;

}
