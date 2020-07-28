#region Asignaciones previas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]
#endregion
public class player : MonoBehaviour {
#region Variables Public
	[Header ("Control personaje")]
	[Range (1, 2)][SerializeField]int SerialID=1;
	[SerializeField]string _Horizontal="Horizontal";
	[SerializeField]string _Vertical="Vertical";
	[Range (2.0f, 20.0f)][SerializeField]float _Speed=10.0f;
	[Header ("Elementos UI")]
	[SerializeField] string Texto_A_Mostrar;
	[SerializeField] Text Puntos, Ganaste;
	[Header ("Points")]
	[SerializeField][Range (1, 100)]int Total_Monedas=11;
	[Header ("Camera Follow")]
	[SerializeField] Vector3 _Distancia_a_seguir;
	[SerializeField][Range (0.01f, 1.0f)]float smoothSpeed=0.1f;
	[SerializeField] [Range (-5.0f, 5.0f)]float CamH, CamV;
	[SerializeField]string AxisX, AxisY;
#endregion

#region Variables Private
	int	_contador=0;
	Rigidbody _Cuerpo;
	Camera Main;
	float AngleX,AngleY;
#endregion

#region Functions Unity 
	void Start () {
		_Cuerpo=GetComponent<Rigidbody>();
		Main=Camera.main;
		Main.transform.position = transform.position + _Distancia_a_seguir;
		_contador= 0;
		Puntacion ();
		Ganaste.enabled = false;
		Cursor.visible = false;
	}
	void FixedUpdate () {
		float RotateX=Input.GetAxis(AxisX);
		Mover (RotateX);}
	void LateUpdate(){
		float RotateX=Input.GetAxis(AxisX);
        float RotateY=Input.GetAxis(AxisY);
		AngleY+=CamH*RotateX;
    	AngleX+= CamV*RotateY;
		Camera_Rotate(AngleX, AngleY);
		Camera_follow();
	}
#endregion

#region Functions Movement
	void Mover(float RotateH){
		float EjeHorizontal = Input.GetAxis (_Horizontal);
		float EjeVertical = Input.GetAxis (_Vertical);
		if (SerialID==1){
		Vector3 movimiento = new Vector3 (EjeHorizontal, 0, EjeVertical)*_Speed;
		_Cuerpo.AddForce (movimiento);
		}
		if (SerialID==2){
			Vector3 movimiento = new Vector3 (EjeHorizontal, 0, EjeVertical)*_Speed;
		_Cuerpo.velocity =(movimiento);
		transform.Rotate(Vector3.up*RotateH);
		}
	}
	void Camera_follow(){
		Vector3 Seguir=transform.position +_Distancia_a_seguir;
		Vector3 Smooth=Vector3.Lerp(Main.transform.position,Seguir,smoothSpeed);
		Main.transform.position = Smooth;
		
		}
		void Camera_Rotate(float RotX, float RotY){
			Main.transform.eulerAngles = new Vector3(RotX, RotY, 0.0f);
		}
#endregion	

#region Contador
	void OnTriggerEnter(Collider other){
		Destroy (other.gameObject);
		_contador = _contador + 1;
		Puntacion();}
	void Puntacion(){
		Puntos.text = Texto_A_Mostrar + _contador;
		if( _contador==Total_Monedas)
		{Ganaste.enabled = true;}
	}
#endregion
}
