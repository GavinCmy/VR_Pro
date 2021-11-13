using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDisperse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("CloudStart");
        for (int i = 0; i < transform.childCount; i++)
        {
            Debug.Log(transform.GetChild(i).name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
