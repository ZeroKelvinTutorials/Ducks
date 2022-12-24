using System.Collections;
using UnityEngine;

//Capable of following mouse or transforms. quacks
public class Duck : MonoBehaviour
{
    //can be either FollowTransform or FollowMouse
    //which are classes that implement the Follower abstract class
    private Follow _follow;

    public virtual void OnEnable()
    {
        DuckManager.Ducks.Add(this);
    }
    void OnDisable()
    {
        DuckManager.Ducks.Remove(this);
    }

    //initializes _follow with new FollowTransform class
    public void StartFollowingTransform(Transform followTransform, float distance, float speed)
    {
        _follow = new FollowTransform(this.transform, followTransform);
        _follow.StartFollowing(distance, speed);
    }

    //Initializes _follow with new FollowMouse class
    public void StartFollowingMouse(float distance, float speed)
    {
        _follow = new FollowMouse(this.transform);
        _follow.StartFollowing(distance, speed);
    }

    void Update()
    {
        if (_follow != null && _follow.IsFollowing)
        {
            transform.position = _follow.GetNextPosition();
            transform.rotation = _follow.GetNextRotation();
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
