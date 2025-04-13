using UnityEngine;

namespace BeJam
{
    public class PostitPicker : MonoBehaviour
    {
        [field: SerializeField]
        private Camera Camera { get; set; }
        
        [field: SerializeField]
        private SpriteRenderer SpriteRenderer { get; set; }

        [field: SerializeField]
        private Sprite OpenHandSprite { get; set; }

        [field: SerializeField]
        private Sprite ClosedHandSprite { get; set; }

        private PostIt PickedPostit { get; set; }
        private Vector3 PostitOffset { get; set; }

        private void Start()
        {
            SpriteRenderer.sprite = OpenHandSprite;
        }
    
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckPostitUnder();
            }

            if (Input.GetMouseButtonUp(0))
            {
                DropPostit();
            }

            MovePostit();
        }

        private void CheckPostitUnder()
        {
            var hit = Physics2D.Raycast(Camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider == null) 
                return;
            
            Debug.Log ("Target Position: " + hit.collider.gameObject.transform.position);
            
            var pickedPostIt = hit.collider.gameObject.GetComponent<PostIt>();
            if (pickedPostIt == null)
                return;
            
            PickPostit(pickedPostIt);
        }

        private void MovePostit()
        {
            if (PickedPostit == null)
                return;
            
            var newPos = Camera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)) +
                         PostitOffset;
            PickedPostit.transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
        }

        private void DropPostit()
        {
            if (PickedPostit == null)
                return;
            
            PickedPostit.Drop();
            PickedPostit = null;
            SpriteRenderer.sprite = OpenHandSprite;
        }

        private void PickPostit(PostIt pickedPostIt)
        {
            DropPostit();

            PickedPostit = pickedPostIt;
            PostitOffset = pickedPostIt.transform.position - transform.position;
            SpriteRenderer.sprite = ClosedHandSprite;
            PickedPostit.Pick();
        }
    }
}
