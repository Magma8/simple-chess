using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [SerializeField] private Material darkSquareMat;
    [SerializeField] private Material lightSquareMat;

    private void Start()
    {
        Grid squaresGrid = new Grid(8, 8, darkSquareMat, lightSquareMat, transform);
    }
}
