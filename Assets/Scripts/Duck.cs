using System.Collections;
using UnityEngine;

//Capable of following mouse or transforms, quacks
public class Duck : MonoBehaviour
{
    //can be either TransformFollower or MouseFollower
    //which are classes that implement the Follower abstract class
    private Follow _follower;

    public virtual void OnEnable()
    {
        DuckManager.Ducks.Add(this);
    }
    void OnDisable()
    {
        DuckManager.Ducks.Remove(this);
    }

    //initializes _follower with new TransformFollower class
    public void StartFollowingTransform(Transform followTransform, float distance, float speed)
    {
        _follower = new FollowTransform(this.transform, followTransform);
        _follower.StartFollowing(distance, speed);
    }

    //Initializes _follower with new MouseFollower class
    public void StartFollowingMouse(float distance, float speed)
    {
        _follower = new FollowMouse(this.transform);
        _follower.StartFollowing(distance, speed);
    }

    void Update()
    {
        if (_follower != null && _follower.IsFollowing)
        {
            transform.position = _follower.GetNextPosition();
            transform.rotation = _follower.GetNextRotation();
        }
        TryQuack();
    }

    public void TryQuack()
    {
        if (Random.Range(0, 10f) > 9.8)
        {
            StartCoroutine(Quack());
        }

        IEnumerator Quack()
        {
            //not cacheing this to keep it neater for highlight the follow stuff
            TMPro.TextMeshPro textMeshPro = GetComponentInChildren<TMPro.TextMeshPro>();
            if (textMeshPro != null)
            {
                textMeshPro.text = "Quack";
                textMeshPro.enabled = true;
                yield return new WaitForSeconds(.5f);
                textMeshPro.enabled = false;
            }
        }
    }
}
