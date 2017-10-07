using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI1 : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float dystans;
    public float rotationSpeed = 100;
    public CharacterController characterController;
    public float currentJumpHeight;
    public Life hpPlayer;
    public PlayerControler pc;
    public Rigidbody rb;
    public float colDown = 4;
    public float obrazenia = 11;
    public Transform xbotx;
    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        
       if (!characterController.isGrounded)
        {

            currentJumpHeight += Physics.gravity.y * Time.deltaTime;
        }

        dystans = Vector3.Distance(transform.position,player.position);

        if ( dystans <= 100)
        {
            Vector3 playerPoz = new Vector3(player.position.x, xbotx.position.y, player.position.z);
            // transform.LookAt(new Vector3(player.position.x, player.position.y, player.position.z));
            xbotx.rotation = Quaternion.Slerp(xbotx.rotation, Quaternion.LookRotation(playerPoz - xbotx.position), rotationSpeed * Time.deltaTime);

            if (dystans <= 90 && dystans >= 1.9f)
            {

                transform.position += transform.forward * speed * Time.deltaTime;
            }
           
        }
        if(dystans <= 2f)
        {
         
      
                hpPlayer.otrzymaneObrazenia(obrazenia);
                colDown = 4;
          
        }
        Vector3 move = new Vector3(0, currentJumpHeight, 0);
        characterController.Move(move * Time.deltaTime);
        
    }

}
