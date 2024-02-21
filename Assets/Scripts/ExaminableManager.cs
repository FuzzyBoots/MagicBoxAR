using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminableManager : MonoBehaviour
{
    [SerializeField]
    Transform _examineTarget;

    Transform _priorTargetTransform;

    Examinable _examinedObject;

    public void PerformExamination(Examinable target)
    {
        if (target == null || _examineTarget == null) return;

        _examinedObject = target;

        _priorTargetTransform = target.transform;

        target.transform.position = _examineTarget.position;
        Debug.Log("Compare positions");
        Debug.Log(_priorTargetTransform.position);
        Debug.Log(target.transform.position);

        target.transform.parent = _examineTarget;
    }

    public void Unexamine()
    {
        _examinedObject.transform.position = _priorTargetTransform.position;
        _examinedObject.transform.rotation = _priorTargetTransform.rotation;
        _examinedObject.transform.parent = null;
    }
}
