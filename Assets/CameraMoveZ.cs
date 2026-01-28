using UnityEngine;

public class CameraMoveZ : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W))
            moveZ = 1f;
        else if (Input.GetKey(KeyCode.S))
            moveZ = -1f;

        transform.Translate(0, 0, moveZ * speed * Time.deltaTime);
    }
}
