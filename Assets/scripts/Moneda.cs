using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Moneda : MonoBehaviour {
	public Vector3 _Rotacion;
	public GameObject Player;

	void Update () 
	{
		rotacion ();
	}
	void rotacion()
	{
		transform.Rotate (_Rotacion*Time.deltaTime);	
	}
}
