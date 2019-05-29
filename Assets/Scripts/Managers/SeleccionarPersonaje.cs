using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionarPersonaje : MonoBehaviour {

    //instancia para referencias
	public static SeleccionarPersonaje Instancia=null;

    //referencias
    public Cowboys[] misCowboys;
    public Controller[] Players; 
    public GameManager miManager;
	public Button[] Botones;
	public FxManager miFx;

    //en el start rellenamos las instancias que faltan
    void Start()
    {
		if (Instancia == null)
		{
			Instancia = this;
		}
		else
		{
			DestroyObject(gameObject);
		}
		miManager = GameManager.Instancia;
		miFx = FxManager.Instancia;
        Players[0] = GameManager.Instancia.Controles[0];
        Players[1] = GameManager.Instancia.Controles[1];

		//controlamos los fx
		if (GameManager.SonidoFXActivo == false) 
		{
			miFx.FxAudio.mute = true;
		}

        miManager.SeleccionEmpezada = true;
    }


    //seleccion de jugador
	public void SeleccionCowboy(int num)
	{
        //si es un solo jugador
        if (miManager.player1Training == true)
        {
            miManager.Controles[1].gameObject.SetActive(false);

            if (Players[0].Player==null) 
            {
                Players[0].Player=misCowboys[num];
                Players[0].IsPlayer1 = true;
				miFx.FxAudio.PlayOneShot(miFx.SonidosFx[num]);
                miManager.player1Seleccionado = true;
                miManager.SeleccionTerminada = true;
            }
			miManager.Start1PGame ();
	   }
        //si son dos jugadores
        if (miManager.player2Duel == true)
        {
            miManager.Controles[1].gameObject.SetActive(true);

            if (Players[0].Player==null) 
            {                
                Players[0].Player = misCowboys[num];
                Players[0].IsPlayer1 = true;
				miFx.FxAudio.PlayOneShot(miFx.SonidosFx[num]);
                miManager.player1Seleccionado = true;
				Vuelta ();
            } 				
            else if (Players[1].Player==null && Players[0].Player!=null) 
            {                
                Players[1].Player = misCowboys[num];
                Players[1].IsPlayer1 = false;
				miFx.FxAudio.PlayOneShot(miFx.SonidosFx[num]);
                miManager.player2Seleccionado = true;
                Players[0].Otro = Players[1].Player;
                Players[1].Otro = Players[0].Player;
                miManager.SeleccionTerminada = true;
                miManager.Start2PGame();
            }

        }
	}

	//con esta funcion se voltean los botones para que el jugador dos los vea rectos
	void Vuelta()
	{		
		for (int i = 0; i < Botones.Length; i++) 
		{
			Botones [i].transform.eulerAngles = new Vector3 (0f, 0f, 180f);
		}
	}
}