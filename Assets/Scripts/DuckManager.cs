using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour
{

    //reference to all ducks enabled
    public static List<Duck> Ducks = new List<Duck>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetDucksInARow();
        }
    }

    void GetDucksInARow()
    {

        //First duck starts following mouse
        Ducks[0].StartFollowingMouse(distance: 1.5f, speed: 2);

        //the rest of the ducks follow the previous ducks
        for (int i = 1; i < Ducks.Count; i++)
        {
            Ducks[i].StartFollowingTransform(
                followTransform: Ducks[i - 1].transform,
                distance: 1.3f,
                speed: 1.5f);
        }

    }
}
