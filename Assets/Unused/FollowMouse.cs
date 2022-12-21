using UnityEngine;

public class FollowMouse : Follower
{
    //constructor that calls base class constructor
    public FollowMouse(Transform ownerTransform, float followDistance) : base(ownerTransform, followDistance)
    {

    }

    //Gets mouse position and uses base.Follow with that position
    //outputs new position and rotation
    public void Follow(out Vector3 position, out Quaternion rotation)
    {
        Debug.Log("following mouse");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Follow(mousePos, out position, out rotation);
    }
}