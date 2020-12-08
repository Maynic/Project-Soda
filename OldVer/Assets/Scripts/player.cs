using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [RequireComponent(typeof(CharacterController))]
public class player : MonoBehaviour
{
    private CharacterController controller;
    public GameObject UI_SP;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 16.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -90.81f;
    // private float timeLimit = 0.0f;
    // private bool isMoving = false;
    Vector3 move = Vector3.zero; 
    public int sanityPoint = 10;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        UI_SP = GameObject.FindGameObjectWithTag("UI_SP");

    }

    // IEnumerator ExampleCoroutine(Vector3 m)
    // {
    //     //Print the time of when the function is first called.
    //     // Debug.Log("Started Coroutine at timestamp : " + Time.time);

    //     //yield on a new YieldInstruction that waits for 5 seconds.
    //     // yield return new WaitForSeconds(1);
    //     float startTime = Time.time;
    //     while(Time.time < (startTime + 1f))
    //     {
    //         controller.Move(m * Time.smoothDeltaTime * playerSpeed);
    //         yield return null;
    //     }
    //     yield return new WaitForSeconds(0.5f);
    //     isMoving = false;

    //     //After we have waited 5 seconds print the time again.
    //     // Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    // }

    void Update()
    {

        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // bool i = Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical");
        controller.Move(move * Time.smoothDeltaTime * playerSpeed);
        if (move != Vector3.zero){ gameObject.transform.forward = move; }


        // if (move != Vector3.zero && !isMoving) {
        // if (i && !isMoving) {
            // gameObject.transform.forward = move;
            // isMoving = true;
            // StartCoroutine(ExampleCoroutine(move));
        // }

        UI_SP.GetComponent<UnityEngine.UI.Text>().text = "SP: " + sanityPoint + "/10"; 

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        // gameObject.transform.Rotate(-22.6f, 0.0f, 0.0f, Space.Self);
        if (sanityPoint < 1)
        {
            sanityPoint = 10;
            controller.enabled = false;
            gameObject.transform.position = new Vector3(-4.0f, 4.0f, -12.0f);
            controller.enabled = true;

        }

    }

    // void OnTriggerStay(Collider col)
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Car") {
            sanityPoint -= 20;
        }        
        if(col.gameObject.tag == "Walker") {
            sanityPoint -= 1;
        }
        if(col.gameObject.tag == "Biker") {
            sanityPoint -= 2;
        }
    }
}