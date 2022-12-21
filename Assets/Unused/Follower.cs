using UnityEngine;

public abstract class Follower
{
    public bool IsFollowing;
    private float _followDistance;
    private Transform _ownerTransform;

    //Constructor
    public Follower(Transform ownerTransform, float followDistance)
    {
        IsFollowing = true;
        _followDistance = followDistance;
        _ownerTransform = ownerTransform;
    }

    public void StartFollowing()
    {
        IsFollowing = true;
    }

    public void FollowPosition(Vector3 targetPosition, out Vector3 position, out Quaternion rotation)
    {
        position = _ownerTransform.position;

        //move towards target if further than distance
        if (Vector3.Distance(targetPosition, _ownerTransform.position) > _followDistance)
        {
            position = Vector3.MoveTowards(_ownerTransform.position, targetPosition, 1f * Time.deltaTime);
        }

        //rotate towards target
        Vector3 targetDirection = targetPosition - _ownerTransform.position;
        float targetAngle = (Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg);
        Quaternion newQuaternion = Quaternion.AngleAxis(targetAngle, Vector3.forward);

        rotation = Quaternion.RotateTowards(_ownerTransform.rotation, newQuaternion, 100 * Time.deltaTime);
    }
    public abstract void Follow(out Vector3 position, out Quaternion rotation);

}