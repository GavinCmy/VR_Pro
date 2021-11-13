using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{   
    private enum mode{player,boat};
    public float speed = 6.0F;
    public bool MoveMode=true;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float rotateSpeed = 15f;
    private Vector3 moveDirection = Vector3.zero;

    public Transform _camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void BoatRotate()
    {
        float rSpeed = Input.GetAxis("Horizontal");
        transform.Rotate(0, rotateSpeed*rSpeed * Time.deltaTime, 0);
    }
    void BoatFoward()
    {     
        moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
    }
    void BoatVertical()
    {
        moveDirection = new Vector3(Horizontal, 0, Vertical);
        moveDirection = _camera.TransformDirection(moveDirection);
        moveDirection *= speed;
    }

    int Vertical = 0;
    int Horizontal = 0;
    void Update()
    {

        HandClickManager.Instance.HandClickOperation(this.gameObject, HandType.BothHands, HandKeyType.OnTouchPadUpPress, () => {
            Vertical = 1;
        });
        HandClickManager.Instance.HandClickOperation(this.gameObject, HandType.BothHands, HandKeyType.OnTouchPadDownPress, () => {
            Vertical = -1;
        });
        HandClickManager.Instance.HandClickOperation(this.gameObject, HandType.BothHands, HandKeyType.OnTouchPadUpPressUp, () => {
            Vertical = 0;
        });
        HandClickManager.Instance.HandClickOperation(this.gameObject, HandType.BothHands, HandKeyType.OnTouchPadDownPressUp, () => {
            Vertical = 0;
        });



        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            //Debug.Log("Grounded");
            //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            if (MoveMode)//1 ´ú±í´¬
            {
             //   BoatFoward();
             //   BoatRotate();
            }
            else
            {
                BoatVertical();

            }
            
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
