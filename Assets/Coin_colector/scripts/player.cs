#region Asignaciones previas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]
public class player : MonoBehaviour {
#endregion
public static int	_contador=0;
#region Variables Public
	
	public AudioClip Coin;
	public AudioClip Winer;

	[Header ("Control personaje")]
	[SerializeField]string _Horizontal="Horizontal";
	[SerializeField]string _Vertical="Vertical";
	[Range (2.0f, 20.0f)][SerializeField]float _Speed=10.0f;
	[Header ("Elementos UI")]
	[SerializeField] string Texto_A_Mostrar="Points:";
	public Text Puntos, Ganaste;
	[Header ("Points")]
	[SerializeField][Range (1, 100)]int Total_Monedas=11;
	[Header ("Camera Follow")]
	[SerializeField] Vector3 _Distancia_a_seguir=Vector3.zero;
	[SerializeField][Range (0.01f, 1.0f)]float smoothSpeed=0.1f;
	[SerializeField] [Range (0, 90.0f)]float RotX=45.0f, RotY=0;
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
		Main=Camera.main;
		Main.transform.position = transform.position + _Distancia_a_seguir;
		_contador= 0;
		Puntacion ();
		Ganaste.enabled = false;
		Cursor.visible = false;
		}
	void FixedUpdate () {Mover ();}
	void LateUpdate(){Camera_follow();}
#endregion

	#region Functions Movement
	void Mover(){
		float EjeHorizontal = Input.GetAxis (_Horizontal);
		float EjeVertical = Input.GetAxis (_Vertical);
		Vector3 movimiento = new Vector3 (EjeHorizontal, 0, EjeVertical)*_Speed;
		_Cuerpo.AddForce (movimiento);
		}
	void Camera_follow(){
		Vector3 Seguir=transform.position +_Distancia_a_seguir;
		Vector3 Smooth=Vector3.Lerp(Main.transform.position,Seguir,smoothSpeed);
		Main.transform.position = Smooth;
		Main.transform.eulerAngles = new Vector3(RotX,RotY,0);
		}
	#endregion	

#region Contador
	void OnTriggerEnter(Collider other){
		Destroy (other.gameObject);
		Audio.clip = Coin;
		Audio.Play();
		_contador = _contador + 1;
		Puntacion();}
	void Puntacion(){
		Puntos.text = Texto_A_Mostrar + _contador;
		if( _contador==Total_Monedas)
		{	Audio.clip = Winer;
			Audio.Play();
			Ganaste.enabled = true;}
	}
#endregion
}
