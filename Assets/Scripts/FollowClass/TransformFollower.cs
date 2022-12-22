using UnityEngine;

public class TransformFollower : Follower
{
    Transform _followTransform;

    public TransformFollower(Transform ownerTransform, Transform followTransform) : base(ownerTransform)
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