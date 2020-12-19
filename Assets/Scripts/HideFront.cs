using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideFront : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject toHide;
    public GameObject replacement;

    void Start()
    {
        // animator = GetComponentInChildren<Animator>();
        // lowSP =  GameObject.FindGameObjectWithTag("LowSP");
        toHide = gameObject.transform.Find("ToHide").gameObject;
        replacement = gameObject.transform.Find("Replacement").gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider target)
    {
        if(target.tag == "MainCharacter")
        {
            toHide.SetActive(false);
            replacement.SetActive(true);
        }
    }
    
    void OnTriggerExit(Collider target)
    {
        if(target.tag == "MainCharacter")
        {
            toHide.SetActive(true);
            replacement.SetActive(false);
        }
    }
}
