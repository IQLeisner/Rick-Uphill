using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour, IScore {

    int score = 0;

    public int? GetScore()
    {
        return score;
    }

    public IEnumerable AddToScore()
    {
        score += 1;
        yield break;
    }

}
