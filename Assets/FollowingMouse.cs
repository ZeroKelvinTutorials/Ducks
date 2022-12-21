using UnityEngine;
public class FollowingMouse : IFollowing
{

    public bool IsFollowing { get; set; }
    public Transform _ownerTransform { get; set; }
    public float _followDistance { get; set; }

    //Constructor
    public FollowingMouse(Transform ownerTransform, float followDistance)
    {
        _ownerTransform = ownerTransform;
        _followDistance = followDistance;
    }
    public void Follow(out Vector3 pos, out Quaternion rot)
    {
        IFollowing iFollowing = this;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        iFollowing.FollowPosition(mousePosition, out pos, out rot);
    }
}