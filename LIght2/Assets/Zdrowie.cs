using UnityEngine;
using System.Collections;

/**
 * Skrypt zdrowia.
 * Jezeli obiekt ma ten skrypt to znaczy, że ma zdrowie ktore mozna mu zabrac.
 */
public class Zdrowie : MonoBehaviour {

	//Punkty zdrowia.
	public float hp = 100.0f;
    public float maxHp = 100;
    //Zadanie obrażeń.
    private void Start()
    {
        
    }
    public void otrzymaneObrazenia(float obrazenia)
    {
		hp -= obrazenia;
	}


    void Update()
    {
		if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
		
	}

}
