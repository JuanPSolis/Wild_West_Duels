using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

    //referencias
    public GameManager miManager;
    public Text Texto1Pl;
    public Text Texto2Pl;
	public Image Pl1;
	public Image Pl2;
    public MusicManager miMusic;
	public FxManager miFx;

    //en el start instanciamos la referencia al gameManager
    void Start()
    {
        miManager = GameManager.Instancia;
        CambiarTexto();
        miMusic = MusicManager.instance;
		miFx = FxManager.Instancia;

		//se coloca la musica del menu en el audiosource
        miMusic._audioSource.clip = miMusic.MusicaMenu;

		//se revisa si esta activa o no
		if (GameManager.SonidoActivo == true) 
		{
			miMusic.PlayMusic ();
		} 
		else if (GameManager.SonidoActivo == false)
		{
			miMusic.PlayMusic (false);
		}

		//comprobamos si los fx estan activos o no
		if (GameManager.SonidoFXActivo == false) 
		{
			miFx.FxAudio.mute = true;
		}
    }

    //esta funcion cambiara el texto del lado del jugador
    public void CambiarTexto()
    {
        if (miManager.player1Training == true)
        {
            Pl1.color = Color.black;
            Texto1Pl.text = "your score is " + miManager.PuntuacionObtenida.ToString();
            Pl2.color = Color.black;
            Texto2Pl.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            Texto2Pl.text = "max score " + GameManager.MaxPuntuacion.ToString();
        }
        else if (miManager.player2Duel == true)
        {
            if (miManager.Loser == "Player1")
            {
				Pl1.sprite = miManager.Controles [0].Player.Lose;
				Pl2.sprite = miManager.Controles [1].Player.Win;
            }
            if (miManager.Loser == "Player2")
            {
				Pl2.sprite = miManager.Controles [1].Player.Lose;
				Pl1.sprite = miManager.Controles [0].Player.Win;
            }
        }
    }

    //esta funcion reiniciara el juego
    public void ReiniciarPartida()
    {        
        if (miManager.player1Training == true)
        {
			FalseBooles();
			miFx.FxAudio.PlayOneShot (miFx.SonidosFx [5]);
			miManager.EmpezarJegoTrn();
        }
        if (miManager.player2Duel == true)
        {
			FalseBooles();
			miFx.FxAudio.PlayOneShot (miFx.SonidosFx [5]);
			miManager.EmpezarJegoDuel();
        }
    }

    //esta funcion quitara la aplicacion
    public void GameOverExit()
    {
        miManager.Exit();
    }

    //funcion que devuelve al menu principal

    public void ReiniciarMenuInicio()
    {
		miManager.player1Training = false;
		miManager.player2Duel = false;
		FalseBooles();
		miFx.FxAudio.PlayOneShot (miFx.SonidosFx [6]);
		miManager.RestartMenu();
    }

	//reiniciamos los bools necesarios
	void FalseBooles()
	{        
		miManager.BotonPresionado = false;
		miManager.player1Seleccionado=false;
		miManager.player2Seleccionado=false;
		miManager.SeleccionEmpezada = false;
		miManager.SeleccionTerminada=false;
		miManager.PartidaPreparada = false;
		miManager.PartidaEmpezada=false;
		miManager.JuegoPausado=false;
		miManager.PartidaTerminada=false;
		miManager.Controles[0].Player = null;
		miManager.Controles[1].Player=null;
	}
}
