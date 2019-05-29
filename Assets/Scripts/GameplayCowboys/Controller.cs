using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    //aqui guardamos los sprites y perfiles de los jugadores
    public Cowboys Player;
    public SpriteRenderer Spr;

    //referencias
    public GameManager miManager;
    public InputManager miInput;
    public LevelManager miLevel;
    public TrnManager miTrn;
    public Cowboys Otro;     
    public GameObject Bala;
    public PoolDeBalas misBalas;
    public AudioSource misAudios; 
    public ParticleSystem miPart;
    public Animator miAnim;

    //vida del personaje y balas restantes
    public float Vida;
    public float VidaInicial=10;
    public float BalasRestantes;
    public float DañoRecibicido;

    //bool para saber si es player 1 o 2
    public bool IsPlayer1 = true;

    //iniciamos los valores y ponemos el transform en su sitio    
    public void PosicionJugador()
    {        
        if (IsPlayer1 == true)
        {
			gameObject.transform.position = new Vector3(0f, -2.8f, 0f);
			gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else
        {
			gameObject.transform.position = new Vector3(0f, 4.8f, 0f);            
        } 
		Spr.sprite = Player.Player;
		BalasRestantes = Player.Balas;
		miAnim.runtimeAnimatorController = Player.Mov.runtimeAnimatorController;

        if (miManager.player2Duel == true)
        {
            DañoRecibicido = Otro.Daño;
        }
        if (miManager.player1Training==true)
        {
            DañoRecibicido = 0;
        }
		miManager.PartidaEmpezada = true;
    }		

    //al disparar recogemos la bala del pool y la activamos
    //la igualamos al transform e invocamos la funcion para desactivarla
    public void Disparar()
    {        
        if (BalasRestantes > 0)
        {
            BalasRestantes--;
            Bala = misBalas.GetPooledObject();
            Bala.SetActive(true);
            if (IsPlayer1 == true)
            {
                Bala.transform.position = new Vector3(transform.position.x, transform.position.y +0.6f, 0f);
				Bala.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            else
            {
                Bala.transform.position = new Vector3 (transform.position.x,transform.position.y -0.6f,0f); 
				Bala.transform.eulerAngles = new Vector3(0f, 0f, -180f);           
            }  
            misAudios.PlayOneShot(Player.Audios[Random.Range(0, Player.Audios.Length)]);
            miAnim.SetTrigger("Disparando");
            miPart.Play();
        }
    }		

    //cuando el jugador es dañado
    void OnCollisionEnter2D(Collision2D col)
    {
        if (miManager.player2Duel == true)
        {
            if (Vida > 0) 
            {
                misAudios.PlayOneShot(Player.Dolor[Random.Range(0, Player.Dolor.Length)]);
                Vida -= DañoRecibicido;
                miLevel.Daños (gameObject.name);
                if (Vida<=0)
                {
                    misAudios.PlayOneShot(Player.Muerte);
                    MuertePersonaje ();
                } 
            }
        }
    }

    //mientras recarga el jugador no podra moverse
	IEnumerator Recarga()
    {
		if (IsPlayer1 == true) {
			miInput.Recargando [0] = true;
		} 
		else {
			miInput.Recargando [1] = true;
		}	

		for (float i = BalasRestantes; i < Player.Balas; i++) 
		{
			yield return new WaitForSeconds ((Player.TiempoDeRecarga/(Player.Balas-BalasRestantes))/2f);
			BalasRestantes += 1;
			misAudios.PlayOneShot (Player.Recarga);
		}

		if (IsPlayer1 == true) {
			miInput.Recargando [0] = false;
		} 
		else {
			miInput.Recargando [1] = false;
		}
    }

	//player muerto
	public void MuertePersonaje()
	{
		miLevel.GameOver (gameObject.name);
	}

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Disparar();
        }
    }*/
}
