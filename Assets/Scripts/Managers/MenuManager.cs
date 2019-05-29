using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	
    //referencias
	public GameManager miManager;
    private int Sonido;
    public Text Audio;
	public Text Fx;
	public MusicManager miMusic;
	public FxManager miFx;

    void Start ()
    {
		//recogida de instancias
        miManager = GameManager.Instancia;
		miMusic = MusicManager.instance;
		miFx = FxManager.Instancia;
		miMusic._audioSource.clip = miMusic.MusicaMenu;

		//analizador para ver si la musica esta activa y lo muestra en pantalla
		if (GameManager.SonidoActivo == true) 
		{
			miMusic.PlayMusic ();
			Audio.text = "yes";
		} 
		else if (GameManager.SonidoActivo == false)
		{
			miMusic.PlayMusic (false);
			Audio.text = "no";
		}			

		//analizar si los fx estan activos, ponerlo en pantalla y mutearlo si es necesario
		if (GameManager.SonidoFXActivo == false)
		{
			miFx.FxAudio.mute = true;
			Fx.text = "no";
		}
		else if (GameManager.SonidoFXActivo == true)
		{
			Fx.text = "yes";
		}
    }
	
    //este script solo controla las opciones 
    //de los botones del menu de inicio
    public void EmpezarJegoTrn()
    {
		miFx.FxAudio.PlayOneShot (miFx.SonidosFx [3]);
        miManager.EmpezarJegoTrn();
    }
    public void EmpezarJegoDuel()
    {
		miFx.FxAudio.PlayOneShot (miFx.SonidosFx [4]);
        miManager.EmpezarJegoDuel();
    }
    public void Creditos()
    {
        SceneManager.LoadScene ("Creditos");
    }
	public void HowToPlay()
	{
		SceneManager.LoadScene ("Instrucciones");
	}
    public void AudioSiNo()
    {
        if (GameManager.SonidoActivo == true)
        {
            GameManager.SonidoActivo = false;
            Audio.text = "no";
			miMusic.PlayMusic (false);
        }
        else if (GameManager.SonidoActivo == false)
        {
            GameManager.SonidoActivo = true;
            Audio.text = "yes";
			miMusic.PlayMusic (true);
        }
    }
	public void FxSiNo()
	{
		if (GameManager.SonidoFXActivo == true)
		{
			GameManager.SonidoFXActivo = false;
			miFx.FxAudio.mute = true;
			Fx.text = "no";
		}
		else if (GameManager.SonidoFXActivo == false)
		{
			GameManager.SonidoFXActivo = true;
			miFx.FxAudio.mute = false;
			Fx.text = "yes";
		}
	}

}
