using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrnManager : MonoBehaviour {

    //intancia
    public static TrnManager Instancia;

    //referencias
    public GameManager miManager;
    public InputManager miInput;
    public Controller[] Controles;
    public Text miScore;
    public Text miMaxScore;
    public Text Recarga1;
	public Image Reloj;
    public Canvas miPausa;
    public int miPuntuacion = 0;
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
        Controles[0] = GameManager.Instancia.Controles[0];

		//se coloca la musica del gameplay en el audiosource
        miMusic._audioSource.clip = miMusic.MusicGML;

		//se comprueba si el sonido esta activo o no
		if (GameManager.SonidoActivo == true) {
			miMusic.PlayMusic ();
		} 
		else if (GameManager.SonidoActivo == false){
			miMusic.PlayMusic (false);
		}

		//comprobamos si los fx estan activos o no
		if (GameManager.SonidoFXActivo == false) {
			Controles [0].misAudios.mute = true;
			miFx.FxAudio.mute = true;
		} 
		else {
			Controles [0].misAudios.mute = false;
			miFx.FxAudio.mute = false;
		}

        miManager.PartidaPreparada = true;

        //se posicionan los jugadores en su posicion de inicio
        Controles[0].PosicionJugador ();

        //mostramos la puntuacion maxima
        miMaxScore.text = "Max Score " + GameManager.MaxPuntuacion.ToString();
    }

    //arranca el Input manager y renovamos la puntuacion que se vaya obteniendo
    void FixedUpdate () {        
        miInput.Movimiento();
        Texto1 ();
		miScore.text = "Score " + miPuntuacion.ToString();
		CuentaAtras ();
    }

	 
    //control del texto de recarga y de las recargas
    public void Texto1()
    {
        Recarga1.text = Controles[0].BalasRestantes.ToString();
    }

    //contralomas la recarga
    public void RecargaPl1()
    {
		if (miInput.Recargando[0] == false) {
			Controles[0].StartCoroutine("Recarga");
		}
    }

    //preparamops el game over
    public void GameOver()
    {
        miManager.PuntuacionObtenida = miPuntuacion;
        GameManager.MaxPuntuacion = miPuntuacion;
        miManager.JuegoAcabado();
    }

	//funcion que controla el reloj
	public void CuentaAtras()
	{
		Reloj.fillAmount -= 0.0003f;
		if (Reloj.fillAmount == 0f) 
		{
			GameOver ();
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
        miManager.player1Training = false;
        FalseBooles();
		miFx.FxAudio.PlayOneShot (miFx.SonidosFx [6]);
        miManager.RestartMenu();
    }
    public void Restart()
    {
        FalseBooles();
		miFx.FxAudio.PlayOneShot (miFx.SonidosFx [5]);
        miManager.EmpezarJegoTrn();
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
        miManager.SeleccionEmpezada=false;
        miManager.SeleccionTerminada=false;
        miManager.PartidaPreparada = false;
        miManager.PartidaEmpezada=false;
        miManager.JuegoPausado=false;
        Time.timeScale = 1;
        miManager.PartidaTerminada=false;
        miManager.Controles[0].Player = null;
    }
}
