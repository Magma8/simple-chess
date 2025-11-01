using UnityEngine;

public class BoardBuilder
{
    private int files;
    private int ranks;
    private int[,] filesAndRanks;
    Vector3 squareDimensions;
    private Material darkSquareMat;
    private Material lightSquareMat;

    public GameObject[,] squares;

    public BoardBuilder(int files, int ranks, Material darkSquareMat, Material lightSquareMat, Transform parent, Vector3 squareDimensions)
    {
        this.files = files;
        this.ranks = ranks;
        this.lightSquareMat = lightSquareMat;
        this.darkSquareMat = darkSquareMat;
        this.squareDimensions = squareDimensions;

        filesAndRanks = new int[files, ranks];
        squares = new GameObject[files, ranks];

        bool isSquareBlack = false;

        BuildBoard(parent, isSquareBlack);
    }

    private void BuildBoard(Transform parent, bool isSquareBlack)
    {
        for (int i = 0; i < filesAndRanks.GetLength(0); i++)
        {
            for (int j = 0; j < filesAndRanks.GetLength(1); j++)
            {
                float boardVerticalOffset = -0.25f;
                squares[i, j] = SpawnSquare(FindFileName(i) + (j + 1).ToString(), parent, new Vector3(i, boardVerticalOffset, j), isSquareBlack);
                isSquareBlack = !isSquareBlack;
            }
            isSquareBlack = !isSquareBlack;
        }
    }

    /// <summary>
    /// Returns a GameObject named squareName, as a child of parent, at localPostition,
    /// with color based on isSquareBlack
    /// </summary>
    /// <param name="squareName">Name of square as per standard chess notation</param>
    /// <param name="parent"></param>
    /// <param name="localPosition"></param>
    /// <param name="isSquareBlack"></param>
    /// <returns></returns>
    private GameObject SpawnSquare(string squareName, Transform parent, Vector3 localPosition, bool isSquareBlack)
    {
        GameObject newSquare = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newSquare.name = squareName;
        newSquare.transform.localScale = squareDimensions;
        newSquare.GetComponent<MeshRenderer>().material = isSquareBlack ? lightSquareMat : darkSquareMat;
        newSquare.transform.SetParent(parent, false);
        newSquare.transform.SetLocalPositionAndRotation(localPosition, Quaternion.identity);

        return newSquare;
    }

    /// <summary>
    /// Names the vertical line of squares (a.k.a. file) as per standard chess notation
    /// </summary>
    /// <param name="n">Number that specifies which file is being named</param>
    /// <returns></returns>
    private string FindFileName(int n)
    {
        string fileName = "";

        switch (n)
        {
            case 0:
                fileName = "a";
                break;
            case 1:
                fileName = "b";
                break;
            case 2:
                fileName = "c";
                break;
            case 3:
                fileName = "d";
                break;
            case 4:
                fileName = "e";
                break;
            case 5:
                fileName = "f";
                break;
            case 6:
                fileName = "g";
                break;
            case 7:
                fileName = "h";
                break;
        }

        return fileName;
    }
}