using UnityEngine;


public class FollowingTransform : IFollowing
{
    public bool IsFollowing { get; set; }
    public Transform _ownerTransform { get; set; }
    public float _followDistance { get; set; }

    Transform _followTransform { get; set; }

    public FollowingTransform(Transform ownerTransform, float followDistance, Transform followTransform)
    {
        _ownerTransform = ownerTransform;
        _followDistance = followDistance;
        _followTransform = followTransform;
    }
    public void Follow(out Vector3 pos, out Quaternion rot)
    {
        IFollowing iFollowing = this;
        iFollowing.FollowPosition(_followTransform.position, out pos, out rot);
    }
}