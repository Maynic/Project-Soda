using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VikingCrew.Tools.UI {

    public class AlertSystem : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject character;
        AudioSource audioData;
        public float timer = 0f;
        public bool hasBubble = false;
        void Start()
        {
            character =  GameObject.FindGameObjectWithTag("MainCharacter");
            audioData = GetComponent<AudioSource>();

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = character.transform.position;
            if(hasBubble){ 
                timer += Time.deltaTime;
                if(timer>3.5f){
                    timer = 0f;
                    hasBubble = false;
                }
            }
        }
        void alert(){
            SpeechBubbleManager.Instance.AddSpeechBubble
            (character.transform, "! ! !", SpeechBubbleManager.SpeechbubbleType.ANGRY, 3, Color.red, Vector3.up);
            audioData.time = 0.3f;
            audioData.Play();
            hasBubble = true;
        }
        // void OnCollisionEnter(Collision col)
        void OnTriggerEnter(Collider col)
        {
            // Debug.Log("Do something else here");

            if(!hasBubble && col.gameObject.tag == "Car") {
                alert();
                // Debug.Log("Do something else here");
            }        
            // if(col.gameObject.tag == "Walker") {
            //     sanityPoint -= 1;
            // }
            // if(col.gameObject.tag == "Biker") {
            //     sanityPoint -= 2;
            // }
        }
    }
}