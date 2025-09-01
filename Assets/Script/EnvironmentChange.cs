using UnityEngine;

public class EnvironmentChange : MonoBehaviour
{
 
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject environment;
    [SerializeField] private PickUpController pickUpController;
    [SerializeField] private Vector3 endPosition, startPosition,_playerStartPosition,_playerEndPosition;

    private float originalSpeed,boostmultiplier=2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition=environment.transform.position ;
        originalSpeed = moveSpeed;
        //_playerStartPosition= _playerPrefab.transform.position ;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0,0,moveSpeed*Time.deltaTime);
        environment.transform.position += movement;
        RegenerationEnvironment();
    }

    private void RegenerationEnvironment()
    {
        if (environment != null && environment.transform.position.z <= endPosition.z)
        {
            environment.transform.position = startPosition;
          //  _playerPrefab.transform.position = _playerStartPosition;
            pickUpController.ClearAllObjects();
        }
    }

    public void ApplySpeedBoost(float duration,GameObject ParticlePrefab)
    {
        StartCoroutine(SpeedBoosCouroutine(duration,ParticlePrefab));
    }

    private System.Collections.IEnumerator SpeedBoosCouroutine(float duration,GameObject ParticlePrefab)
    {
        moveSpeed *= boostmultiplier;
        if (ParticlePrefab != null) ParticlePrefab.SetActive(true);
        yield return new WaitForSeconds(duration);
        moveSpeed = originalSpeed;
        if (ParticlePrefab != null) ParticlePrefab.SetActive(false);
        
    }
    public void IncreaseSpeed(float amount)
    {
        moveSpeed += amount;
    }
}
