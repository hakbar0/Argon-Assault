using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("LevelDelay", 3f);
	}
	
    void LevelDelay()
    {
        SceneManager.LoadScene(1);
    }

	private void Awake()
	{
        DontDestroyOnLoad(this.gameObject);
	}
}
