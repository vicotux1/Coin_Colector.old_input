using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Points=10;

    void OnTriggerEnter(Collider other){
		Destroy (this.gameObject);
        Game_Manager.estancia.Puntacion(Points);
        }
}
