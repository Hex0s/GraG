using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * Skrypt odpowiedzialny za zadanie obrażeń przez pocisk lecący np. rakieta.
 */
public class PociskDetonacja : MonoBehaviour {

	//Animacja przy uderzeniu
	public GameObject uderzeniePrefab;
    public GameObject kamienPrefab; 
    //Obrarzenie jakie zadaje (ile punktow zdrowia zabiera).
    public float obrazenia = 200f;
    public PlayerControler plcr;
	public float zasiegEksplozji = 3f;
    public float timer = 1f;
    public Texty tx;
    public AudioSource boom;
    public GameObject granat;

    void Start()
    {
       
            timer = tx.moc;
     
    }

    private void Update()
    {

        
        if (timer > 0)
        {
            
            timer -= 1 * Time.deltaTime;
        }
        if (timer <= 0)
        {
            Detonacja();
            
        }

        
   
    }


	

	void Detonacja()
    {
        GameObject particle;

        particle = (GameObject)Instantiate(kamienPrefab, granat.transform.position + granat.transform.forward, granat.transform.rotation);
    
		Vector3 punktDetonacji = transform.position ;
		
		if (uderzeniePrefab != null)
        {
			Instantiate(uderzeniePrefab, punktDetonacji, Quaternion.identity);
			
		}
		Destroy (gameObject);

		//Pobranie wszystkich obiektów w zasięgu pola rażenia pocisku.
		Collider[] colliders = Physics.OverlapSphere (punktDetonacji, zasiegEksplozji);
		//Iteracja w celu sprawdzenia czy obiekt znajdujący się w polu rażenia zawiera punkty zdrowia.
		foreach(Collider c in colliders)
        {
            float dist = Vector3.Distance(punktDetonacji, c.transform.position);
            Zdrowie Hp = c.GetComponent<Zdrowie>();
			if(Hp != null)
            {
                
				
				//Obliczenie obrażeń zgodnie z odstępem od pocisku. 
				//Im bliżej tym obrażenia większe im dalej tym mniejsze.
				float noweObrazenia = 1f - (dist / zasiegEksplozji); 
				Hp.otrzymaneObrazenia(obrazenia *  noweObrazenia);
			}

            Life hp = c.GetComponent<Life>();
            if (hp != null)
            {
                
                //Obliczenie obrażeń zgodnie z odstępem od pocisku. 
                //Im bliżej tym obrażenia większe im dalej tym mniejsze.
                float noweObrazenia = 1f - (dist / zasiegEksplozji);
                hp.otrzymaneObrazenia(obrazenia * noweObrazenia);
                plcr.hitDistance = -70 * noweObrazenia;
                plcr.currentJumpHeight = 10*noweObrazenia;
            }
            
           

        }
        float dist2 = Vector3.Distance(punktDetonacji,plcr.transform.position);
        boom.volume = 1 / dist2 * 15;
        boom.Play();
    }
}
