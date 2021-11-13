using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCrash : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject WaterEffect;
    //public GameObject Stone;
    private Vector3 pos;
    //public float UpForce = 10f;
    void Start()
    {
        Debug.Log("Start");
    }
    void DestroyWater()
    {
        Destroy(WaterEffect);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stone"))
        {
            pos = other.gameObject.transform.position;
            GameObject.Instantiate(WaterEffect, pos, Quaternion.identity);
            Debug.Log("Collided");
        //    Rigidbody rb = Stone.GetComponent<Rigidbody>();
        //    rb.AddForce(0, UpForce, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
