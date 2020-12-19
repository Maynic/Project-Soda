using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position;
        pos.y += 1;
        VikingCrew.Tools.UI.SpeechBubbleManager.Instance.AddSpeechBubble(pos, "Hello world!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
