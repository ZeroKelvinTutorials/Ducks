using UnityEngine;

public class FollowMouse : Follow
{
    //this is a FollowMouse specific Property (not from Follow abstract class)
    Vector3 mousePosition
    {
        get
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            return position;
        }
    }

    //constructor which calls base class constructor (Follow(ownerTransform)
    public FollowMouse(Transform ownerTransform) : base(ownerTransform) { }

    //overrides Follow.GetNextPosition()
    public override Vector3 GetNextPosition()
    {
        //returns Follow.GetNextPosition(Vector3)
        return GetNextPosition(mousePosition);
    }

    //overrides Follow.GetNextRotation()
    public override Quaternion GetNextRotation()
    {
        //returns Follow.GetNextRotation(Vector3)
        return GetNextRotation(mousePosition);
    }
}