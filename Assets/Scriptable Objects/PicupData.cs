using UnityEngine;


public enum PickupType
{
    ExtraLife,
    SpeedBoost,
    Points
}
[CreateAssetMenu(fileName = "PicupData", menuName = "Scriptable Objects/PicupData")]
public class PicupData : ScriptableObject
{
    public string pickupName;
    public PickupType pickupType;
    public int lifeCount;
    public float speedBoost;
    public int points;
    public bool _needParticles;
}
