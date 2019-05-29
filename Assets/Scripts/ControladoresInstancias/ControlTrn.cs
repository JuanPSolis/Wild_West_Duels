using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTrn : MonoBehaviour {

    //este escript solo sirve para añadir la instancia a los controler
    //para que reconozcan el level manager y el pool
    public TrnManager miTrn;
    public GameManager miManager;
    public PoolDeBalas pol;
    void Start () {
        miManager = GameManager.Instancia;
        miManager.Controles[0].miTrn = miTrn;
        miManager.Controles[0].misBalas = pol;
        miManager.miTrn = miTrn;
    }
}
