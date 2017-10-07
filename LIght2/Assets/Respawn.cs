using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Respawn : MonoBehaviour {
    public GameObject player;
    public GameObject point;
    public Button yes;
    public Button no;
    public Canvas gameOver;

    public Canvas hud;

    public Life lf;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
   public void Resp()
    {
        lf.hp = 100;
        player.transform.position = point.transform.position;
        gameOver.enabled = false;
        Debug.Log("res");
        Cursor.visible = false;
        hud.enabled = true;
        no.enabled = false;
        yes.enabled = false;
    }
}
