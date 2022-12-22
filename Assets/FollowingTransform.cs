using UnityEngine;

public class FollowingTransform : IFollowing
{

    Transform FollowTransform { get; set; }

    //IFollowing properties
    public IFollowing iFollowing { get { return this; } }
    public bool IsFollowing { get; set; }
    public Transform OwnerTransform { get; set; }
    public float FollowDistance { get; set; }
    public float MovementSpeed { get; set; } = 1.3f;
    public float RotationSpeed { get; set; } = 100;

    //Constructor
    public FollowingTransform(Transform ownerTransform, float followDistance, Transform followTransform)
    {
        this.OwnerTransform = ownerTransform;
        this.FollowDistance = followDistance;
        this.FollowTransform = followTransform;
    }

    //IFollowing methods
    public Vector3 GetNextPosition()
    {
        return iFollowing.GetNextPosition(FollowTransform.position);
    }
    public Quaternion GetNextRotation()
    {
        return iFollowing.GetNextRotation(FollowTransform.position);
    }

}