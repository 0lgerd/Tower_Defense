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
        try
        {
            // Disable camera control if the game is over
            if (GameManager.GameIsOver)
            {
                this.enabled = false;
                return;
            }

            Vector3 direction = new Vector3();

            // Check input for movement in different directions
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

            // Translate the camera based on the input
            transform.Translate(direction.normalized * panSpeed * Time.deltaTime, Space.World);

            float scroll = Input.GetAxis("Mouse ScrollWheel");

            Vector3 pos = transform.position;

            // Adjust the camera's height based on the scroll input
            pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            transform.position = pos;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Update(): {ex.Message}");
        }
    }
}
