using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Granate : MonoBehaviour
{

    public GameObject kamienPrefab;
    public float predkosc = 50;
    public PociskDetonacja det;
    public AudioSource boom;
    public float number = 3f;
    public Text ammo;
    // Update is called once per frame
    void Update()
    {
        ammo.text = number + "/3";

        if (Input.GetMouseButtonDown(0) && number > 0)
        { //Jezeli nacisniety przycisk fire
            number--;
            det.enabled = !det.enabled;
            GameObject kamien;
            //Utworzenie instatncji poocisku i nadanie mu pozycji kamery.
            
            kamien = (GameObject)Instantiate(kamienPrefab, Camera.main.transform.position + Camera.main.transform.forward, Camera.main.transform.rotation);
            kamien.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * predkosc, ForceMode.Impulse);
            det.enabled = !det.enabled;
            

        }

    }
}