using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager estancia;
    public int _contador=0;
    public int Life, total_levels;
    public string next_level;
    public string main_Menu;
    [Header ("Elementos UI")]
	[SerializeField] string Texto_GameOver,Texto_Next_level ;
	public Text Puntos_text, nivel_text,live_text;
	[Header ("Points")]
	[SerializeField][Range (10, 500)]int MaxScore=10;
    [Header ("Coin Music")]
	public AudioClip Coin_Sound;
	public AudioClip Winer_Sound;
    public AudioClip Loose_Sound;
    public AudioClip Next_level_sound;
    //Variables Private
    AudioSource Audio;
    private void Update() {
        live_text.text=" "+Life;
    }

    private void Awake() {
    live_text.text=" "+Life;
    _contador=0;    
    Audio=GetComponent<AudioSource>();
    nivel_text.text="";

	Cursor.visible = false;
    if (estancia!=null){
    Destroy(this.gameObject);      
    }else{
        estancia=this;
        DontDestroyOnLoad(this.gameObject);}
    }
    	public void Puntacion(int Value){
        _contador = _contador + Value;
        Audio.clip = Coin_Sound;
		Audio.Play();
		Puntos_text.text = "" +_contador;
		if( _contador==MaxScore){
            StartCoroutine(Next_level());
		}
	}
    public void Lives(){
        Debug.Log("perdiste una vida");
        Life = Life -1;
        StartCoroutine(Coins());
		if( Life==0)
		{	Audio.clip = Winer_Sound;
            Audio.Play();
            StartCoroutine(GamOver());
            }
        }    
        IEnumerator GamOver(){
        nivel_text.text=Texto_GameOver;
        _contador=0;
        Life=5;
        yield return new WaitForSeconds(5);
        Puntos_text.text = "" +_contador;
        SceneManager.LoadScene (main_Menu);
    }
    IEnumerator Next_level(){
        nivel_text.text=Texto_Next_level;
        Audio.clip = Next_level_sound;
		Audio.Play();
        yield return new WaitForSeconds(5);
        if(SceneManager.GetActiveScene ().buildIndex + 1<total_levels){
        int _Level=SceneManager.GetActiveScene ().buildIndex+ 1;    
        next_level=_Level.ToString();
        }
        else if (SceneManager.GetActiveScene ().buildIndex + 1>=total_levels){
        next_level=main_Menu;
        Life=5;
        }
        SceneManager.LoadScene (next_level);
        _contador=0;
        yield return new WaitForSeconds(1);
        nivel_text.text="";
        
    }
    IEnumerator Coins(){
        nivel_text.text="perdiste 1 vida, quedan "+ Life;
        Audio.clip = Loose_Sound;
		Audio.Play();
        yield return new WaitForSeconds(2);
         live_text.text=" "+Life;
         nivel_text.text="";
         }
}
