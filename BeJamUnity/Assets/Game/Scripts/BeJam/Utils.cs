using UnityEngine;

namespace BeJam
{
    public static class Utils
    {
        public static Vector4 GetColliderBounds(Collider2D colliderUnder)
        {
            var size = Vector2.zero;
            
            if (colliderUnder is BoxCollider2D boxCollider)
                size = boxCollider.size * 0.5f * colliderUnder.gameObject.transform.localScale;
            else if (colliderUnder is CircleCollider2D circleCollider)
                size = circleCollider.radius * colliderUnder.gameObject.transform.localScale;

            Vector2 botLeft = colliderUnder.gameObject.transform.position;
            botLeft.x -= size.x;
            botLeft.y -= size.y;
            
            Vector2 topRight = colliderUnder.gameObject.transform.position;
            topRight.x += size.x;
            topRight.y += size.y;
            
            var bounds = new Vector4(botLeft.x, botLeft.y, topRight.x, topRight.y);
            
            Debug.DrawLine(botLeft ,topRight , Color.red, 0);
            return bounds;
        }

        public static bool AreCollidersCompletelyOverlapped(Collider2D colliderA, Collider2D colliderB)
        {
            var postItBounds = GetColliderBounds(colliderA);
            var objBounds = GetColliderBounds(colliderB);
            
            var isHidden = postItBounds.x < objBounds.x &&
                           postItBounds.y < objBounds.y &&
                           postItBounds.z > objBounds.z &&
                           postItBounds.w > objBounds.w;
            
            return isHidden;
        }
    }    
}
