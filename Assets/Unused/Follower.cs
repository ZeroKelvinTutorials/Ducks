using UnityEngine;
public abstract class Follower
{
    public bool IsFollowing;
    float _followDistance;
    Transform _ownerTransform;

    //Constructor
    public Follower(Transform ownerTransform, float followDistance)
    {
        _ownerTransform = ownerTransform;
        _followDistance = followDistance;
    }

    public void StartFollowing()
    {
        IsFollowing = true;
    }

    //has owner transform follow a target position
    //outputs new position and rotation of owner transform
    public void Follow(Vector3 targetPosition, out Vector3 position, out Quaternion rotation)
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
}