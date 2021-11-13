using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmbarkBoat : MonoBehaviour
{
    // Start is called before the first frame update
    public bool rowBoat = true;
    public GameObject boat;
    public GameObject personOnIsland;
    public bool triggered = false;
    void Start()
    {
        /*if (rowBoat)
        {
            Debug.Log("Create the boat");
            Destroy(personOnIsland);
            Instantiate(boat);
            //boat.SetActive(true);            
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && triggered == false)
        {
            Debug.Log("Space");
            Instantiate(boat);
            triggered = true;
        }
    }
}
