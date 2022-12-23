using UnityEngine;

public class FollowTransform : Follow
{
    private Transform _followTransform;

    //constructor
    public FollowTransform(Transform ownerTransform, Transform followTransform) : base(ownerTransform)
    {
        _followTransform = followTransform;
    }
    public override Vector3 GetNextPosition()
    {
        return GetNextPosition(_followTransform.position);
    }
    public override Quaternion GetNextRotation()
    {
        return GetNextRotation(_followTransform.position);
    }
}