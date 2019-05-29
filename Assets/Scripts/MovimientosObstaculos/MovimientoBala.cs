using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBala : MonoBehaviour {    

	//variable de velocidad
    public float Velocidad;


	//en el update avanza la bala y ajusta la velocidad
	void Update()
	{
		transform.Translate(new Vector3(0f,Velocidad*Time.deltaTime,0f));
	}

	//esta funcion sera invocada para desactivar la bala
	public void DestruirBalasPooled()
	{
		gameObject.SetActive(false);
		transform.position = new Vector3 (-10f, 0f, 0f);
	}

    //destruimos las balas cuando colisionan
	void OnCollisionEnter2D(Collision2D col)
	{
        if (col.gameObject.tag != "bala")
        {
            DestruirBalasPooled ();
        }
	}

	//desapareceran tambien con los trigger de fondo
	void OnTriggerEnter2D(Collider2D col)
	{
		DestruirBalasPooled ();
	}
}
