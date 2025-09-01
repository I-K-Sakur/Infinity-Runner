using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float moveSpeed = 15f;
    private bool _isInGround = true;
    private float jumpForce = 15f;
    [SerializeField] private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PickupInformation pickupInformation = player.GetComponent<PickupInformation>();
    }

    // Update is called once per frame
    void Update()
    {
        // Running();
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) && _isInGround)
        {
            Jump();
        }

    }

    public void Running()
    {
        
    }

    public void Movement()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(moveX, 0, 0);

    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _isInGround = false;
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isInGround = true;
        }
    }
    



}
