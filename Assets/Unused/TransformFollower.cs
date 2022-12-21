using UnityEngine;

public class TransformFollower : Follower
{
    Transform _followTransform;

    public TransformFollower(Transform ownerTransform, float followDistance, Transform followTransform) :
        base(ownerTransform, followDistance)
    {
        _followTransform = followTransform;
    }
    // public void Follow(Transform followTransform)
    public override void Follow(out Vector3 position, out Quaternion rotation)
    {
        base.FollowPosition(_followTransform.position, out position, out rotation);
    }
}