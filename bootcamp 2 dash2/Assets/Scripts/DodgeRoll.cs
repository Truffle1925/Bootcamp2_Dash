using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeRoll : MonoBehaviour
{

    private Movement2D move;
    bool roll = false;
    public int cooldown = 3;
    [SerializeField] float boost = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = GetComponent<Movement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("rightclick");

            if (!roll)
            {
                Debug.Log("rolling");
                roll = true;
                Dodge();
            }
        }
    }

    void Dodge()
    {
        move.Dodger(boost);
        StartCoroutine(CoolDown());
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(.1f);

        float sD = boost - (boost * 2);
        move.Dodger(sD);
        Debug.Log("coroutine acomplished");

        yield return new WaitForSeconds(coolDownTime);

        roll = false;
    }
}
