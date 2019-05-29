using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolDeBalas : MonoBehaviour {
	
	//referencias
	public static PoolDeBalas Instancia;
	public GameObject Bala;
	public List<GameObject> Balas;
	public GameObject tempBala;

	//valores publicos
	private int NumeroBalasStart=20;
	public bool isPoolGrow;
	private int MaxGrowBalas=30;


	void Awake()
	{
		Instancia = this; 
	}

	//aqui instanciamos las balas al principio del programa
	void Start () {
		Balas = new List<GameObject>();

		for (int i=0; i<NumeroBalasStart; i++)
		{
			tempBala = (GameObject)Instantiate(Bala);
			tempBala.SetActive(false);
			Balas.Add(tempBala);
		}
	}

	//aqui rellenamos las balas si se acaban 
	//tambien da la posibilidad de aumentar la list
	public GameObject GetPooledObject()
	{

		for (int i=0; i<Balas.Count; i++)
		{
			if (!Balas [i].activeInHierarchy)
				return Balas [i];
		}

		if (isPoolGrow && Balas.Count < MaxGrowBalas)
		{
			tempBala = (GameObject)Instantiate(Bala);
			Balas.Add(tempBala);
			return tempBala;
		}
		return null;
    }
}
