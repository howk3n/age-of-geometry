using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool moveAllowed;
    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            // only interested in the first touch
            Touch touch = Input.GetTouch(0);

            // this is bad because it's pixel coordinates, and we need unity world coordinates
            // Vector2 touchPosition = touch.position; 
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position); 

            if(touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if(col == touchedCollider)
                {
                    moveAllowed = true;
                }
            }

            if(touch.phase == TouchPhase.Moved)
            {
                if(moveAllowed == true) 
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }
            
            if(touch.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
            }
        }
    }
}
