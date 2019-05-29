using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxManager : MonoBehaviour {

	public static FxManager Instancia;
	public AudioSource FxAudio;
	public AudioClip[] SonidosFx;


	void Awake()
	{
		// referencia a este objeto para facilitar el acceso desde otros scripts
		if (Instancia == null)
		{
			Instancia = this;
		}
		else
		{
			DestroyObject(gameObject);
		}
		DontDestroyOnLoad (Instancia);       
	}
}
