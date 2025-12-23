using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelVictoria : MonoBehaviour
{
    public GameObject panelVictoria;

    public void MostrarPanelVictoria()
    {
        // Time.timeScale significa que el tiempo del juego se detiene
        // SetActive significa que el panel de victoria se activa y se muestra en la pantalla
        panelVictoria.SetActive(true);
        Time.timeScale = 0f;
    }
    // public void significa que el metodo es accesible desde otros scripts
    // void significa que el metodo no devuelve ningun valor
    // LoadScene significa que se carga una escena
    // GetActiveScene significa que se obtiene la escena activa
    // sceneManager significa que se utiliza el gestor de escenas de Unity
    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MAIN MENU");
    }
}
