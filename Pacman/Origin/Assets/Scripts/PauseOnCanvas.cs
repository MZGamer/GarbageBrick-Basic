using UnityEngine; 
using System.Collections; 
using UnityEngine.SceneManagement;

public class PauseOnCanvas : MonoBehaviour
 {     private bool Click = false;
    public string main,title;
    
    public void Restart() 
    {

            SceneManager.LoadScene(main);// Application.loadedLevel表當前關卡
            attack.fireball_amount = 2;
            ScoreMan.score = 0;
            ScoreMan.usetime = 0;             Time.timeScale = 1f;
            ScoreMan.pac = 332;             fireball.kill = 0; 
    }
    public void Menu()
    {
        SceneManager.LoadScene(title);
        Time.timeScale = 1f;
    }
}
