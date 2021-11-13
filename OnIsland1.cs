using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnIsland1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boat;
    public GameObject person;
    void Start()
    {
        //boat.SetActive(false);
        Instantiate(person);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
