using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator CharacterAnimator;
    public int Action;
    public int ColliderAction;
    bool jump;
    public float speed = 0.2f;

    // Use this for initialization
    void Start()
    {
        jump = false;
        ChooseAction();
    }

    // Update is called once per frame
    void ChooseAction()
    {
        if (jump == false)
        {
            Action = Mathf.RoundToInt(Random.Range(0, 3));
            ChangeAction();
        }
        if (jump == true)
        {
            Action = 3;
            ChangeAction();
        }
    }

    void ChangeAction()
    {

        if (Action == 0)
        {
            Debug.Log("Standing");
            CharacterAnimator.SetBool("Standing", true);
            StartCoroutine(StandTimer());
        }
        if (Action == 1)
        {
            Debug.Log("Walking");
            CharacterAnimator.SetBool("Walking", true);
            Vector3 euler = transform.eulerAngles;
            euler.y = Random.Range(0f, 360f);
            transform.eulerAngles = euler;
            StartCoroutine(WalkTimer());

        }
        if (Action == 2)
        {
            Debug.Log("Waving");
            CharacterAnimator.SetBool("Waving", true);
            StartCoroutine(WaveTimer());
        }
        if (Action == 3)
        {
            Debug.Log("Jumping");
            CharacterAnimator.SetBool("Jumping", true);
            StartCoroutine(JumpTimer());
        }
    }

    IEnumerator StandTimer()
    {
        yield return new WaitForSeconds(3f);
        CharacterAnimator.SetBool("Standing", false);
        ChooseAction();
    }

    IEnumerator WalkTimer()
    {
        yield return new WaitForSeconds(3f);
        CharacterAnimator.SetBool("Walking", false);
        ChooseAction();
    }

    IEnumerator WaveTimer()
    {
        yield return new WaitForSeconds(3f);
        CharacterAnimator.SetBool("Waving", false);
        ChooseAction();
    }

    IEnumerator JumpTimer()
    {
        yield return new WaitForSeconds(2f);
        CharacterAnimator.SetBool("Jumping", false);
        jump = false;
        ChooseAction();
    }

    private void FixedUpdate()
    {
        if (CharacterAnimator.GetBool("Walking"))
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }

    void OnTriggerEnter(Collider Other)
    {
        Debug.Log("Hit Collider");
        CharacterAnimator.SetBool("Walking", false);
        transform.position -= transform.forward * 0.01f;
        jump = true;
    }
}