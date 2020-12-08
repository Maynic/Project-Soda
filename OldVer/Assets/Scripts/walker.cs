using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walker : MonoBehaviour
{
    private CharacterController controller;
    // private Vector3 playerVelocity;
    // private bool groundedPlayer;
    private float playerSpeed = 16.0f;
    // private float jumpHeight = 1.0f;
    // private float gravityValue = -90.81f;
    // private float timeLimit = 0.0f;
    // private bool isMoving = false;
    Vector3 move = Vector3.left;
    bool canTurn = true;     
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        controller.Move(move * Time.smoothDeltaTime * playerSpeed);
        if (move != Vector3.zero){ gameObject.transform.forward = move; }
    }
    // void OnTriggerStay(Collider col)
    void OnTriggerEnter(Collider col)
    {
        if(canTurn && col.gameObject.tag == "OtherZone")
        {
            move = -1 * move;
            // canTurn = false;
            // StartCoroutine(ExampleCoroutine());
        }
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(3);
        canTurn = true;
    }
}
