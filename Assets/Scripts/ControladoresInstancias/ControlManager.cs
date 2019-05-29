using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour {

	//este escript solo sirve para añadir la instancia a los controler
	//para que reconozcan el level manager y el pool
	public LevelManager milev;
    public GameManager miManager;
    public PoolDeBalas pol;
	void Start () {
        miManager = GameManager.Instancia;
        miManager.miLevel = milev;
        miManager.Controles[0].miLevel = milev;
        miManager.Controles[1].miLevel = milev;
        miManager.Controles[0].misBalas = pol;
        miManager.Controles[1].misBalas = pol;
	}
}
