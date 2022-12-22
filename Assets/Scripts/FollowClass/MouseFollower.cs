using UnityEngine;

public class MouseFollower : Follower
{
    Vector3 mousePosition
    {
        get
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            return position;
        }
    }

    //constructor that calls base class constructor
    public MouseFollower(Transform ownerTransform) : base(ownerTransform)
    {

    }

    public override Vector3 GetNextPosition()
    {
        return GetNextPosition(mousePosition);
    }
    public override Quaternion GetNextRotation()
    {
        return GetNextRotation(mousePosition);
    }
}