using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Zdrowie hp;
    public GameObject hpBarG;
    public GameObject hpBarO;
    public GameObject hpBarR;
   public float hpBarNumber;
  //0.234
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        

        hpBarNumber = hp.hp / hp.maxHp * 0.234f;
        hpBarG.transform.localScale = new Vector3(hpBarNumber, 0.3316536f, 1);
        hpBarO.transform.localScale = new Vector3(hpBarNumber, 0.3316536f, 1);
        hpBarR.transform.localScale = new Vector3(hpBarNumber, 0.3316536f, 1);








         if (hpBarNumber <= 0.117f)
        {
            hpBarG.SetActive(false);
            hpBarO.SetActive(true);
            hpBarR.SetActive(false);
         }
            if (hpBarNumber > 0.117f)
            {
            hpBarG.SetActive(true);
            hpBarO.SetActive(false);
            hpBarR.SetActive(false);
        }
            if (hpBarNumber <= 0.036f)
            {
            hpBarG.SetActive(false);
            hpBarO.SetActive(false);
            hpBarR.SetActive(true);
        }
        }
}
