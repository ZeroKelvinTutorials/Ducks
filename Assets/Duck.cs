using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Capable of following mouse or other transforms
//Wanders, Quacks
public class Duck : MonoBehaviour
{
    public IFollowing _following;

    public virtual void OnEnable()
    {
        DuckManager.Ducks.Add(this);
    }

    void OnDisable()
    {
        DuckManager.Ducks.Remove(this);
    }

    //Starts following target transform at max desired proximity distance
    public void StartFollowingTransform(Transform followTransform, float distance)
    {
        _following = new FollowingTransform(this.transform, distance, followTransform);
        _following.StartFollowing();
    }

    //Starts following mouse at max desired proximity distance
    public void StartFollowingMouse(float distance)
    {
        _following = new FollowingMouse(this.transform, distance);
        _following.StartFollowing();
    }

    //handles movement
    public virtual void Update()
    {
        //if following, update position and rotation accordingly
        //_following can be either FollowingTransform or FollowingMouse
        if (_following != null && _following.IsFollowing)
        {
            transform.position = _following.GetNextPosition();
            transform.rotation = _following.GetNextRotation();
        }
    }
}
