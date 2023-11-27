using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidadMovimiento = 3.0f;
    public float distanciaPersecucion = 10.0f;
    public GameObject proyectil;
    public Transform jugador;
    public float velocidadProyectil = 10.0f;

    private bool persiguiendo = false;

    private void Start()
    {
        jugador = GameObject.FindWithTag("Player").transform; 
    }

    private void Update()
    {
        if (jugador == null)
        {
            return;
        }

        float distanciaJugador = Vector3.Distance(transform.position, jugador.position);

        if (distanciaJugador < distanciaPersecucion)
        {
            persiguiendo = true;
          
            transform.LookAt(jugador);
            transform.Translate(Vector3.forward * velocidadMovimiento * Time.deltaTime);
        }
        else
        {
            persiguiendo = false;
        }

        if (persiguiendo && distanciaJugador < 1.0f)
        {
            
            Destroy(jugador.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            
            Destroy(gameObject);
           
        }
    }

    
}


