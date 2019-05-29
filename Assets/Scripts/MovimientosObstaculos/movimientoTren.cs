using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoTren : MonoBehaviour {

    public GameObject Trigger4;
    public GameObject Trigger4I;
    public GameObject Trigger3;
    public GameObject Trigger3I;
    public float velocidadMovimiento = 1f;
	public AudioClip Disparo;
	public AudioSource miAudio;



    void Start () 
    {
        this.transform.position = Trigger3I.transform.position; 

		if (GameManager.SonidoFXActivo == false) {
			miAudio.mute = true;
		} 
		else {
			miAudio.mute = false;
		}
	}
		
	void Update () 
    {      
        transform.position += Vector3.right.normalized * Time.deltaTime * velocidadMovimiento;
	}

    void OnTriggerEnter2D(Collider2D col)
    {        
        if (col.name == "Trigger3")
        {
            transform.position = Trigger4.transform.position;
            transform.Rotate(new Vector2(0f, 180f));
            velocidadMovimiento = -velocidadMovimiento;
        }
        else if (col.name == "Trigger4I")
        {
            transform.position = Trigger3I.transform.position;
            transform.Rotate(new Vector2(0f, 180f));
            velocidadMovimiento = -velocidadMovimiento;
        }
        
		if (col.transform.tag == "bala") 
		{
			miAudio.PlayOneShot (Disparo);
		}			
    }		
}
