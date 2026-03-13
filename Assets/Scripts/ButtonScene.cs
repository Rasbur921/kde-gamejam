using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScene : MonoBehaviour
{
	public int SceneNumber;
	public void SceneChange(){
		SceneManager.LoadScene(SceneNumber);
	}
	public void Exit(){
		Application.Quit();
	}	
    public void Restart()
    {
        // Получаем имя текущей сцены
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        // Загружаем текущую сцену заново
        SceneManager.LoadScene(currentSceneName);
    }
}
