using UnityEngine;
public interface IFollowing
{
    bool IsFollowing { get; set; }
    Transform _ownerTransform { get; set; }
    float _followDistance { get; set; }

    void Follow(out Vector3 pos, out Quaternion rot);

    void StartFollowing()
    {
        IsFollowing = true;
    }

    void FollowPosition(Vector3 targetPosition, out Vector3 position, out Quaternion rotation)
    {
        Debug.Log(targetPosition + " " + _ownerTransform.position);
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