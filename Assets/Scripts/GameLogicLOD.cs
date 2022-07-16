using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicLOD : MonoBehaviour
{
    public enum ELODLevel
    {
        LOD0,
        LOD1,
        LOD2,
        Culled
    }

    public float LOD0Distance = 30f;
    public float LOD1Distance = 60f;
    public float LOD2Distance = 90f;
    public float QueryInterval = 0.1f;

    public ELODLevel CurrentLOD { get; private set; } = ELODLevel.LOD0;

    float NextQueryTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        RecalculateLOD();
    }

    // Update is called once per frame
    void Update()
    {
        NextQueryTime -= Time.deltaTime;
        if (NextQueryTime <= 0f)
        {
            NextQueryTime = QueryInterval;

            RecalculateLOD();
        }
    }

    void RecalculateLOD()
    {
        float distanceSq = (Camera.main.transform.position - transform.position).sqrMagnitude;

        if (distanceSq <= LOD0Distance * LOD0Distance)
            CurrentLOD = ELODLevel.LOD0;
        else if (distanceSq <= LOD1Distance * LOD1Distance)
            CurrentLOD = ELODLevel.LOD1;
        else if (distanceSq <= LOD2Distance * LOD2Distance)
            CurrentLOD = ELODLevel.LOD2;
        else
            CurrentLOD = ELODLevel.Culled;
    }
}
