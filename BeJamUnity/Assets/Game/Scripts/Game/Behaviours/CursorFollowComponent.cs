using TMPro;
using UnityEngine;

public class CursorFollowComponent : MonoBehaviour
{
    public Camera mainCamera;
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
            mousePosition.x = Mathf.Clamp(Input.mousePosition.x, 0.0f, Screen.width);
            mousePosition.y = Mathf.Clamp(Input.mousePosition.y, 0.0f, Screen.height);
            if (mainCamera is not null)
            {
                mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
                transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            }
    }
}
