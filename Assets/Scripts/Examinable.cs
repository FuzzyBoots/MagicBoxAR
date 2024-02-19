using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examinable : MonoBehaviour
{
    [SerializeField] ExaminableManager _manager;
    // Start is called before the first frame update
    void Start()
    {
        _manager = FindObjectOfType<ExaminableManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
