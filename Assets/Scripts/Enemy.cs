using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private float _speed=1f;

    [SerializeField]
    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();

        if (_anim == null)
        {
            Debug.LogError("The animator is NULL");
        }

    }

    void Update()
    {
        transform.Translate(new Vector3(0,-1,0)*_speed*Time.deltaTime);
		 
		if(transform.position.y<0.09f){
		
		float randomX= Random.Range(-4f,4f);
		
		transform.position = new Vector3(randomX,3.7f,0);
		
		}
    }
	
	private void OnTriggerEnter2D(Collider2D other){
	
	if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            Destroy(this.gameObject, 2.8f);
        }

        if (other.tag == "Laser")
        {
            Score.scoreValue += 100;
            Destroy(other.gameObject);
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            Destroy(this.gameObject, 2.8f);
        }
	
	
	}
	
}
