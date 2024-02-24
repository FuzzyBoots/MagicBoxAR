using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField]
    private BoxManager.gemColors _color;

    public BoxManager.gemColors Color { get => _color;}
}