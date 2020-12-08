using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraf : MonoBehaviour
{
    public GameObject mainCharacter;
    void Start()
    {
        mainCharacter =  GameObject.FindGameObjectWithTag("MainCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position.x = mainCharacter.transform.position.x;
        // transform.position.z = mainCharacter.transform.position.z;
        // transform.position = new Vector3(mainCharacter.transform.position.x, transform.position.y, mainCharacter.transform.position.z-30.0f);
        transform.position = new Vector3(mainCharacter.transform.position.x, mainCharacter.transform.position.y+7.0f, mainCharacter.transform.position.z+27.0f);

    }
}
