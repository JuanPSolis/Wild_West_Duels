using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboys : MonoBehaviour {

    //perfil jugador
    public Sprite Player;
	public Sprite Win;
	public Sprite Lose;
    public float Daño;
    public int Balas;
    public float VelocidadBala;
    public float TiempoDeRecarga;
    public AudioClip[] Audios;
    public AudioClip[] Dolor;
	public AudioClip Recarga;
    public AudioClip Muerte;
    public Animator Mov;
}
