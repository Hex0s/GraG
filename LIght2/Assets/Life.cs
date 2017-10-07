using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour {
    public float hp = 100.0f;
    public float maxhp = 100f;
    public Canvas gameOver;
    public Canvas menu;
    public Canvas hud;
    public Button no;
    public Button yes;
    public Image hpBarG;
    public Image hpBarO;
    public Image hpBarR;
    public float hpBarNumber;
    public Blood blood;
    public float damage;
    // Use this for initialization
   
    public void otrzymaneObrazenia(float obrazenia)
    {
      
        hp -= obrazenia;
        blood.opacity = obrazenia/hp;
    }
    // Update is called once per frame
    void Update ()
    {
        
        if (hp <= 0)
        {
            gameOver.enabled = true;
            hud.enabled = false;
            menu.enabled = false;
            yes.enabled = true;
            no.enabled = true;
        }
        else
        {
            gameOver.enabled = false;

        }

        hpBarNumber = hp/maxhp;
        hpBarG.fillAmount = hpBarNumber;
        hpBarO.fillAmount = hpBarNumber;
        hpBarR.fillAmount = hpBarNumber;
        if (hpBarNumber <= 0.5f)
        {
            hpBarG.enabled = false;
            hpBarO.enabled = true;
            hpBarR.enabled = false;
        }
        if (hpBarNumber > 0.5f)
        {
            hpBarG.enabled = true;
            hpBarO.enabled = false;
            hpBarR.enabled = false;
        }
        if (hpBarNumber <= 0.15f)
        {
            hpBarG.enabled = false;
            hpBarO.enabled = false;
            hpBarR.enabled = true;
        }
    }
}
