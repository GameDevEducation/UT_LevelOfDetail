using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float MovementAmount = 2f;
    public float MovementSpeed = 1f;

    Vector3 InitialPosition;
    GameLogicLOD LogicLOD;

    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = transform.position;
        LogicLOD = GetComponent<GameLogicLOD>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LogicLOD.CurrentLOD == GameLogicLOD.ELODLevel.Culled)
            return;

        float heightOffset = Mathf.Sin(Mathf.PingPong(Time.time * MovementSpeed, 1f) * Mathf.PI * 2f) * MovementAmount;
        transform.position = InitialPosition + Vector3.up * heightOffset;
    }
}
