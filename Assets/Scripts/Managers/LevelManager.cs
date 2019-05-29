using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    //instancia para referencias
	public static LevelManager Instancia;

	//referencias
	public GameManager miManager;
	public InputManager miInput;
    public Controller[] Controles;
    public Image Vida1;
    public Image Vida2;
    public Text Recarga1;
    public Text Recarga2;
    public Canvas miPausa; 
    public MusicManager miMusic;
	public FxManager miFx;

    //en el start se instancian las referencias que faltan
    //tambien se posicionan los jugadores en la escena
    void Start ()
    {
		if (Instancia == null)
		{
			Instancia = this;
		}
		else
		{
			DestroyObject(gameObject);
		}

        //se toman referencias y se desactiva el canvas del menu de pausa
        miPausa.gameObject.SetActive(false);
        miMusic = MusicManager.instance;
		miManager = GameManager.Instancia;	
		miFx = FxManager.Instancia;
        miInput = GameManager.Instancia.miInput;
        Controles[1] = GameManager.Instancia.Controles[1];
        Controles[0] = GameManager.Instancia.Controles[0];

		//se incorpora la musica del gameplay
        miMusic._audioSource.clip = miMusic.MusicGML;

		//se revisa si esta activa o no
		if (GameManager.SonidoActivo == true) {
			miMusic.PlayMusic ();
		} 
		else if (GameManager.SonidoActivo == false){
			miMusic.PlayMusic (false);
		}

		//comprobamos si los fx estan activos o no
		if (GameManager.SonidoFXActivo == false) {
			Controles [0].misAudios.mute = true;
			Controles [1].misAudios.mute = true;
			miFx.FxAudio.mute = true;
		} 
		else {
			Controles [0].misAudios.mute = false;
			Controles [1].misAudios.mute = false;
			miFx.FxAudio.mute = false;
		}
        miManager.PartidaPreparada = true;

        //se posicionan los jugadores en su posicion de inicio
        if (miManager.player1Training == true)
        {
            Controles[0].Vida=Controles[0].VidaInicial;
            Controles[0].PosicionJugador ();
        }
        if (miManager.player2Duel == true)
        {
            Controles[0].Vida=Controles[0].VidaInicial;
            Controles[1].Vida=Controles[1].VidaInicial;
            Controles[0].PosicionJugador ();
            Controles[1].PosicionJugador ();
        }
    }
        
	//arranca el Input manager
	void Update () {        
		miInput.Movimiento();
		Texto1 ();
		Texto2 ();
	}

	//control de la barra de vida y el game over
	public void ControlVidaPl1()
	{
        Vida1.fillAmount -= Controles[0].DañoRecibicido/10f;
	}
	public void ControlVidaPl2()
	{
        Vida2.fillAmount -= Controles[1].DañoRecibicido/10f;
	}
	public void Daños(string name)
	{
		if (name == "Player1") 
		{
			ControlVidaPl1 ();
		}
		if (name == "Player2") 
		{
			ControlVidaPl2 ();
		}
	}
	public void GameOver(string name)
	{
        miManager.Loser = name;
        miManager.JuegoAcabado();

	}

	//control del texto de recarga y de las recargas
	public void Texto1()
	{
		Recarga1.text = Controles[0].BalasRestantes.ToString();
	}
	public void Texto2()
	{
		Recarga2.text = Controles[1].BalasRestantes.ToString();
	}
	public void RecargaPl1()
	{
		if (miInput.Recargando[0] == false) {
			Controles[0].StartCoroutine("Recarga");
		}
	}
	public void RecargaPl2()
	{
		if (miInput.Recargando[1] == false) {
			Controles[1].StartCoroutine("Recarga");
		}
	}

    //pausa y el menu de los buttons de pausa
    public void Pausa()
    {
        if (miManager.JuegoPausado==false)
        {
            miManager.JuegoPausado = true;
            Time.timeScale = 0;
            miPausa.gameObject.SetActive(true);
        }
        else if (miManager.JuegoPausado==true)
        {
            miManager.JuegoPausado = false;
            Time.timeScale = 1;
            miPausa.gameObject.SetActive(false);
        }
    }

    //opciones para el menu de pausa 
    public void MainMenu()
    {     
        miManager.player2Duel = false;
        FalseBooles();
		miFx.FxAudio.PlayOneShot (miFx.SonidosFx [6]);
        miManager.RestartMenu();
    }
    public void Restart()
    {        
        FalseBooles();
		miFx.FxAudio.PlayOneShot (miFx.SonidosFx [5]);
        miManager.EmpezarJegoDuel();
    }
    public void Exit()
    {
        miManager.Exit();
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
        Time.timeScale = 1;
        miManager.PartidaTerminada=false;
        miManager.Controles[0].Player = null;
        miManager.Controles[1].Player=null;
    }
}
