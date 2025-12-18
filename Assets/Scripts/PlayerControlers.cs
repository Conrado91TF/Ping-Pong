using UnityEngine;

public class PlayerControlers : MonoBehaviour
{
    [SerializeField]
    KeyCode upInput;
    [SerializeField]
    KeyCode downInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
    }
}
