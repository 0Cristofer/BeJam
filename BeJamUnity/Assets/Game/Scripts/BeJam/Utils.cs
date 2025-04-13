using UnityEngine;

namespace BeJam
{
    public static class Utils
    {
        public static Vector4 GetColliderBounds(Vector2 position, Vector2 boxSize)
        {
            var size = boxSize * 0.5f;

            var botLeft = position;
            botLeft.x -= size.x;
            botLeft.y -= size.y;
            
            var topRight = position;
            topRight.x += size.x;
            topRight.y += size.y;
            
            var bounds = new Vector4(botLeft.x, botLeft.y, topRight.x, topRight.y);
            
            Debug.DrawLine(botLeft ,topRight , Color.red, 0);
            return bounds;
        }

        public static bool AreCollidersCompletelyOverlapped(Vector2 positionA, Vector2 boxSizeA, Vector2 positionB, Vector2 boxSizeB)
        {
            var objABounds = GetColliderBounds(positionA, boxSizeA);
            var objBBounds = GetColliderBounds(positionB, boxSizeB);
            
            var isHidden = objABounds.x <= objBBounds.x &&
                           objABounds.y <= objBBounds.y &&
                           objABounds.z >= objBBounds.z &&
                           objABounds.w >= objBBounds.w;

            return isHidden;
        }
        
        public static bool AreCollidersIntersecting(Vector2 positionA, Vector2 boxSizeA, Vector2 positionB, Vector2 boxSizeB)
        {
            var a = new Bounds(positionA, boxSizeA);
            var b = new Bounds(positionB, boxSizeB);
            return a.Intersects(b);
            // var objABounds = GetColliderBounds(positionA, boxSizeA);
            // var objBBounds = GetColliderBounds(positionB, boxSizeB);
            //
            // var isHidden = objABounds.x <= objBBounds.x &&
            //                objABounds.y <= objBBounds.y &&
            //                objABounds.z >= objBBounds.z &&
            //                objABounds.w >= objBBounds.w;
            //
            // return isHidden;
        }

        public static bool GetBoxSizeFromCollider2D(Collider2D collider2D, out Vector2 size)
        {
            switch (collider2D)
            {
                case BoxCollider2D boxCollider:
                    size = boxCollider.size;
                    return true;
                case CircleCollider2D circleCollider:
                    size = circleCollider.radius * 2 * Vector2.one;
                    return true;
                default:
                    size = Vector2.zero;
                    return false;
            }
        }
    }    
}
