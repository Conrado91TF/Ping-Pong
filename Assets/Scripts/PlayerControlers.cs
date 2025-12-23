using UnityEngine;

public class PlayerControlers : MonoBehaviour
{
    [SerializeField]
    KeyCode upInput;
    [SerializeField]
    KeyCode downInput;
    [SerializeField]
    private float velocidadMovimiento = 5f;

    // new vector3(1.0f,1.0f,1.0f) significa escala en x=1.0,y=1.0,z=1.0
    // vector3 significa escala en x,y,z
    // vector3.one significa escala 1,1,1
    // vector3.zero significa escala 0,0,0
    // vector2 significa escala en x,y
    // keycode es para definir las teclas de entrada
    // else if es para definir una segunda condicion y significa "si no"
    // VECTOR3.FORWARD es para mover hacia adelante en el eje z
    // VECTOR3.BACK es para mover hacia atras en el eje z
    void Start()
    {
        

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
      transform.position += Vector3.forward * Time.deltaTime * velocidadMovimiento;
      transform.position += Vector3.back * Time.deltaTime * velocidadMovimiento;
    }

}
