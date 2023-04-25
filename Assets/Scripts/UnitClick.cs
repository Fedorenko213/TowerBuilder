
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera myCamera;

    public LayerMask clickable;

    private LayerMask Ground;
    
    // Start is called before the first frame update
    void Start()
    {
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                // if we hit a clickable object
                
                // normal click and shift  click 

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelections.Instance.ShiftClickSelect(hit.collider.gameObject);
                }
                else
                {
                    UnitSelections.Instance.ClickSelect(hit.collider.gameObject);
                }
                
            }
            else
            {
                // if we didn't 

                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelections.Instance.DeSelectAll();
                }
                
            }
            
        }
    }
}
