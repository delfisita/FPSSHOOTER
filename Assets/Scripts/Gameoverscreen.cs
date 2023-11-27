using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas; // Asigna el Canvas de Game Over en el Inspector de Unity.
    public Text gameOverText; // El texto que muestra el mensaje de Game Over.

    private bool isGameOver = false;

    private void Start()
    {
      
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo") && !isGameOver)
        {
            // Si el jugador colisiona con un enemigo y el juego aún no ha terminado, muestra la pantalla de Game Over.
            ShowGameOver();
        }
    }

    public void ShowGameOver()
    {
        if (gameOverCanvas != null)
        {
            isGameOver = true;

            // Muestra la pantalla de Game Over y pausa el juego si es necesario.
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0; // Esto pausará el juego. Ajusta según tus necesidades.

            // Personaliza el mensaje de Game Over, por ejemplo:
            gameOverText.text = "¡Game Over!";
        }
    }

    public void RestartGame()
    {
        // Puedes usar esta función para reiniciar el juego desde la pantalla de Game Over.
        Time.timeScale = 1; // Reanuda el juego.
        // Agrega aquí la lógica para reiniciar tu juego, como cargar una escena inicial o restablecer valores.
    }

    // Puedes agregar más funciones y lógica según tus necesidades, como un botón para volver al menú principal o guardar puntajes.
}
