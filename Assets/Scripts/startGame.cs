using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour {

    public GameObject _startFlashText;

	// Use this for initialization
	void Start () {
        InvokeRepeating("startFlashText", 0f, 0.2f);
	}

    void startFlashText()
    {
        _startFlashText.SetActive(!_startFlashText.activeSelf);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Return))
        {
            Livescript.livesValue = 3;
            Score.scoreValue = 0;
            SceneManager.LoadScene(1);
        }
    }
}
