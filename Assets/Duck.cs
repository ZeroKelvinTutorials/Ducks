using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Capable of following mouse or transforms
//Wanders, Quacks
public class Duck : MonoBehaviour
{
    //can be either FollowingTransform or FollowingMouse
    //which are classes that implement the IFollowing interface
    public IFollowing _following;

    public virtual void OnEnable()
    {
        DuckManager.Ducks.Add(this);
    }
    void OnDisable()
    {
        DuckManager.Ducks.Remove(this);
    }

    //initializes _following with new FollowingTransform class
    public void StartFollowingTransform(Transform followTransform, float distance, float speed)
    {
        _following = new FollowingTransform(this.transform, followTransform);
        _following.StartFollowing(distance, speed);
    }

    //Initializes _following with new FollowingMouse class
    public void StartFollowingMouse(float distance, float speed)
    {
        _following = new FollowingMouse(this.transform);
        _following.StartFollowing(distance, speed);
    }

    void Update()
    {
        if (_following != null && _following.IsFollowing)
        {
            transform.position = _following.GetNextPosition();
            transform.rotation = _following.GetNextRotation();
        }
        TryQuack();
    }

    void TryQuack()
    {
        if (Random.Range(0, 10f) > 9.8)
        {
            StartCoroutine(Quack());
        }

        IEnumerator Quack()
        {
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
