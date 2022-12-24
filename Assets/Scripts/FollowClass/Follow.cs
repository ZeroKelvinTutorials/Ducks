using UnityEngine;

public abstract class Follow
{
    public bool IsFollowing;

    // movement/rotation variables
    // could make public if need to change or could make public SetX() methods
    private Transform _ownerTransform; //self
    private float _followDistance; //if further than this, follow
    private float _movementSpeed;

    //Constructor, called on the constructor of classes that inherit it
    public Follow(Transform ownerTransform)
    {
        _ownerTransform = ownerTransform;
    }

    public void StartFollowing(float distance, float speed)
    {
        _followDistance = distance;
        _movementSpeed = speed;
        IsFollowing = true;
    }

    public abstract Vector3 GetNextPosition(); //abstract (must be overriden wherever class is inherited)
    protected Vector3 GetNextPosition(Vector3 targetPosition) //handles movement  behaviour
    {
        if (Vector3.Distance(targetPosition, _ownerTransform.position) > _followDistance)
        {
            //returns a position from current position towards targetPosition
            return Vector3.MoveTowards(_ownerTransform.position, targetPosition, _movementSpeed * Time.deltaTime);
        }
        return _ownerTransform.position;
    }

    public abstract Quaternion GetNextRotation(); //abstract (must be overriden wherever class is inherited)
    protected Quaternion GetNextRotation(Vector3 targetPosition) //handles rotating behaviour
    {
        Vector3 targetDirection = targetPosition - _ownerTransform.position;
        float targetAngle = (Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg);
        Quaternion newQuaternion = Quaternion.AngleAxis(targetAngle, Vector3.forward);
        float rotationSpeed = 200;
        //returns a rotation from current rotation towards fully rotated towards targetPosition
        return Quaternion.RotateTowards(_ownerTransform.rotation, newQuaternion, rotationSpeed * Time.deltaTime);
    }
}