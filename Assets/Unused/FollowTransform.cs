using UnityEngine;

public class FollowTransform : Follower
{
    Transform _followTransform;

    public FollowTransform(Transform ownerTransform, float followDistance, Transform followTransform) :
        base(ownerTransform, followDistance)
    {
        _followTransform = followTransform;
    }
    // public void Follow(Transform followTransform)
    public void Follow(out Vector3 position, out Quaternion rotation)
    {
        base.Follow(_followTransform.position, out position, out rotation);
    }
}