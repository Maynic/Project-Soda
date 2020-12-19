using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraf : MonoBehaviour
{
    public GameObject mainCharacter;
    public bool isLevel2 = false;

	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;
	
	// How long the object should shake for.
	public float shakeDuration = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	// public float shakeAmount = 0.7f;
	public float shakeAmount = 0.2f;
	public float decreaseFactor = 1.0f;
	
	Vector3 originalPos;

    // public void shakeC(float time){
    //     shakeDuration = time;
    // }

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
        // if (isLevel2)
        // {
        //     transform.position = new Vector3(mainCharacter.transform.position.x, mainCharacter.transform.position.y+7.0f, mainCharacter.transform.position.z-27.0f);

        // }
        // else
        // {
            transform.position = new Vector3(mainCharacter.transform.position.x, mainCharacter.transform.position.y+7.0f, mainCharacter.transform.position.z+27.0f);
        // }
	// void Update()
	// {
		if (shakeDuration > 0)
		{
			// camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			camTransform.localPosition = transform.position + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			// camTransform.localPosition = originalPos;
			camTransform.localPosition = transform.position;
		}
	// }
    }

	
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	
	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}


}
