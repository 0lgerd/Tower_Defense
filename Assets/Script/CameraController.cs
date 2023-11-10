using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBoardThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    void Update()
    {
        if(GameManager.GameIsOver)
        {
           this.enabled = false;
           return;
        }

        Vector3 direction = new Vector3();

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBoardThickness)
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBoardThickness)
        {
            direction += Vector3.back;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBoardThickness)
        {
            direction += Vector3.right;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBoardThickness)
        {
            direction += Vector3.left;
        }

        transform.Translate(direction.normalized * panSpeed * Time.deltaTime, Space.World);

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

    }
}
