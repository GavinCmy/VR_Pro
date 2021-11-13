using UnityEngine;
using System.Collections;
public class CameraFollow : MonoBehaviour
{
	public GameObject target;
	public Vector3 position;
	private Vector3 offset;
	public float mouseSpeed = 100f;
	private float ymove,xmove;

	void Start()
	{
		//offset = target.transform.position - this.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		//Follow();
		//Scale();
		Rotate();
	}
	void Follow()
	{
		this.transform.position = target.transform.position - offset;
	} 

	void Rotate()
	{
		float x, y;
		x = Input.GetAxis("Mouse X")*mouseSpeed*Time.deltaTime;
		y = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime ;
		xmove = xmove + x;
		ymove = ymove - y;
		this.transform.localRotation = Quaternion.Euler(ymove,xmove, 0);
		//transform.Rotate(Vector3.up * x);
	}

}