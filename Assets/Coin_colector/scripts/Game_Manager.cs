using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager estancia;
    public int _contador=0;
    public int Life= 3;
    [Header ("Elementos UI")]
	[SerializeField] string Texto_A_Mostrar="Points:";
	public Text Puntos_text, nivel_text;
	[Header ("Points")]
	[SerializeField][Range (10, 500)]int MaxScore=10;
    [Header ("Coin Music")]
	public AudioClip Coin;
	public AudioClip Winer;
    //Variables Private
    AudioSource Audio;

    private void Awake() {
    _contador=0;    
    Audio=GetComponent<AudioSource>();
    nivel_text.enabled = false;
	Cursor.visible = false;    
    Life= 10;
    if (estancia!=null){
    Destroy(this.gameObject);      
    }else{
        estancia=this;}
    }
    	public void Puntacion(int Value){
        _contador = _contador + Value;
        Audio.clip = Coin;
		Audio.Play();
		Puntos_text.text = Texto_A_Mostrar + _contador;
		if( _contador==MaxScore)
		{	Audio.clip = Winer;
			Audio.Play();
			nivel_text.enabled = true;}
	}
}
