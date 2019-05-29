using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDiana2 : MonoBehaviour {

	public GameObject Trigger7;
	public GameObject Trigger7I;
	public GameObject Trigger8;
	public GameObject Trigger8I;
	public SpriteRenderer miSr;
	public TrnManager miTrnManager;
	public int PuntosObt;

	public float Velocidad;
	public Sprite[] misSprites;

	void Start () 
	{
		miTrnManager = TrnManager.Instancia;
		this.transform.position = Trigger8.transform.position;
		miSr.sprite = misSprites[Random.Range(0, misSprites.Length)];
	}
		
	void Update () 
	{
		transform.position += Vector3.right.normalized * Time.deltaTime * Velocidad;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name == "Trigger8I") 
		{
			

			transform.Rotate (new Vector3 (0f, 0f, 180f));

			Velocidad = Mathf.Sign (Velocidad) * Random.Range (-2.5f, -3.2f);

			miSr.sprite = misSprites [Random.Range (0, misSprites.Length)];

		} 
		else if (col.name == "Trigger8") 
		{
			

			transform.Rotate (new Vector3 (0f, 0f, 180f));

			Velocidad = Mathf.Sign (Velocidad) * Random.Range (-2.5f, -3.2f);

			miSr.sprite = misSprites [Random.Range (0, misSprites.Length)];

		}
	}
	//collision enter para subir la puntuacion
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "bala")
		{
			miTrnManager.miPuntuacion += PuntosObt;
			this.transform.position = Trigger8.transform.position;
			Velocidad = Mathf.Sign (Velocidad) * Random.Range (-2.5f, -3.2f);
		}
	}
}
