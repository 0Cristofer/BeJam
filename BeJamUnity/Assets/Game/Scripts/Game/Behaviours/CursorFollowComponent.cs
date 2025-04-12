using TMPro;
using UnityEngine;

public class CursorFollowComponent : MonoBehaviour
{
    public Canvas canvas;
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
            mousePosition = Input.mousePosition;
            if (mainCamera is not null)
            {
                mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
                // if (mousePosition.x > -Screen.width * 0.5f && mousePosition.x < Screen.width * 0.5f &&
                //     mousePosition.x > -Screen.height * 0.5f && mousePosition.y < Screen.height * 0.5f)
                // {
                    transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
                // }
            }
    }
}
