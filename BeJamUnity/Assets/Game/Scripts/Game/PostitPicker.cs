using BeJam;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PostitPicker : MonoBehaviour
{
    private PostIt postit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit.collider != null)
            {
                Debug.Log ("Target Position: " + hit.collider.gameObject.transform.position);
                var pickedPostIt = hit.collider.gameObject.GetComponent<PostIt>();
                if (pickedPostIt != null)
                {
                    postit = pickedPostIt;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            postit = null;
        }

        if (postit != null)
        {
            postit.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4.0f));
        }
    }

    void FixedUpdate()
    {
    }
}
