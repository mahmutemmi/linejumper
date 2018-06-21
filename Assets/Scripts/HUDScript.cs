using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour {

    float playerScore = 0;
    int lineCount = 10;

	public int getLineCount()
    {
        return lineCount;
    }
	void Update () {
        playerScore += Time.deltaTime;
	}
    public void IncreaseLine(int amount)
    {
        lineCount += amount;
    }
    public void IncreaseScore(int amout)
    {
        playerScore += amout;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Score: " + (int)playerScore * 100);
        GUI.Label(new Rect(10, 50, 100, 30), "Line Count: " + lineCount);
    }

}
