using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class player : MonoBehaviour {

	// SerializeField
	[Header ("Control personaje")]
	[SerializeField]string _Horizontal="Horizontal";
	[SerializeField]string _Vertical="Vertical";
	[Range (5.0f, 20.0f)][SerializeField]float _Speed=10.0f;
	
	[Header ("Elementos UI")]
	[SerializeField] string Texto_A_Mostrar;
	[SerializeField] Text Puntos, Ganaste;
	[Header ("Points")]
	[SerializeField][Range (1, 100)]int Total_Monedas=11;
	
	[Header ("Camera Follow")]
	[SerializeField] Vector3 _Distancia_a_seguir;
	[SerializeField][Range (0.01f, 1.0f)]float smoothSpeed=0.1f;
	// Private 
	int	_contador=0;
	Rigidbody _Cuerpo;
	Camera Main;


	void Start () {
		_Cuerpo=GetComponent<Rigidbody>();
		Main=Camera.main;
		Main.transform.position = transform.position + _Distancia_a_seguir;
		_contador= 0;
		Puntacion ();
		Ganaste.enabled = false;
		//_Distancia_a_seguir= Vector3.zero;
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
		Vector3 Seguir=transform.position +_Distancia_a_seguir;
		Vector3 Smooth=Vector3.Lerp(Main.transform.position,Seguir,smoothSpeed);
		Main.transform.position = Smooth;

	}

	void OnTriggerEnter(Collider other)
	{


		Destroy (other.gameObject);
		_contador = _contador + 1;
		Puntacion();
	}
	void Puntacion()
	{
		Puntos.text = Texto_A_Mostrar + _contador;
		if( _contador==Total_Monedas)
		{
			Ganaste.enabled = true;
		}
	}



}
