using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Moneda : MonoBehaviour {
	[SerializeField]Vector3 _Rotacion;
	void Update () 
	{
		transform.Rotate (_Rotacion*Time.deltaTime);
	}
}
