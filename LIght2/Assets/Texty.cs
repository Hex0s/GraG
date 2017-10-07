using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texty : MonoBehaviour {

    public Text liczba;
   public float moc = 3;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            // scroll up
            moc += 0.10f;
            liczba.text = (System.String.Format("{0:N2}", moc)) + "sec";
        }
        else if (d < 0f)
        {
            // scroll down
            moc -= 0.10f;
            liczba.text = (System.String.Format("{0:N2}", moc)) + "sec";
        }




	}
}
