using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instrucciones : MonoBehaviour {

	public Text Texto;
	public SpriteRenderer[] miSpr;
	public Animator miAnim;
	public GameManager miManager;


	void Start () {
		miManager = GameManager.Instancia;
		miSpr[0].gameObject.SetActive (false);
		miSpr[1].gameObject.SetActive (false);
		miSpr[2].gameObject.SetActive (false);
		StartCoroutine ("Instructions");
	}

	//preparamos la corrutina para mostrar las instrucciones animadas
	IEnumerator Instructions()
	{
		Texto.text = "";
		yield return new WaitForSeconds(1);
		Texto.text = "Touches the character and drags the finger to move it laterally";
		yield return new WaitForSeconds(1);
		miSpr[0].gameObject.SetActive (true);
		miAnim.SetTrigger ("MovLat");
		yield return new WaitForSeconds(3);
		miSpr[0].gameObject.SetActive (false);
		Texto.text = "And lift your finger to shoot";
		yield return new WaitForSeconds(1);
		miSpr[0].gameObject.SetActive (true);
		miAnim.SetTrigger ("MovShoot");
		yield return new WaitForSeconds(3);
		miSpr[0].gameObject.SetActive (false);
		Texto.text = "Touch the image of the charger to recharge your weapon";
		yield return new WaitForSeconds(1);
		miSpr[0].gameObject.SetActive (true);
		miSpr[1].gameObject.SetActive (true);
		miAnim.SetTrigger ("MovRec");
		yield return new WaitForSeconds(4);
		Texto.text = "Remember: while reloading you will not be able to move the character";
		yield return new WaitForSeconds(2);
		miSpr[0].gameObject.SetActive (false);
		miSpr[1].gameObject.SetActive (false);
		Texto.text = "In training mode hits the targets to get points";
		yield return new WaitForSeconds(1);
		miSpr[2].gameObject.SetActive (true);
		yield return new WaitForSeconds(3);
		Texto.text = "Hurry up. Time runs against you";
		yield return new WaitForSeconds(2);
		miSpr[2].gameObject.SetActive (false);
		Texto.text = "In duel mode you will have to hit the other character to lower his life bar";
		yield return new WaitForSeconds(4);
		Texto.text = "Will win the player who before ends with the opponent's life bar";
		yield return new WaitForSeconds(4);
		Texto.text = "Each character has its own damage, reload time, number of bullets ...";
		yield return new WaitForSeconds(4);
		Texto.text = "try with everyone to know which you like more";
		yield return new WaitForSeconds(5);
		miManager.RestartMenu ();
	}

	//usamos un boton para poder volver al menu cuando el jugador quiera
	public void Skip ()
	{
		miManager.RestartMenu ();
	}
	

}
