using System;
using System.Collections.Generic;
using UnityEngine;

namespace BeJam
{
    public class PostIt : MonoBehaviour
    {
        private Dictionary<string, GameObject> _pawns;
        
        void Start()
        {
            _pawns = new Dictionary<string, GameObject>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (_pawns.Count > 0)
            {
                foreach (KeyValuePair<string, GameObject> kpv in _pawns)
                {
                    if (IsCompletlyHidden(kpv.Value))
                    {
                        Debug.Log("HIDEN!!!!!!!!!!!!!!!!!!!");
                        // TODO : STUFF ON COVERED
                    }
                }
            }
        }

        bool IsCompletlyHidden(GameObject go)
        {
            Vector4 postItBounds = GetSpriteBounds(gameObject);
            Vector4 objBounds = GetSpriteBounds(go);
            
            bool isHidden = postItBounds.x < objBounds.x &&
                            postItBounds.y < objBounds.y &&
                            postItBounds.z > objBounds.z &&
                            postItBounds.w > objBounds.w;
            
            return isHidden;
        }

        Vector4 GetSpriteBounds(GameObject go)
        {
            Vector2 size = Vector2.zero;
            
            // uncomment the one you want
            //size = go.GetComponent<SpriteRenderer>().size * transform.localScale;
            Collider2D collider = go.GetComponent<Collider2D>();
            if (collider.GetType() == typeof(BoxCollider2D))
                size = go.GetComponent<BoxCollider2D>().size * 0.5f * go.transform.localScale;
            else if (collider.GetType() == typeof(CircleCollider2D))
                size = go.GetComponent<CircleCollider2D>().radius * go.transform.localScale;

            Vector2 botLeft = go.transform.position;
            botLeft.x -= size.x;
            botLeft.y -= size.y;
            
            Vector2 topRight = go.transform.position;
            topRight.x += size.x;
            topRight.y += size.y;
            
            Vector4 bounds = new Vector4(botLeft.x, botLeft.y, topRight.x, topRight.y);
            
            Debug.DrawLine(botLeft ,topRight , Color.red, 0);
            return bounds;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Pawn"))
            {
                _pawns.Add(other.name, other.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Pawn"))
            {
                _pawns.Remove(other.name);
            }
        }
    }    
}

