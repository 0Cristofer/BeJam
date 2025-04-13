using UnityEngine;

namespace BeJam
{
    public class CursorFollowComponent : MonoBehaviour
    {
        [field: SerializeField]
        private Camera Camera { get; set; }
        
        [field: SerializeField]
        private bool LerpPosition { get; set; }
        
        [field: SerializeField]
        private float MoveSpeed { get; set; }

        private void Update()
        {
            Vector2 mousePosition;
            
            mousePosition.x = Mathf.Clamp(Input.mousePosition.x, 0.0f, Screen.width);
            mousePosition.y = Mathf.Clamp(Input.mousePosition.y, 0.0f, Screen.height);

            if (Camera is null)
                return;
            
            var targetPosition = Camera.ScreenToWorldPoint(mousePosition);

            Vector2 newPosition;
            if (LerpPosition)
            {
                newPosition = Vector2.Lerp(transform.position, targetPosition, MoveSpeed);
            }
            else
            {
                newPosition = new Vector2(targetPosition.x, targetPosition.y);
            }
            
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }   
}
