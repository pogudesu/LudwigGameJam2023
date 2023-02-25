using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 5.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private InputManager inputManager;
    private Transform cameraTransform;
    public static PlayerController Instance;
    public CinemachinePOVExtension camExtension;
    public GameObject camPos;
    public Collider colliderhit;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
        if (Instance == null)
        {
            Instance = this;
        }

        // Cursor.visible = false;
        
    }
    private int nextUpdate=1;
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0.0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0.0f;
        controller.Move(move.normalized * Time.deltaTime * playerSpeed);

        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

        // Changes the height position of the player..
        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if(inputManager.PlayerInteract())
        {
            RaycastHit ray;
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out ray, 1000.0f))
            {

                if(ray.collider.GetComponent<Interactables>() != null)
                {
                    colliderhit = ray.collider;
                    Interactables obj = colliderhit.GetComponent<Interactables>();
                    obj.Interact();
                }
            }
        }
        
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            /////////////// FootStep /////////////////
            if(Time.time>=nextUpdate){
                nextUpdate=Mathf.FloorToInt(Time.time)+1;
                AudioManager.Instance.PlatFootstep();
            }
        }

    }
}
