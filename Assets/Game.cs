using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class Game : MonoBehaviour{

    [SerializeField] private GameObject whitePawnPrefab;
    [SerializeField] private GameObject whiteRookPrefab;
    [SerializeField] private GameObject whiteKnightPrefab;
    [SerializeField] private GameObject whiteBishopPrefab;
    [SerializeField] private GameObject whiteQueenPrefab;
    [SerializeField] private GameObject whiteKingPrefab;
    [SerializeField] private GameObject blackPawnPrefab;
    [SerializeField] private GameObject blackRookPrefab;
    [SerializeField] private GameObject blackKnightPrefab;
    [SerializeField] private GameObject blackBishopPrefab;
    [SerializeField] private GameObject blackQueenPrefab;
    [SerializeField] private GameObject blackKingPrefab;

    private ArrayList whitePawn;
    private ArrayList whiteRook;
    private ArrayList whiteKnight;
    private ArrayList whiteBishop;
    private ArrayList whiteQueen;
    private ArrayList whiteKing;

    private ArrayList blackPawn;
    private ArrayList blackRook;
    private ArrayList blackKnight;
    private ArrayList blackBishop;
    private ArrayList blackQueen;
    private ArrayList blackKing;


    // Start is called before the first frame update
    void Start(){
        GameObject temp;

        whitePawn = new ArrayList();
        whiteRook = new ArrayList();
        whiteKnight = new ArrayList();
        whiteBishop = new ArrayList();
        whiteQueen = new ArrayList();
        whiteKing = new ArrayList();

        blackPawn = new ArrayList();
        blackRook = new ArrayList();
        blackKnight = new ArrayList();
        blackBishop = new ArrayList();
        blackQueen = new ArrayList();
        blackKing = new ArrayList();

        temp = Instantiate(whiteRookPrefab) as GameObject;
        temp.transform.position = Assets.BoardHandler.toWorldPos(0, 0);
        whiteRook.Add(temp);
        temp = Instantiate(whiteRookPrefab) as GameObject;
        temp.transform.position = Assets.BoardHandler.toWorldPos(7, 0);
        whiteRook.Add(temp);

        temp = Instantiate(whiteKnightPrefab) as GameObject;
        temp.transform.position = Assets.BoardHandler.toWorldPos(1, 0);
        whiteKnight.Add(temp);
        temp = Instantiate(whiteKnightPrefab) as GameObject;
        temp.transform.position = Assets.BoardHandler.toWorldPos(6, 0);
        whiteKnight.Add(temp);

        temp = Instantiate(whiteBishopPrefab) as GameObject;
        temp.transform.position = Assets.BoardHandler.toWorldPos(2, 0);
        whiteBishop.Add(temp);
        temp = Instantiate(whiteBishopPrefab) as GameObject;
        temp.transform.position = Assets.BoardHandler.toWorldPos(5, 0);
        whiteBishop.Add(temp);

        temp = Instantiate(whiteQueenPrefab) as GameObject;
        temp.transform.position = Assets.BoardHandler.toWorldPos(3, 0);
        whiteQueen.Add(temp);

        temp = Instantiate(whiteKingPrefab) as GameObject;
        temp.transform.position = Assets.BoardHandler.toWorldPos(4, 0);
        whiteKing.Add(temp);

        for(int i = 0; i < 8; i++) {
            temp = Instantiate(whitePawnPrefab) as GameObject;
            temp.transform.position = Assets.BoardHandler.toWorldPos(i, 1);
            whitePawn.Add(temp);
        }

        temp = Instantiate(blackRookPrefab) as GameObject;
        temp.transform.position = Assets.BoardHandler.toWorldPos(0, 7);
        blackRook.Add(temp);
        temp = Instantiate(blackRookPrefab) as GameObject;
        temp.transform.position = Assets.BoardHandler.toWorldPos(7, 7);
        blackRook.Add(temp);

        temp = Instantiate(blackKnightPrefab) as GameObject;
        temp.transform.position = Assets.BoardHandler.toWorldPos(1, 7);
        blackKnight.Add(temp);
        temp = Instantiate(blackKnightPrefab) as GameObject;
        temp.transform.position = Assets.BoardHandler.toWorldPos(6, 7);
        blackKnight.Add(temp);

        temp = Instantiate(blackBishopPrefab) as GameObject;
        temp.transform.position = Assets.BoardHandler.toWorldPos(2, 7);
        blackBishop.Add(temp);
        temp = Instantiate(blackBishopPrefab) as GameObject;
        temp.transform.position = Assets.BoardHandler.toWorldPos(5, 7);
        blackBishop.Add(temp);

        temp = Instantiate(blackQueenPrefab) as GameObject;
        temp.transform.position = Assets.BoardHandler.toWorldPos(4, 7);
        blackQueen.Add(temp);

        temp = Instantiate(blackKingPrefab) as GameObject;
        temp.transform.position = Assets.BoardHandler.toWorldPos(3, 7);
        blackKing.Add(temp);

        for (int i = 0; i < 8; i++) {
            temp = Instantiate(blackPawnPrefab) as GameObject;
            temp.transform.position = Assets.BoardHandler.toWorldPos(i, 6);
            blackPawn.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
