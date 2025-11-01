using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public static bool inCheck = false;
    public static BoardBuilder chessBoard;

    [SerializeField] private Material darkSquareMat;
    [SerializeField] private Material lightSquareMat;
    [SerializeField] private Vector3 squareDimensions;

    private void Start()
    {
        chessBoard = new BoardBuilder(8, 8, darkSquareMat, lightSquareMat, transform, squareDimensions);

        SpawnPieces();
    }

    private void SpawnPieces()
    {

    }
}
