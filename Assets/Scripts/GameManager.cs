using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public int points;

    public void AddPoints(int numPoints)
    {
        points += numPoints;
        scoreText.text = points.ToString();
    }
}
