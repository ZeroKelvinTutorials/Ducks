using UnityEngine;

public class MouseFollower : Follower
{

    //constructor that calls base class constructor
    public MouseFollower(Transform ownerTransform, float followDistance) : base(ownerTransform, followDistance)
    {

    }

    //Gets mouse position and uses base.Follow with that position
    //outputs new position and rotation
    public override void Follow(out Vector3 position, out Quaternion rotation)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        base.FollowPosition(mousePos, out position, out rotation);
    }
}