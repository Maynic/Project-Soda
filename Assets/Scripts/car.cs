using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SWS {
public class car : MonoBehaviour
{
    // private CharacterController controller;
    // private Vector3 playerVelocity;
    // private bool groundedPlayer;
    // private float playerSpeed = 48.0f;
    // private float jumpHeight = 1.0f;
    // private float gravityValue = -90.81f;
    // private float timeLimit = 0.0f;
    // private bool isMoving = false;
    // Vector3 move = Vector3.back;
    // bool canTurn = true;     
    public PathManager pathContainer;
    public float speed = 3.5f;

    void Start()
    {
        // controller = GetComponent<CharacterController>();
        gameObject.GetComponent<splineMove>().speed = speed;
        gameObject.GetComponent<splineMove>().pathContainer = pathContainer;
        gameObject.GetComponent<splineMove>().StartMove();
    }

    // Update is called once per frame
    void Update()
    {
        // controller.Move(move * Time.smoothDeltaTime * playerSpeed);
        // if (move != Vector3.zero){ gameObject.transform.forward = move; }
    }
    // void OnTriggerStay(Collider col)
    // {
    //     if(canTurn && col.gameObject.tag == "CarZone")
    //     {
    //         move = -1 * move;
    //         canTurn = false;
    //         StartCoroutine(ExampleCoroutine());
    //     }
    // }
    // IEnumerator ExampleCoroutine()
    // {
    //     yield return new WaitForSeconds(3);
    //     canTurn = true;
    // }
}
}