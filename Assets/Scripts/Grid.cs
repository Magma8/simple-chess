using UnityEngine;

public class Grid
{
    private int ranks;
    private int files;
    private int[,] filesAndRanks;
    private Material darkSquareMat;
    private Material lightSquareMat;

    public GameObject[,] squares;

    public Grid(int ranks, int files, Material darkSquareMat, Material lightSquareMat, Transform parent)
    {
        this.ranks = ranks;
        this.files = files;
        this.lightSquareMat = lightSquareMat;
        this.darkSquareMat = darkSquareMat;
        filesAndRanks = new int[files, ranks];
        squares = new GameObject[files, ranks];

        bool squareColor = false;

        for (int i = 0; i < filesAndRanks.GetLength(0); i++)
        {
            for (int j = 0; j < filesAndRanks.GetLength(1); j++)
            {
                squares[i, j] = SpawnSquare(FindFileName(i) + (j + 1).ToString(), parent, new Vector3(i, 0, j), squareColor);
                squareColor = !squareColor;
            }
            squareColor = !squareColor;
        }
    }

    private GameObject SpawnSquare(string squareName, Transform parent, Vector3 localPosition, bool squareColor)
    {
        GameObject newSquare = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newSquare.name = squareName;
        newSquare.transform.localScale = new Vector3(1f, 0.25f, 1f);
        newSquare.GetComponent<MeshRenderer>().material = squareColor ? lightSquareMat : darkSquareMat;
        newSquare.transform.SetParent(parent, false);
        newSquare.transform.SetLocalPositionAndRotation(localPosition, Quaternion.identity);

        return newSquare;
    }

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