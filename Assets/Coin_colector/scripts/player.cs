#region Asignaciones previas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]
public class player : MonoBehaviour {
#endregion
public static int	_contador=0;
public Vector3 Posicion_inicial;
#region Variables Public
	[Header ("Control personaje")]
	[SerializeField]string _Horizontal="Horizontal";
	[SerializeField]string _Vertical="Vertical";
	[Range (2.0f, 20.0f)][SerializeField]float _Speed=10.0f;
#endregion

#region Variables Private
	Rigidbody _Cuerpo;
	Camera Main;
	float AngleX,AngleY;
	AudioSource Audio;
#endregion

#region Functions Unity 
	void Start () {
		_Cuerpo=GetComponent<Rigidbody>();
		Audio=GetComponent<AudioSource>();
		Cursor.visible = false;
		transform.position=Posicion_inicial;
		}

		void OnTriggerEnter(Collider other){
        if (other.tag == "Enemy"){
			Game_Manager.estancia.Lives();
			_Cuerpo.velocity=Vector3.zero;
			transform.position=Posicion_inicial;
			}
		}	
	void FixedUpdate () {
		Mover ();
		}
#endregion

	#region Functions Movement
	void Mover(){
		float EjeHorizontal = Input.GetAxis (_Horizontal);
		float EjeVertical = Input.GetAxis (_Vertical);
		Vector3 movimiento = new Vector3 (EjeHorizontal, 0, EjeVertical)*_Speed;
		_Cuerpo.AddForce (movimiento);
		}
	#endregion
}
