using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminableManager : MonoBehaviour
{
    [SerializeField]
    Transform _examineTarget;

    public void PerformExamination(Examinable target)
    {
        if (target == null || _examineTarget == null) return;

        target.transform.position = _examineTarget.position;

        target.transform.parent = _examineTarget;
    }
}
