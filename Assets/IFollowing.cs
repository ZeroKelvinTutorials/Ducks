using UnityEngine;
public interface IFollowing
{
    IFollowing iFollowing { get; }
    bool IsFollowing { get; set; }
    Transform OwnerTransform { get; set; }
    float FollowDistance { get; set; }
    float MovementSpeed { get; set; }
    float RotationSpeed { get; set; }

    void StartFollowing()
    {
        IsFollowing = true;
    }
    Vector3 GetNextPosition(); //abstract (must be implemented wherever interface is implemented)
    Vector3 GetNextPosition(Vector3 targetPosition)
    {
        if (Vector3.Distance(targetPosition, OwnerTransform.position) > FollowDistance)
        {
            //returns a position from current position towards targetPosition
            Vector3 pos = Vector3.MoveTowards(OwnerTransform.position, targetPosition, MovementSpeed * Time.deltaTime);
            Debug.Log(Vector3.Distance(pos, OwnerTransform.position) + " " + Time.deltaTime);
            return pos;
        }
        return OwnerTransform.position;
    }
    Quaternion GetNextRotation(); //abstract (must be implemented wherever interface is implemented)
    Quaternion GetNextRotation(Vector3 targetPosition)
    {
        Vector3 targetDirection = targetPosition - OwnerTransform.position;
        float targetAngle = (Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg);
        Quaternion newQuaternion = Quaternion.AngleAxis(targetAngle, Vector3.forward);

        //returns a rotation from current rotation towards fully rotated towards targetPosition
        return Quaternion.RotateTowards(OwnerTransform.rotation, newQuaternion, RotationSpeed * Time.deltaTime);
    }
}