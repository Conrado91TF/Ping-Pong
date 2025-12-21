using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public GameObject mainMenuUI;

   public void PlayGame()
   {
       SceneManager.LoadScene("Ping Pong");
   }
}
