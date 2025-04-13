using UnityEngine;

namespace BeJam
{
    public class PostIt : MonoBehaviour
    {
        [field: SerializeField]
        private BoxCollider2D Collider2D { get; set; }
        
        [field: SerializeField]
        private SpriteRenderer SpriteRenderer { get; set; }
        
        [field: SerializeField]
        private float PickedAlpha { get; set; }

        private bool IsPicked { get; set; }

        private void Start()
        {
            Drop();
        }

        public void Pick()
        {
            IsPicked = true;
            
            var newColor = SpriteRenderer.color;
            newColor.a = PickedAlpha;
            
            SpriteRenderer.color = newColor;
        }
        
        public void Drop()
        {
            IsPicked = false;
            
            var newColor = SpriteRenderer.color;
            newColor.a = 1f;
            
            SpriteRenderer.color = newColor;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (IsPicked)
            {
                return;
            }
            
            var coverableEntity = other.gameObject.GetComponent<ICoverableEntity>();
            var otherCollider = other.GetComponent<Collider2D>();
            
            if (coverableEntity == null || otherCollider == null)
                return;

            if (!Utils.GetBoxSizeFromCollider2D(otherCollider, out var otherSize))
            {
                return;
            }

            if (Utils.AreCollidersCompletelyOverlapped(transform.position, Collider2D.size, otherCollider.gameObject.transform.position, otherSize))
            {
                coverableEntity.OnCovered();
            }
        }
    }
}

