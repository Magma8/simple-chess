using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [SerializeField] private Material darkSquareMat;
    [SerializeField] private Material lightSquareMat;

    private void Start()
    {
        Grid chessBoard = new Grid(8, 8, darkSquareMat, lightSquareMat, transform);
    }
}
