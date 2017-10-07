
using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {


	public CharacterController characterControler;
    public AudioSource aS;
    public GameObject sword;
    public bool hit = false;
    public float moveSpeed = 13.0f;
    public GameObject player;
	public float jumpHeight = 11.0f;
    public AI1 ai;
	public float currentJumpHeight = 0f;

    public float runSpeed = 19.0f;
    public float runSpeedDev = 50.0f;

    public float sensitivity = 3.0f;	
	public float mouseUpDown = 0.0f;

	public float mouseRangeUpDown = 90.0f;

    public int exhaustion = 0, exhaustionOnOff = 0;
    public float force;
    public float falling = 0.3f;
    public float hitDistance = -50;
    public float dev = 30;
    public bool devOnOff = false;
    void Start ()
    {
		characterControler = GetComponent<CharacterController>();
        
    }
	

	void Update()
    {
        keyboard();
		mouse();
        walksounds();
        Hitter();
    }

    private void Hitter()
    {
        if (hitDistance < 0)
        {
            if (characterControler.isGrounded)
            {

                hitDistance += 50 * Time.deltaTime;
            }
            else
            {
                hitDistance += 20 * Time.deltaTime;

            }
        }

        if (ai.dystans <= 2f)
        {
            hitDistance = -50;

        }
    
        
    }
    private void keyboard()
    {

        float moveForwardBack = Input.GetAxis("Vertical") * moveSpeed;

        float moveLeftRight = Input.GetAxis("Horizontal") * moveSpeed;


        if (characterControler.isGrounded && Input.GetButton("Jump"))
        {
            currentJumpHeight = jumpHeight;
        }

        else if (!characterControler.isGrounded)
        {

            currentJumpHeight += Physics.gravity.y * Time.deltaTime / falling;
        }



        if (Input.GetKey(KeyCode.LeftShift))//XD 69
        {
            exhaustion++;
            if (exhaustion >= 300)
            {
                moveSpeed = 5;
            }

        }
        else
        {
            if (exhaustion >= 1)
            {
                exhaustion--;
            }
        }
        if (exhaustion <= 150 && moveSpeed <= 13 && moveSpeed >= 4)
        {
            moveSpeed = 7;
        }

        if (Input.GetKeyDown("b") && devOnOff == false)
        {
            jumpHeight += dev;
            moveSpeed += runSpeedDev;
            devOnOff = true;


        }
        else if (Input.GetKeyDown("b") && devOnOff == true)
        {
            devOnOff = false;
            jumpHeight -= dev;
            moveSpeed -= runSpeedDev;

        }

        if (Input.GetKeyDown("left shift"))
        {
            moveSpeed += runSpeed;


        } else if (Input.GetKeyUp("left shift") && moveSpeed >= 8)
        {
            moveSpeed -= runSpeed;
        }

        
        if(hitDistance < 0)
        {


            Vector3 move = new Vector3(moveLeftRight, currentJumpHeight, hitDistance);

            move = transform.rotation * move;
            characterControler.Move(move * Time.deltaTime);

        }

        else
        {

            Vector3 move = new Vector3(moveLeftRight, currentJumpHeight, moveForwardBack);
            move = transform.rotation * move;
            characterControler.Move(move * Time.deltaTime);
        }









    }

	
	private void mouse()
    {

     
		float myszLewoPrawo = Input.GetAxis("Mouse X") * sensitivity;	
		transform.Rotate(0, myszLewoPrawo, 0);
		
		
		mouseUpDown -= Input.GetAxis("Mouse Y") * sensitivity;


        mouseUpDown = Mathf.Clamp(mouseUpDown, -mouseRangeUpDown, mouseRangeUpDown);
		
		Camera.main.transform.localRotation = Quaternion.Euler(mouseUpDown, 0, 0);
        //sword.transform.localRotation = Quaternion.Euler(mouseUpDown, 0, 0);
    }
    private void walksounds()
    {
        if (characterControler.isGrounded && (Input.GetKey("w") || Input.GetKey("d") || Input.GetKey("a") || Input.GetKey("s")))
        {

         
            aS.enabled = true;

        }
        else
        {

            aS.enabled = false;
        }

    }



}
