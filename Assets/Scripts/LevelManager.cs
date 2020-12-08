using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int levelN = 0;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
