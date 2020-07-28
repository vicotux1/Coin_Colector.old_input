using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class player : MonoBehaviour {
	[Header ("Control personaje")]
	[SerializeField]
	string _Horizontal="Horizontal";
	[SerializeField]
	string _Vertical="Vertical";
	[Range (5.0f, 20.0f)]
	[SerializeField]
	float _Speed=10.0f;
	Rigidbody _Cuerpo;
	[Header ("Camara Follow")]
	[SerializeField]
	Camera Main;
	[SerializeField]
	Vector3 _Distancia_a_seguir;

	int	_contador=0;
	[Header ("Elementos UI")]
	public Text Puntos;
	public Text Ganaste;
	[SerializeField]
	int Total_Monedas=11;


	void Start () {
		_Cuerpo=GetComponent<Rigidbody>();
		Main.transform.position = transform.position + _Distancia_a_seguir;
		_contador= 0;
		Puntacion ();
		Ganaste.enabled = false;
	}
	void FixedUpdate () 
	{
		Mover ();
	}
	void LateUpdate()
	{
		Camera_follow();

	}

	void Mover()
	{
		float EjeHorizontal = Input.GetAxis (_Horizontal);
		float EjeVertical = Input.GetAxis (_Vertical);
		Vector3 movimiento = new Vector3 (EjeHorizontal, 0, EjeVertical)*_Speed;
		_Cuerpo.AddForce (movimiento);
	}
	void Camera_follow()
	{
		Main.transform.position = transform.position +_Distancia_a_seguir;

	}

	void OnTriggerEnter(Collider other)
	{


		Destroy (other.gameObject);
		_contador = _contador + 1;
		Puntacion();
	}
	void Puntacion()
	{
		Puntos.text = "Puntos: "+ _contador;
		if( _contador==Total_Monedas)
		{
			Ganaste.enabled = true;
		}
	}



}
