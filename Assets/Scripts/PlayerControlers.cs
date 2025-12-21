using UnityEngine;

public class PlayerControlers : MonoBehaviour
{
    [SerializeField]
    KeyCode upInput;
    [SerializeField]
    KeyCode downInput;
    [SerializeField]
    float animationPlayer = 0.5f;
    public LeanTweenType tipoEasing = LeanTweenType.easeInOutSine;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // animacion de entrada del jugador continuamente

        LeanTween.scale(gameObject, new Vector3(1.0f, 1.0f, 1.0f), animationPlayer).setEase(tipoEasing).setLoopPingPong();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upInput))
        {
            transform.position += Vector3.forward * Time.deltaTime * 10f;
        }
        else if (Input.GetKey(downInput))
        {
            transform.position += Vector3.back * Time.deltaTime * 10f;
        }
    }
}
