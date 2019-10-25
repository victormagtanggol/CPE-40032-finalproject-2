using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private AudioClip _clip;
    [SerializeField]
	private float _speed=3.0f;
    [SerializeField]
    private int powerupID;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.down*_speed*Time.deltaTime);
        if(transform.position.y<0.09f){
		
		
		}
        if(transform.position.y<-4f){
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other){
	
	if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            AudioSource.PlayClipAtPoint(_clip, transform.position);

            if (player != null)
            {
                switch(powerupID)

        {
    case 0:
    player.TripleShotActive();
    Debug.Log("Collected Triple Shot Boost");
    break;
    case 1:
        player.SpeedPowerUpActive();
    Debug.Log("Collected Speed Boost");
    break;  
    case 2:
    player.ShieldsActive();
    Debug.Log("Shields Collected");
    break;
    default:
    Debug.Log("Default value");
       break;
}
            }
            Destroy(this.gameObject);
        }
	}
}
