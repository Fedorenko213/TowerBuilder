using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    private Camera myCamera;

    [SerializeField] private RectTransform boxVisusal;

    private Rect selectionBox;

    private Vector2 starartPosition;
    private Vector2 endPosition;

    private void Start()
    {
        myCamera = Camera.main;
        starartPosition = Vector2.zero;
        endPosition = Vector2.zero;
        DrawVisual();
    }

    private void Update()
    {
        // When clicked 
        if (Input.GetMouseButtonDown(0))
        {
            starartPosition = Input.mousePosition;
            selectionBox = new Rect();
        }
        // When dragging
        if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }
        // When release click

        if (Input.GetMouseButtonUp(0))
        {
            SelectUnits();
            starartPosition = Vector2.zero;
            endPosition = Vector2.zero;
            DrawVisual();
            
        }
    }

    private void DrawVisual()
    {
        Vector2 boxStart = starartPosition;
        Vector2 boxEnd = endPosition;
        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisusal.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));

        boxVisusal.sizeDelta = boxSize;
    }

    private void DrawSelection()
    {
        // do X calculations
        if (Input.mousePosition.x < starartPosition.x)
        {
            // Dragging left 
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = starartPosition.x;
        }
        else
        {
            // Dragging right
            selectionBox.xMin = starartPosition.x;
            selectionBox.xMax = Input.mousePosition.x;
        }
        
        // do y calculations
        if (Input.mousePosition.y < starartPosition.y)
        {
            // Dragging down
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = starartPosition.y;
        }
        else
        {
            // Dragging Up
            selectionBox.yMin = starartPosition.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }

    private void SelectUnits()
    {
        // Loop thru all the units
        foreach (var unit in UnitSelections.Instance.unitList)
        {
            // if unit is within the bounds of the selection rect 
            if (selectionBox.Contains(myCamera.WorldToScreenPoint(unit.transform.position)))
            {
                // if any Unit is within the selection and them to selection
                UnitSelections.Instance.DragSelect(unit);
            }
        }
    }
}
