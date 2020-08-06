#region Previas
using UnityEngine; 
using System.Collections; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#endregion
#if UNITY_EDITOR
using UnityEditor;
#endif
public class pause_manager : MonoBehaviour {
    public Canvas canvasPausa;
	void Start(){
	canvasPausa.enabled = false;
	Time.timeScale = 1;
	}
	void Update(){
		if (Input.GetButtonDown ("Cancel")){
			Pause();}
			}
    public void Pause(){
        canvasPausa.enabled = !canvasPausa.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1: 0;
		}
	public void SetQuality (int Level){
		QualitySettings.SetQualityLevel(Level);
	}
	public void Quit(){
        #if UNITY_EDITOR 
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
		#endif
		}
	public void scene(string name){ 
		SceneManager.LoadScene (name);
		}
	public void Vsync(int Vsync){
		QualitySettings.vSyncCount = Vsync;}
}