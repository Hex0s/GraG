using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Blood : MonoBehaviour {
    public Texture2D blood;
    public float opacity = 0;
    public bool hit = false;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
    void OnGUI()
    {
        
        if (opacity < 0)
        {
            opacity = 0;
        }
        if (opacity > 2)
        {

            opacity = 2;
        }
        if (opacity > 0)
        {
            opacity -= 0.001f;
            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, opacity);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blood, ScaleMode.StretchToFill);
            
        }

        
    }
}
