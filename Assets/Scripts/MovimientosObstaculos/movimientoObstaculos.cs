using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoObstaculos : MonoBehaviour {

	public GameObject Trigger1;
	public GameObject Trigger1I;
	public GameObject Trigger2;
	public GameObject Trigger2I;
	public GameObject Trigger5;
	public GameObject Trigger5I;
	public GameObject Trigger6;
	public GameObject Trigger6I;
	public SpriteRenderer miSr;
	public float Velocidad;	
    public Sprite[] misSprites;
	public AudioClip Disparo;
	public AudioSource miAudio;
    
	void Start () 
	{
		this.transform.position = Trigger1I.transform.position;
		miSr.sprite = misSprites[Random.Range(0, misSprites.Length)];	

		if (GameManager.SonidoFXActivo == false) {
			miAudio.mute = true;
		} 
		else {
			miAudio.mute = false;
		}
	}
		
	void Update () 
	{
		transform.position += Vector3.right.normalized * Time.deltaTime * Velocidad;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name == "Trigger1")			
		{
			transform.position = Trigger2.transform.position;

			transform.Rotate (new Vector3 (0f, 0f, 180f));

            Velocidad = Mathf.Sign(Velocidad) * Random.Range(-2.5f,-4.2f);

            miSr.sprite = misSprites[Random.Range(0, misSprites.Length)];
		}
		else if (col.name == "Trigger2I")
		{
			transform.position = Trigger5I.transform.position;

			transform.Rotate (new Vector3 (0f, 0f, 180f));

            Velocidad = Mathf.Sign(Velocidad) * Random.Range(-2.5f,-4.2f);

            miSr.sprite = misSprites[Random.Range(0, misSprites.Length)];
		}
		else if (col.name == "Trigger5")
		{
			transform.position = Trigger6.transform.position;

			transform.Rotate (new Vector3 (0f, 0f, 180f));

            Velocidad = Mathf.Sign(Velocidad) * Random.Range(-2.5f,-4.2f);

            miSr.sprite = misSprites[Random.Range(0, misSprites.Length)];
		}
		else if (col.name == "Trigger6I")
		{
			transform.position = Trigger1I.transform.position;

			transform.Rotate (new Vector3 (0f, 0f, 180f));

            Velocidad = Mathf.Sign(Velocidad) * Random.Range(-2.5f,-4.2f);

            miSr.sprite = misSprites[Random.Range(0, misSprites.Length)];
		}

		if (col.transform.tag == "bala") 
		{
			miAudio.PlayOneShot (Disparo);
		}
	}
}
