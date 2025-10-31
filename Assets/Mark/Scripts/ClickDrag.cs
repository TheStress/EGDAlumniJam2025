using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

/// <summary>
/// Using Event Systems to track when the mouse is clicked and dragged over this object
/// IPointerDownHandler tracks when mouse is clicked over object
/// IBeginDragHandler tracks when drag begins - mouse is held over object
/// IDragHandler tracks when dragging is happening(i.e when mouse is held over object AND moving)
/// IEndDragHandler tracks when drag ends - mouse is release
/// </summary>
/// 
public class ClickDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IDragHandler
{
    private Transform _transform;
    public Camera cam;
    private Vector3 newMousePos;

    
    public float spawnMinX;
    public float spawnMinY;
    public float spawnMaxX;
    public float spawnMaxY;

    
    public float snapPosX;
    public float snapPosY;

    private bool canDrag = true;
    public bool inPlace = false;

    public string winTag;
    /*
     //called in any instance where this script is loaded. i.e in hierarchy on game start, or when activated or instantiated during game
     */
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        //cam = Camera.main;
        _transform.position = new Vector3(Random.Range(spawnMinX, spawnMaxX), Random.Range(spawnMinY, spawnMaxY));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("ckick");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("dragging start");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(canDrag)
        {
            if (inPlace)
            {
                //can no longer drag
                //send transform to inPlace ps
                Debug.Log("snap in place");
                canDrag = false;
            }


            //delta is the value for how much the mouse has moved since the previous frame.
            //the mouse moves on a different scale that the objects on the screen
            //take the mouse position, and use ScreentoWorld point to convert its pos to the world pos, which is alligned with objects
            //then set this object's postion to the converted mouse position
            
            newMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            _transform.position = new Vector3(newMousePos.x, newMousePos.y, 0);
        }
        

    }
    

    public void OnEndDrag(PointerEventData eventData)
    {
        
        //with this here, body part will snap in place AFTER player lets go
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == winTag)
        {
            inPlace = true;
        }
    }

}
