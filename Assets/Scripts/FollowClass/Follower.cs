using UnityEngine;

public abstract class Follower
{

    public bool IsFollowing;
    private Transform _ownerTransform;
    private float _followDistance;
    private float _movementSpeed;

    //Constructor
    public Follower(Transform ownerTransform)
    {
        _ownerTransform = ownerTransform;
    }

    public void StartFollowing(float distance, float speed)
    {
        _followDistance = distance;
        IsFollowing = true;
    }

    public abstract Vector3 GetNextPosition(); //abstract (must be implemented wherever class is inherited)
    protected Vector3 GetNextPosition(Vector3 targetPosition) //has default behaviour
    {
        if (Vector3.Distance(targetPosition, _ownerTransform.position) > _followDistance)
        {
            //returns a position from current position towards targetPosition
            Vector3 pos = Vector3.MoveTowards(_ownerTransform.position, targetPosition, _movementSpeed * Time.deltaTime);
            return pos;
        }
        return _ownerTransform.position;
    }

    public abstract Quaternion GetNextRotation(); //abstract (must be implemented wherever class is inherited)
    protected Quaternion GetNextRotation(Vector3 targetPosition) //has default behaviour
    {
        Vector3 targetDirection = targetPosition - _ownerTransform.position;
        float targetAngle = (Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg);
        Quaternion newQuaternion = Quaternion.AngleAxis(targetAngle, Vector3.forward);
        float rotationSpeed = 200;
        //returns a rotation from current rotation towards fully rotated towards targetPosition
        return Quaternion.RotateTowards(_ownerTransform.rotation, newQuaternion, rotationSpeed * Time.deltaTime);
    }
}