using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cardynal : MonoBehaviour {
    public Canvas menu;
    public Canvas gameOver;
    public PlayerControler pc;
    public Granate granate;
    public Image warning;
    public Texty tx;
    public float gun = 1;
    public Strzal pistol;
    public Image gunimage;
    public Image granateimage;
    public Canvas eq;
    public Text ammo;
    public GameObject gunPistol;
    // Use this for initialization
    void Start()
    {
        if (gun == 2)
        {
            granate.enabled = true;
        }
        if (gun == 1)
        {
            pistol.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        AllTime();
        Warning();
    
    }
    public void AllTime()
    {

        if (menu.enabled == true || gameOver.enabled == true || eq.enabled == true)
        {
            Time.timeScale = 0;
            pc.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            pc.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            if (gun == 2)
            {
                granate.enabled = true;
                gunimage.enabled = false;
                granateimage.enabled = true;
                ammo.text = granate.number + "/3";
                gunPistol.SetActive(false);
            }
            else
            {
                granate.enabled = false;
            }
            if (gun == 1)
            {
                pistol.enabled = true;
                gunimage.enabled = true;
                granateimage.enabled = false;
                ammo.text = pistol.ammo.ToString() + ("/10");
                gunPistol.SetActive(true);
            }
            else
            {
                pistol.enabled = false;
            }

            if (Input.GetKeyUp("1"))
            {
                gun = 1;
            }
            if (Input.GetKeyUp("g"))
            {
                gun = 2;
            }
        }


    }

    public void Warning()
    {
        if (tx.moc >= 0.50f)
        {
            warning.enabled = false;
        }
        else
        {
            warning.enabled = true;

        }
    }
   

}
