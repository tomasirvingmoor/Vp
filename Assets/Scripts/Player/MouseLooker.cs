using UnityEngine;

public class MouseLooker : MonoBehaviour
{
    public Vector2 mousePosition { get; private set; }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
