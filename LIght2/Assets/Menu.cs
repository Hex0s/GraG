using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Canvas menuUI;
public class Menu : MonoBehaviour
{

    public Canvas menuUI;
    public Button btnStart;
    public Button btnExit;
    public AudioSource aS;
    public Canvas eq;
    

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
   
        if (Input.GetKeyUp(KeyCode.Escape))
        {

            menuUI.enabled = !menuUI.enabled;
            btnStart.enabled = !btnStart.enabled;
            

        }

        if (menuUI.enabled)
        {

            btnStart.enabled = true;
            btnExit.enabled = true;
            aS.enabled = false;
        }
        else
        {
            
           
            btnExit.enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {

            eq.enabled = !eq.enabled;


        }
    }
    public void Zmiana()
    {
        menuUI.enabled = !menuUI.enabled;
        btnStart.enabled = !btnStart.enabled;     
    }
    public void End()
    {
        Application.Quit();
        Debug.Log("wyl");
    }
}

