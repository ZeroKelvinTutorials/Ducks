using UnityEngine;

public class FollowTransform : Follow
{
    //this is a FollowTransform specific variable, (not from Follow abstract class)
    private Transform _followTransform;

    //constructor which calls base class constructor and adds _followTransform locally
    public FollowTransform(Transform ownerTransform, Transform followTransform) : base(ownerTransform)
    {
        _followTransform = followTransform;
    }

    //implements the abstract Follow.GetNextPosition()
    public override Vector3 GetNextPosition()
    {
        //returns Follow.GetNextPosition(Vector3)
        return GetNextPosition(_followTransform.position);
    }

    //implements the abstract Follow.GetNextRotation()
    public override Quaternion GetNextRotation()
    {
        //returns Follow.GetNextRotation(Vector3)
        return GetNextRotation(_followTransform.position);
    }
}