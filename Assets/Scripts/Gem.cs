using System;
using System.Collections;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField]
    private BoxManager.gemColors _color;

    private Material _targetMaterial;
    
    [SerializeField]
    private Color _emissionColor;
    private float _emissionDelay = 0.5f;

    private void Start()
    {
        _targetMaterial = GetComponentInChildren<Renderer>().material;
        ChangeEmission(false);
    }

    public BoxManager.gemColors GemColor { get => _color;}

    public void ChangeEmission(bool isEmitting)
    {
        if (isEmitting)
        {
            _targetMaterial.SetColor("_EmissionColor", _emissionColor);
            StartCoroutine(EndEmissionAfterDelay());
        } else
        {
            _targetMaterial.SetColor("_EmissionColor", Color.black);
        }
    }

    private IEnumerator EndEmissionAfterDelay()
    {
        yield return new WaitForSeconds(_emissionDelay);
        ChangeEmission(false);
    }
}