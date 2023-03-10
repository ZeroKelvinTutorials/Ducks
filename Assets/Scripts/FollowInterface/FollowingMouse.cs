using UnityEngine;

public class FollowingMouse : IFollowing
{
    //gets mouse position in world screen with z = 0
    Vector3 mousePosition
    {
        get
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            return position;
        }
    }

    //Ifollowing properties
    public IFollowing iFollowing { get { return this; } }
    public bool IsFollowing { get; set; }
    public Transform OwnerTransform { get; set; }
    public float FollowDistance { get; set; }
    public float MovementSpeed { get; set; } = 1; //default value of 1

    //Constructor
    public FollowingMouse(Transform ownerTransform)
    {
        OwnerTransform = ownerTransform;
    }

    //IFollowing methods
    public Vector3 GetNextPosition()
    {
        return iFollowing.GetNextPosition(mousePosition);
    }
    public Quaternion GetNextRotation()
    {
        return iFollowing.GetNextRotation(mousePosition);
    }
}