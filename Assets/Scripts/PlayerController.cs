//Script for everything related to the player: movement, jumping and interaction with pickables
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Non editable variables

    //Main variables
    private Rigidbody playerRB;
    private Vector3 playerPos;

    //Jump variables
    private bool isGrounded = true;
    private bool doubleJumpAvailable = false;

    //Audio variable (for when picking up the pickables)
    public AudioSource pickable;

    //Editable variables 
    [Header ("Parámetros del jugador")]
    [SerializeField]
    [Tooltip ("Similar a la velocidad del jugador")]
    private float moveForce = 500f;
    [SerializeField]
    [Tooltip("Fuerza con la que el jugador salta")]
    private float jumpForce = 10f;
    [SerializeField]
    [Tooltip("Distancia hasta la que el jugador puede saltar")]
    private float jumpAmount = 1f;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    //Movement of the player
    private void PlayerMovement()
    {
        playerPos = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        playerRB.AddForce(playerPos.normalized * moveForce * Time.deltaTime);
    }

    //Jump of the player
    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerPos = new Vector3(0, jumpAmount, 0);

            playerRB.AddForce(playerPos * jumpForce, ForceMode.Impulse);

            doubleJumpAvailable = true;

        }
        else if (doubleJumpAvailable && Input.GetKeyDown(KeyCode.Space))
        {
            playerPos = new Vector3(0, jumpAmount, 0);

            playerRB.AddForce(playerPos * jumpForce, ForceMode.Impulse);

            doubleJumpAvailable = false;

        }

    }

    //Methods to check if player is grounded or not
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    //Method to pick pickables
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Pickable"))
        {
            GameManager.instance.playerScore++;
            GameManager.instance.pickableNumber--;

            Destroy(other.gameObject);
            pickable.Play();
           
        }
    }
}
