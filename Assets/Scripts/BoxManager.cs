using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public enum gemColors
    {
        Red,
        Green,
        Blue
    }

    [SerializeField] gemColors[] _solution = { gemColors.Red, gemColors.Blue, gemColors.Green };
    Queue<gemColors> _queue = new Queue<gemColors>();

    [SerializeField] Animator _boxAnimator;
        
    public void GemSelect(Gem curGem)
    {
        print(curGem.GemColor);
        // Enqueue the gem color
        _queue.Enqueue(curGem.GemColor);
        print (_queue.ToCommaSeparatedString());

        curGem.ChangeEmission(true);

        // If queue is oversize, get rid of excess
        while (_queue.Count > _solution.Length)
        {
            _queue.Dequeue();
        }

        CheckGemSolution();
    }

    private void CheckGemSolution()
    {
        // Check gem solution
        gemColors[] current = _queue.ToArray();

        if (Enumerable.SequenceEqual<gemColors>(current, _solution))
        {
            _boxAnimator.SetTrigger("Open");
        }
    }
}
