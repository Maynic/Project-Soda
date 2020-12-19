using System.Collections;
using UnityEngine;

namespace VikingCrew.Tools.UI {
	public class ScriptedDialogueBehaviour : MonoBehaviour {
        [System.Serializable]
        public class DialogueLine {
            [Tooltip("The transform doing the speaking. This could be a mouth, head or character transform depending on your scene")]
            public Transform speaker;
            [Tooltip("Time to delay from the previous message in the array")]
            public float delay = 2;
            [Multiline, Tooltip("What to say")]
            public string line = "Hello World!";
            [Tooltip("How to say it")]
            public SpeechBubbleManager.SpeechbubbleType speechBubbleType = SpeechBubbleManager.SpeechbubbleType.NORMAL;
        }

        public DialogueLine[] script;
        public bool doRestartAtEnd = true;
        public float bubbleTimeToLive = 3f;
        public bool isSpeaking = false;
        public bool allowSpeaking = false;
        // public bool isNearby = false;
        // public GameObject manager;
        // public SpeechBubbleManager manager;
        // public GameObject character;

		// Use this for initialization
		private void Start () {
            // manager = gameObject.transform.Find("Manager").gameObject.GetComponent<SpeechBubbleManager>();
            // character =  GameObject.FindGameObjectWithTag("MainCharacter");

            // StartCoroutine(FollowScript());
		}
        void Update(){
            if (!isSpeaking && allowSpeaking)
            {
                StartCoroutine(FollowScript());
            }
            if (!allowSpeaking)
            {
                // manager.Clear();
                isSpeaking = false;
            }
            // SpeechBubbleManager.Instance.AddSpeechBubble
            // (character.transform, "! ! !", SpeechBubbleManager.SpeechbubbleType.ANGRY, 3, Color.red, Vector3.up);
        }
        // public void isNearby(){
        //     manager.AddSpeechBubble(gameObject.transform, "TALK", SpeechBubbleManager.SpeechbubbleType.NORMAL, 5, Color.white, Vector3.up);
        // }
    
        // public void interact(){
            
        // }
        // void OnTriggerEnter(Collider target)
        // {
        //     if(target.tag == "MainCharacter")
        //     {
        //         // levelManager.GetComponent<LevelManager>().isSmart = true;
        //         // UnityEngine.SceneManagement.SceneManager.LoadScene("Menu_Win");
        //         isNearby();
        //     }

        // }
		
        private IEnumerator FollowScript() {
            isSpeaking = true;
            int index = 0;

            while (index < script.Length && allowSpeaking) {
                yield return new WaitForSeconds(script[index].delay);

                SpeechBubbleManager.Instance.AddSpeechBubble(script[index].speaker, script[index].line, script[index].speechBubbleType, bubbleTimeToLive, Color.white, Vector3.up);
                // manager.AddSpeechBubble(script[index].speaker, script[index].line, script[index].speechBubbleType, bubbleTimeToLive, Color.white, Vector3.up);
                index++;
                if (doRestartAtEnd && index == script.Length)
                    index = 0;
                
            }
        }
	}
} 