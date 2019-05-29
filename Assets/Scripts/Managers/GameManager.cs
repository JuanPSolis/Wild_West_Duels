using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	
    //intancia para las referencias
	public static GameManager Instancia=null;

	// preparamos los bools
	public bool BotonPresionado=false;
	public bool player1Seleccionado=false;
	public bool player2Seleccionado=false;
	public bool player1Training=false;
	public bool player2Duel = false;
    public bool SeleccionEmpezada=false;
    public bool SeleccionTerminada=false;
	public bool PartidaPreparada = false;
    public bool PartidaEmpezada=false;
    public bool JuegoPausado=false;
    public bool PartidaTerminada=false;

	//referencias
	public MenuManager miMenu;
    public TrnManager miTrn;
    public LevelManager miLevel;
    public Controller[] Controles;
    public InputManager miInput;

    //variables
    //variable para saber cual es el perdedor en el modo duelo
    public string Loser;
    //Vida de la bala
    public int TiempoDeVidaBala;
    //variable para acumular la puntuacion
    public int PuntuacionObtenida;

    //esta funcion guarda la puntuacion actual si es la puntuacion maxima 
    public static int MaxPuntuacion
    {
        get
        {
            return PlayerPrefs.GetInt("MaxPuntuacion",0);
        }
        set
        {
            
			if (value > PlayerPrefs.GetInt("MaxPuntuacion",0))
            {                
                PlayerPrefs.SetInt("MaxPuntuacion", value);
            }
        }
    }

    //intanciamos esta misma clase y nos aseguramos
    //que no se destruya
	void Awake () {  
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
		
	//comienzo accesible desde cualquier punto
	//se usara un invoke para dar tiempo a la animacion a terminar
    public void EmpezarJegoDuel()
    {
		if (BotonPresionado == false) 
		{
			player2Duel = true;
			Invoke ("PanSel", 1);
			BotonPresionado = true;
		}
    }
    public void EmpezarJegoTrn()
    {
		if (BotonPresionado == false) 
		{
			player1Training = true;
			Invoke ("PanSel", 1);
			BotonPresionado = true;
		}
    }
	void PanSel()
	{
		SceneManager.LoadScene("SeleccionPersonaje");
	}

    //comenzar a jugar
    public void Start1PGame()
    {
        SceneManager.LoadScene ("GamePlay1P");
    }
    public void Start2PGame()
    {
        SceneManager.LoadScene ("GamePlay2P");
    }

    //si acaba el juego salta la pantalla de game over
	public void JuegoAcabado()
	{        
        SceneManager.LoadScene("GameOver");
	}

    //para salir del juego
    public void Exit()
    {
        Application.Quit();
    }

    //volver al menu principal
    public void RestartMenu()
    {
        SceneManager.LoadScene("MenuInicio");
    }
		
    //bool para encender y apagar el sonido
    public static bool SonidoActivo
    {
        get
        {
            // La propiedad es de tipo bool, pero en el PlayerPref
            // hay almacenado un entero
            //     1=true
            //     0=false
            if(PlayerPrefs.GetInt("SonidoActivo",1)==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        set
        {
            // La propiedad es de tipo bool, pero para guardarla en
            // un PlayerPref necesito convertirla en un entero
            //     1=true
            //     0=false
            if(value==true)
            {
                PlayerPrefs.SetInt("SonidoActivo",1);
            }
            else
            {
                PlayerPrefs.SetInt("SonidoActivo",0);
            }
        }
    }
	//boll para saber si los fx estan encendidos o apagados	
	public static bool SonidoFXActivo
	{
		get
		{
			// La propiedad es de tipo bool, pero en el PlayerPref
			// hay almacenado un entero
			//     1=true
			//     0=false
			if(PlayerPrefs.GetInt("SonidoFxActivo",1)==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		set
		{
			// La propiedad es de tipo bool, pero para guardarla en
			// un PlayerPref necesito convertirla en un entero
			//     1=true
			//     0=false
			if(value==true)
			{
				PlayerPrefs.SetInt("SonidoFxActivo",1);
			}
			else
			{
				PlayerPrefs.SetInt("SonidoFxActivo",0);
			}
		}
	}
}
