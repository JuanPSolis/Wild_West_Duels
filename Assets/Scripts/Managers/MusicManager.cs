using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicManager : MonoBehaviour {


    public AudioSource _audioSource;
	public GameManager miManager;
	public static MusicManager instance;
    public AudioClip MusicaMenu;
    public AudioClip MusicGML;

    void Awake()
    {
        // referencia a este objeto para facilitar el acceso desde otros scripts
		if (instance== null)
		{
			instance = this;
		}
		else
		{
			DestroyObject(gameObject);
		}
		DontDestroyOnLoad (instance);
        SceneManager.sceneLoaded += sceneLoaded;        
	}

    public void PlayMusic(bool b = true)

    {
        if (b == true)
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }

    }

    // puesto a disposición de otros scripts para que puedan iniciar la música

    public void PlayMusic()

    {
        PlayMusic(true);
    }

    void sceneLoaded (Scene scene, LoadSceneMode mode)

    {
        if (scene.name != "MenuInicio" && GameManager.SonidoActivo == true)
        {
            _audioSource.Play();
        }


    }

    void OnDestroy()

    {
        SceneManager.sceneLoaded -= sceneLoaded;
    }
	

}
