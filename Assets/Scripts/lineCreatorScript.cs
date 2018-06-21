using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineCreatorScript : MonoBehaviour {
    public GameObject linePrefab;
    Line activeLine;
    HUDScript hud;

    private void Start()
    {
        hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
    }

    void Update () {
        int lineCount = hud.getLineCount();
        if (lineCount <= 0)
            return;
        if(Input.GetMouseButton(0))
        {
            if(activeLine == null)
            {
                GameObject lineObj = Instantiate(linePrefab);
                Destroy(lineObj, 0.8f);
                activeLine = lineObj.GetComponent<Line>();
                hud.IncreaseLine(-1);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }
        if(activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.updateLine(mousePos);
        }
		
	}
}
