using UnityEngine;

public abstract class Following
{
    public bool IsFollowing;

    private float _followDistance;
    // private Transform _followTransform;
    private Transform _ownerTransform;

    //Constructor
    public Following(Transform ownerTransform, float followDistance)
    {
        IsFollowing = true;
        // _followTransform = followTransform;
        _followDistance = followDistance;
        _ownerTransform = ownerTransform;
    }

    // //Constructor for mouse following
    // public Following(Transform ownerTransform, float followDistance)
    // {
    //     IsFollowing = true;
    //     _ownerTransform = ownerTransform;
    //     _followDistance = followDistance;
    // }

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

    // public void FollowMouse(out Vector3 position, out Quaternion rotation)
    // {
    //     Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     mousePos.z = 0;
    //     Debug.Log(mousePos);
    //     FollowPosition(mousePos, out position, out rotation);
    // }

    // public void Follow(out Vector3 position, out Quaternion rotation)
    // {
    //     if (_followTransform == null)
    //     {
    //         Debug.LogError("Cannot follow a null transform");
    //         position = _ownerTransform.position;
    //         rotation = _ownerTransform.rotation;
    //         return;
    //     }
    //     FollowPosition(_followTransform.position, out position, out rotation);
    // }

    // public void StopFollowing()
    // {
    //     IsFollowing = false;
    // }
}