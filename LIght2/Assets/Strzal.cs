using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Strzal : MonoBehaviour
{

    public float range = 100.0f;
    public float wait = 0.4f;
    public float odliczanieDoStrzalu = 0f;
    public float damage = 50.0f;
    public AudioSource shoot;
    public AudioSource reload;
    public int ammo = 10;
    public Text anno;
    public Animator animator;
  
    void Start()
    {

    }


    void Update()
    {

        attack();

        

    }


    void attack()
    {
        if (odliczanieDoStrzalu < wait)
        {
            odliczanieDoStrzalu += Time.deltaTime;
        }


        if (Input.GetKeyDown("r") && ammo <= 9)
        {
            reload.Play();
            ammo = 10;
            anno.text = ammo.ToString() + ("/10");
        }
        if (Input.GetMouseButton(0) && odliczanieDoStrzalu >= wait && ammo >= 1 && !reload.isPlaying)
        {
       
            odliczanieDoStrzalu = 0;
            ammo--;
            shoot.Play();
            anno.text = ammo.ToString() + ("/10");



            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo;


            if (Physics.Raycast(ray, out hitInfo, range))
            {

                Vector3 hitPoint = hitInfo.point;

                GameObject go = hitInfo.collider.gameObject;


                hit(go);//XD 69

                

            }
            if (animator != null)
            {

                animator.SetTrigger("Bom");

            }
        }

    }
 
	void hit( GameObject go)
    {
	
		Zdrowie hp = go.GetComponent<Zdrowie>();
		
		if(hp != null)
        {
			
			hp.otrzymaneObrazenia(damage);
		}
	}
}
