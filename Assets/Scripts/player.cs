using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeechBubbleManager = VikingCrew.Tools.UI.SpeechBubbleManager;


// [RequireComponent(typeof(CharacterController))]
public class player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 4.0f;
    private float jumpHeight = 0.3f;
    private float gravityValue = -9.81f;
    private Animator animator;
    private float lastRotY;
    private float level3timer = 0f;
    public GameObject levelManager;
    public GameObject camera;
    public GameObject lowSP;
    public GameObject SPBar;
    public GameObject coll;
    public int sp = 10;
    public bool isLevel2 = false;
    public bool isLevel3 = false;
    public bool isPaused = false;
    // public bool isMoving = false;
    GameObject pause;
    GameObject win;
    GameObject over;
    // public Transform speaker;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        levelManager =  GameObject.FindGameObjectWithTag("LevelManager");
        // if(!isLevel3){animator = GetComponentInChildren<Animator>();}
        animator = GetComponentInChildren<Animator>();
        lowSP =  GameObject.FindGameObjectWithTag("LowSP");
        SPBar =  GameObject.FindGameObjectWithTag("SP_Bar");
        camera =  GameObject.FindGameObjectWithTag("MainCamera");
        pause =  GameObject.FindGameObjectWithTag("MenuPause");
        win =  GameObject.FindGameObjectWithTag("MenuWin");
        over =  GameObject.FindGameObjectWithTag("MenuOver");
        lowSP.SetActive(false);
        pause.SetActive(false);
        win.SetActive(false);
        over.SetActive(false);

    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (isLevel3)
        {
            if(level3timer > 0)
            {controller.Move(gameObject.transform.forward * Time.deltaTime * 3f);}
            level3timer -= Time.deltaTime;

        }
        else {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            // if(!isLevel2){move = -move;}
            move = -move;
            controller.Move(move * Time.deltaTime * playerSpeed);
            // Animation
            if (move != Vector3.zero) {
                // if(isLevel2){move = -move;}
                gameObject.transform.forward = move;
                animator.SetFloat("Speed", 4f);
            }else { animator.SetFloat("Speed", 0f); }
            float angle = 0f;
            angle = (transform.eulerAngles.y - lastRotY) * 10;
            lastRotY = transform.eulerAngles.y;
            // animator.SetFloat("Speed", speed);
            animator.SetFloat("Direction", angle, 0.15f, Time.deltaTime);
        }

        if (Input.GetButtonDown("Cancel")){ ESC_Pause(); }
    }

    public void setMoving(){ level3timer = 1.5f; }
    public void turnLeft(){ gameObject.transform.Rotate(0.0f, -90.0f, 0.0f); }
    public void turnRight(){ gameObject.transform.Rotate(0.0f, 90.0f, 0.0f); }

    public void ESC_Pause(){
        if (isPaused)
        {
            Time.timeScale = 1;
            pause.SetActive(false);
            isPaused = false;
        }
        else{
            Time.timeScale = 0;
            pause.SetActive(true);
            isPaused = true;       
        }

    }

    public void checkSP(){
        camera.GetComponent<cameraf>().shakeDuration = 0.5f;
        levelManager.GetComponent<LevelManager>().resp = sp;

        if (sp <= 0)
        {
            {SPBar.transform.Find("h1").gameObject.SetActive(false);}
            Time.timeScale = 0;
            over.SetActive(true);
        }
        if (sp <= 2) {
            SPBar.transform.Find("h2").gameObject.SetActive(false);
            lowSP.SetActive(true);
        }
        if (sp <= 4) {SPBar.transform.Find("h3").gameObject.SetActive(false);}
        if (sp <= 6) {SPBar.transform.Find("h4").gameObject.SetActive(false);}
        if (sp <= 8) {SPBar.transform.Find("h5").gameObject.SetActive(false);}
    }

        // void OnTriggerStay(Collider col)
    void OnCollisionEnter(Collision col)
    // void OnCollisionStay(Collision col)
    {
        // Debug.Log("Do something else here");

        if(col.gameObject.tag == "Car") {
            // Debug.Log("Do something else here");
            sp = -5;
            checkSP();    
        }        
        // if(col.gameObject.tag == "Walker") {
        //     sp -= 1;
        //     camera.GetComponent<cameraf>().shakeDuration = 0.5f;
        //     checkSP();
        // }
        // if(col.gameObject.tag == "Biker") {
        //     sanityPoint -= 2;
        // }
    }
    // public void sorry(){
    //                 SpeechBubbleManager.Instance.AddSpeechBubble
    //         (gameObject.transform, "Sorry", SpeechBubbleManager.SpeechbubbleType.NORMAL, 3, Color.white, Vector3.up);
    // }
    void OnTriggerEnter(Collider target)
    {
        if(target.tag == "Finish")
        {
            // levelManager.GetComponent<LevelManager>().isSmart = true;
            Time.timeScale = 0;
            win.SetActive(true);        }
        if(target.gameObject.tag == "Walker") {
            sp -= 1;
            // coll = ;
            // coll.GetComponent<walker>().playerSpeed = 0f;
            if(!isLevel2)
{            string s = "Excuse Me";
            if(Random.Range(0f, 1.0f)>0.5f){
                s = "Sorry!";
            }

            SpeechBubbleManager.Instance.AddSpeechBubble
            (target.gameObject.transform, s, SpeechBubbleManager.SpeechbubbleType.NORMAL, 3, Color.white, Vector3.up);}
            checkSP();
        }
        // if(target.tag == "SmartFinish")
        // {
        //     levelManager.GetComponent<LevelManager>().isSmart = true;
        //     UnityEngine.SceneManagement.SceneManager.LoadScene("Menu_Win");
        // }
    }
}
// {
//     private CharacterController controller;
//     // public GameObject UI_SP;
//     private Vector3 playerVelocity;
//     private bool groundedPlayer;
//     private float playerSpeed = 16.0f;
//     private float jumpHeight = 1.0f;
//     private float gravityValue = -9.81f;
//     // private float timeLimit = 0.0f;
//     // private bool isMoving = false;
//     Vector3 move = Vector3.zero; 
//     public int sanityPoint = 10;

//     private void Start()
//     {
//         controller = GetComponent<CharacterController>();
//         // UI_SP = GameObject.FindGameObjectWithTag("UI_SP");

//     }

//     // IEnumerator ExampleCoroutine(Vector3 m)
//     // {
//     //     //Print the time of when the function is first called.
//     //     // Debug.Log("Started Coroutine at timestamp : " + Time.time);

//     //     //yield on a new YieldInstruction that waits for 5 seconds.
//     //     // yield return new WaitForSeconds(1);
//     //     float startTime = Time.time;
//     //     while(Time.time < (startTime + 1f))
//     //     {
//     //         controller.Move(m * Time.smoothDeltaTime * playerSpeed);
//     //         yield return null;
//     //     }
//     //     yield return new WaitForSeconds(0.5f);
//     //     isMoving = false;

//     //     //After we have waited 5 seconds print the time again.
//     //     // Debug.Log("Finished Coroutine at timestamp : " + Time.time);
//     // }

//     void Update()
//     {

//         move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
//         move = -move;
//         // bool i = Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical");
//         controller.Move(move * Time.smoothDeltaTime * playerSpeed);
//         if (move != Vector3.zero){ gameObject.transform.forward = move; }


//         // if (move != Vector3.zero && !isMoving) {
//         // if (i && !isMoving) {
//             // gameObject.transform.forward = move;
//             // isMoving = true;
//             // StartCoroutine(ExampleCoroutine(move));
//         // }

//         // UI_SP.GetComponent<UnityEngine.UI.Text>().text = "SP: " + sanityPoint + "/10"; 

//         groundedPlayer = controller.isGrounded;
//         if (groundedPlayer && playerVelocity.y < 0)
//         {
//             playerVelocity.y = 0f;
//         }
//         // Changes the height position of the player..
//         if (Input.GetButtonDown("Jump") && groundedPlayer)
//         {
//             playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
//         }

//         playerVelocity.y += gravityValue * Time.deltaTime;
//         controller.Move(playerVelocity * Time.deltaTime);
//         // gameObject.transform.Rotate(-22.6f, 0.0f, 0.0f, Space.Self);
//         if (sanityPoint < 1)
//         {
//             sanityPoint = 10;
//             controller.enabled = false;
//             gameObject.transform.position = new Vector3(-4.0f, 4.0f, -12.0f);
//             controller.enabled = true;

//         }

//     }

//     // void OnTriggerStay(Collider col)
//     void OnCollisionEnter(Collision col)
//     {
//         if(col.gameObject.tag == "Car") {
//             sanityPoint -= 20;
//         }        
//         if(col.gameObject.tag == "Walker") {
//             sanityPoint -= 1;
//         }
//         if(col.gameObject.tag == "Biker") {
//             sanityPoint -= 2;
//         }
//     }
// }