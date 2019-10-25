using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _shieldVisualizer;

    [SerializeField]
    private Animator _anim;

    [SerializeField]
    private AudioClip _laserSoundClip;
    private AudioSource _audioSource;

    [SerializeField]
	private int _lives = 3;
	private float _fireRate = 0.5f;
	private float _canFire = -1f;

	[SerializeField]
	private float _speedMultiplier = 2f;
	private SpawnManager _spawnManager;
	[SerializeField]
	private float _speed=5.0f;

	private bool _isSpeedPowerUpActive = false;
	private bool _isTripleShotActive = false;
	private bool _isShieldActive = false;

	[SerializeField]
	private GameObject _tripleShot;
	[SerializeField]
	private GameObject _laserPrefabs;

    void Start()
    {
        _anim = GetComponent<Animator>();
        if (_anim == null)
        {
            Debug.LogError("The animator is NULL");
        }
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _isShieldActive = false;
        _shieldVisualizer.SetActive(false);
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("Audio Source on the player is NULL");

        }
        else {
            _audioSource.clip = _laserSoundClip;
        }
    }

    // Update is called once per frame
    void Update()
    {
		CalculateMovement();
		if (Input.GetKeyDown(KeyCode.Space) && Time.time >_canFire){
		FireLaser();
		}

		
	}
		
		void CalculateMovement(){
		float horizontalInput=Input.GetAxis("Horizontal");
		float verticalInput=Input.GetAxis("Vertical");
		
		
		transform.Translate(new Vector3(0,1,0) *verticalInput*_speed*Time.deltaTime);
		transform.Translate(Vector3.right *horizontalInput*_speed*Time.deltaTime);
		
		if(transform.position.y >=3.5f){
			transform.position= new Vector3(transform.position.x,-2.2f,0);
			} 
		
		
		if(transform.position.x >=3.5f){
		
			transform.position= new Vector3(-3.5f,transform.position.y,0);
			
			}
		else if(transform.position.x <-3.5f){
		
		
			transform.position= new Vector3(3.5f,transform.position.y,0);
			
			}
		}
		
		void FireLaser()
		{
        _audioSource.Play();
        _canFire = Time.time + _fireRate;
		if (_isTripleShotActive == true){
		Instantiate(_tripleShot, transform.position+new Vector3(0, -1.2f, 0), Quaternion.identity);
										}
		else{
		Instantiate(_laserPrefabs,transform.position+new Vector3(0, 0.3f, 0),Quaternion.identity);
			}
		
		}
		
		public void Damage()
    	{

		if(_isShieldActive == true)
		{
		_isShieldActive = false;
        _shieldVisualizer.SetActive(false);
        return;
		}

        _lives -= 1;
        Livescript.livesValue -= 1;
        if (_lives < 1)
        	{
			_spawnManager.OnPlayerDeath();
            _anim.SetTrigger("PlayerDestroyed");
            _speed = 0;
            Destroy(this.gameObject,2.8f);
            Debug.Log("DEDSU");
         
            SceneManager.LoadScene(2);
        }
			   
    	}

		public void ShieldsActive()
		{
		_isShieldActive = true;
        _shieldVisualizer.SetActive(true);
    }

		public void TripleShotActive(){
				_isTripleShotActive = true;
				Debug.Log("true");
				StartCoroutine(TripleShotPowerDownRoutine());
		}

		IEnumerator TripleShotPowerDownRoutine(){
			while(_isTripleShotActive == true){
				yield return new WaitForSeconds(5.0f);
				_isTripleShotActive = false;

			}

		}
		public void SpeedPowerUpActive(){
		_isSpeedPowerUpActive = true;
		_speed *= _speedMultiplier;
		StartCoroutine(SpeedPowerDownRoutine());
		}
	
		IEnumerator SpeedPowerDownRoutine(){
		while (_isSpeedPowerUpActive == true)
		{
		yield return new WaitForSeconds(5.0f);
		_isSpeedPowerUpActive = false;
		_speed /= _speedMultiplier;
		}

}	
		
    }
	
