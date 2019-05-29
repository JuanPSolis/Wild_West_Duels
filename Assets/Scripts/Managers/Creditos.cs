using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour {

	public GameManager miManager;

	void Start () {
		miManager = GameManager.Instancia;
	}

	public void Back()
	{
		miManager.RestartMenu ();
	}

}
