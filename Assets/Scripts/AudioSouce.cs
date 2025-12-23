using UnityEngine;
using UnityEngine.Audio;

public class AudioSouce : MonoBehaviour
{
    public AudioSource quienEmite;
    public AudioClip clipASonar;
    public float volumen;
    public AudioClip PlayerSoucer;
    public AudioSource PlayerAudioSource;
    public AudioClip WallSouce;
    public AudioSource WallAudioSource;

    [SerializeField]
    public GameObject effectsGoal;


    // Lo que intento hacer en esté código es que al momento de que la pelota entre en el trigger y haga el gol,
    // se reproduzca un sonido y se instancie un efecto visual en la posición del trigger.
    // Null: significa (nula)
    // != significa "diferente de"
    //other: significa "otro"
    // if: significa "si"
    // CompareTag: significa "comparar etiqueta"
    // GameObject: significa "objeto de juego"
    // Instantiate: significa "instanciar"
    // funcion OnTriggerEnter: significa "función al entrar en el disparador"
    // else: significa "de lo contrario"
    // transform.position: significa "posición de la transformación"
    // Quaternion.identity: significa "identidad de cuaternión"
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Ball"))
       {
           quienEmite.PlayOneShot(clipASonar, volumen);
           
       }
       if (effectsGoal != null)
       {
           Instantiate(effectsGoal, transform.position, Quaternion.identity);
       }
       
    }

    // funcion OnCollisionEnter: significa "función al entrar en colisión"
    // Lo que intento hacer en esté código es que al momento de que la pelota colisione con el jugador, suene un sonido.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            PlayerAudioSource.PlayOneShot(PlayerSoucer);
        }
        
    }
    // Aquí hago lo mismo que en la función OnCollisionEnter, pero para las paredes.
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            WallAudioSource.PlayOneShot(WallSouce);
            
        }

    }
}

