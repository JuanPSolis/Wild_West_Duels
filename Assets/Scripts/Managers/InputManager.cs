using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
	
	//referencias
    public GameManager miManager;
    public Controller[] misControles;
    public GameObject[] players;
    private Touch Toque;
    public int numeroToques;
    private RaycastHit2D Golpe;
    private Ray Rayo;
    private Vector3 Aux;
    private int[] Finger;
    public bool[] Arrastrando;
	public bool[] Recargando;


	//iniciamos algunas arrays
    void Start()
    {
        Finger=new int[2] {-1,-1}; 
        Arrastrando=new bool[2];
		Recargando=new bool[2];
    }		

	//controlmuctitactil para dos jugadores
	//contrala el movimiento y el disparo
	public void Movimiento()
	{
		numeroToques = Input.touchCount;

		if (numeroToques > 0) 
		{
			for (int a = 0; a < numeroToques; a++) 
			{		
                for (int i = 0; i < Arrastrando.Length; i++)
                {
                    Toque = Input.GetTouch (a);
                    if (Toque.phase == TouchPhase.Began && Arrastrando[i]==false && Recargando[i]==false) 
                    {
                        Rayo = Camera.main.ScreenPointToRay (Toque.position);
                        Golpe = Physics2D.Raycast (Rayo.origin, Rayo.direction);

                        if (Golpe.collider!=null && Golpe.collider.name==players[i].name) 
                        {
                            Debug.Log (Golpe.collider.name);
                            Finger[i] = Toque.fingerId;
                            Arrastrando[i] = true;
                        }
                    }
					else if (Arrastrando[i] == true && Toque.phase == TouchPhase.Moved && Toque.fingerId==Finger[i])
                    {
                        Aux=Camera.main.ScreenToWorldPoint (Toque.position);
                        Aux.z = players[i].transform.position.z;
                        Aux.y = players[i].transform.position.y;
                        players[i].transform.position =Aux;
                    }
                    else if ((Toque.phase == TouchPhase.Ended || Toque.phase == TouchPhase.Canceled) && Toque.fingerId==Finger[i])
                    {
                        Arrastrando[i] = false;
                        Finger[i] = -1;	
                        misControles[i].Disparar();
                    }
                }				
			}
		}
	}
}
