using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets {
    internal class Board : MonoBehaviour {
        private GameObject[,] board;
        private List<Move> moves;
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
        [SerializeField] private GameObject selectedCellPrefab;
        [SerializeField] private GameObject moveCellPrefab;

        private GameObject selectedCell;
        private Vector2Int selectedFigure;
        private List<GameObject> moveCells;
        private List<Vector2Int> correctMoves;
        private bool isSelected;
        private Team makesMove;

        private const int MINIMAX_DEPTH = 3;
        private bool isPlaying = false;
        private bool isFinished = false;
        private string winner;

        private bool isBotPlaying = false;

        private Board() {
            board = new GameObject[8, 8];
        }

        public void addWhitePawn(Vector2Int pos) {
            GameObject temp = Instantiate(whitePawnPrefab) as GameObject;
            temp.transform.position = Assets.BoardHandler.toWorldPos(pos.x, pos.y);
            Figure fig = temp.AddComponent<Figure>() as Figure;
            fig.VectorMoves = FigureMover.getWhitePawnVectorMoves();
            fig.AttackMoves = FigureMover.getWhitePawnAttackMoves();
            fig.team = Team.WHITE;
            fig.Type = TypeFigure.Pawn;
            board[pos.x, pos.y] = temp;
        }
        public void addWhiteRook(Vector2Int pos) {
            GameObject temp = Instantiate(whiteRookPrefab) as GameObject;
            temp.transform.position = Assets.BoardHandler.toWorldPos(pos.x, pos.y);
            Figure fig = temp.AddComponent<Figure>() as Figure;
            fig.VectorMoves = FigureMover.getRookVectorMoves();
            fig.Moves = null;
            fig.AttackMoves = null;
            fig.team = Team.WHITE;
            fig.Type = TypeFigure.Rook;
            board[pos.x, pos.y] = temp;
        }
        public void addWhiteKnight(Vector2Int pos) {
            GameObject temp = Instantiate(whiteKnightPrefab) as GameObject;
            temp.transform.position = Assets.BoardHandler.toWorldPos(pos.x, pos.y);
            Figure fig = temp.AddComponent<Figure>() as Figure;
            fig.Moves = FigureMover.getKnightMoves();
            fig.VectorMoves = null;
            fig.AttackMoves = null;
            fig.team = Team.WHITE;
            fig.Type = TypeFigure.Knight;
            board[pos.x, pos.y] = temp;
        }
        public void addWhiteBishop(Vector2Int pos) {
            GameObject temp = Instantiate(whiteBishopPrefab) as GameObject;
            temp.transform.position = Assets.BoardHandler.toWorldPos(pos.x, pos.y);
            Figure fig = temp.AddComponent<Figure>() as Figure;
            fig.VectorMoves = FigureMover.getBishopVectorMoves();
            fig.Moves = null;
            fig.AttackMoves = null;
            fig.team = Team.WHITE;
            fig.Type = TypeFigure.Bishop;
            board[pos.x, pos.y] = temp;
        }
        public void addWhiteQueen(Vector2Int pos) {
            GameObject temp = Instantiate(whiteQueenPrefab) as GameObject;
            temp.transform.position = Assets.BoardHandler.toWorldPos(pos.x, pos.y);
            Figure fig = temp.AddComponent<Figure>() as Figure;
            fig.VectorMoves = FigureMover.getQueenVectorMoves();
            fig.Moves = null;
            fig.AttackMoves = null;
            fig.team = Team.WHITE;
            fig.Type = TypeFigure.Queen;
            board[pos.x, pos.y] = temp;
        }
        public void addWhiteKing(Vector2Int pos) {
            GameObject temp = Instantiate(whiteKingPrefab) as GameObject;
            temp.transform.position = Assets.BoardHandler.toWorldPos(pos.x, pos.y);
            Figure fig = temp.AddComponent<Figure>() as Figure;
            fig.Moves = FigureMover.getKingMoves();
            fig.VectorMoves = null;
            fig.AttackMoves = null;
            fig.team = Team.WHITE;
            fig.Type = TypeFigure.King;
            board[pos.x, pos.y] = temp;
        }

        public void addBlackPawn(Vector2Int pos) {
            GameObject temp = Instantiate(blackPawnPrefab) as GameObject;
            temp.transform.position = Assets.BoardHandler.toWorldPos(pos.x, pos.y);
            Figure fig = temp.AddComponent<Figure>() as Figure;
            fig.VectorMoves = FigureMover.getBlackPawnVectorMoves();
            fig.AttackMoves = FigureMover.getBlackPawnAttackMoves();
            fig.Moves = null;

            fig.team = Team.BLACK;
            fig.Type = TypeFigure.Pawn;
            board[pos.x, pos.y] = temp;
        }
        public void addBlackRook(Vector2Int pos) {
            GameObject temp = Instantiate(blackRookPrefab) as GameObject;
            temp.transform.position = Assets.BoardHandler.toWorldPos(pos.x, pos.y);
            Figure fig = temp.AddComponent<Figure>() as Figure;
            fig.VectorMoves = FigureMover.getRookVectorMoves();
            fig.Moves = null;
            fig.AttackMoves = null;
            fig.team = Team.BLACK;
            fig.Type = TypeFigure.Rook;
            board[pos.x, pos.y] = temp;
        }
        public void addBlackKnight(Vector2Int pos) {
            GameObject temp = Instantiate(blackKnightPrefab) as GameObject;
            temp.transform.position = Assets.BoardHandler.toWorldPos(pos.x, pos.y);
            Figure fig = temp.AddComponent<Figure>() as Figure;
            fig.Moves = FigureMover.getKnightMoves();
            fig.VectorMoves = null;
            fig.AttackMoves = null;
            fig.team = Team.BLACK;
            fig.Type = TypeFigure.Knight;
            board[pos.x, pos.y] = temp;
        }
        public void addBlackBishop(Vector2Int pos) {
            GameObject temp = Instantiate(blackBishopPrefab) as GameObject;
            temp.transform.position = Assets.BoardHandler.toWorldPos(pos.x, pos.y);
            Figure fig = temp.AddComponent<Figure>() as Figure;
            fig.VectorMoves = FigureMover.getBishopVectorMoves();
            fig.Moves = null;
            fig.AttackMoves = null;
            fig.team = Team.BLACK;
            fig.Type = TypeFigure.Bishop;
            board[pos.x, pos.y] = temp;
        }
        public void addBlackQueen(Vector2Int pos) {
            GameObject temp = Instantiate(blackQueenPrefab) as GameObject;
            temp.transform.position = Assets.BoardHandler.toWorldPos(pos.x, pos.y);
            Figure fig = temp.AddComponent<Figure>() as Figure;
            fig.VectorMoves = FigureMover.getQueenVectorMoves();
            fig.Moves = null;
            fig.AttackMoves = null;
            fig.team = Team.BLACK;
            fig.Type = TypeFigure.Queen;
            board[pos.x, pos.y] = temp;
        }
        public void addBlackKing(Vector2Int pos) {
            GameObject temp = Instantiate(blackKingPrefab) as GameObject;
            temp.transform.position = Assets.BoardHandler.toWorldPos(pos.x, pos.y);
            Figure fig = temp.AddComponent<Figure>() as Figure;
            fig.Moves = FigureMover.getKingMoves();
            fig.VectorMoves = null;
            fig.AttackMoves = null;
            fig.team = Team.BLACK;
            fig.Type = TypeFigure.King;
            board[pos.x, pos.y] = temp;
        }

        public void moveFigure(Vector2Int oldPos, Vector2Int newPos) {
            if (newPos.x >= 0 && newPos.x < 8 && newPos.y >= 0 && newPos.y < 8 && board[oldPos.x, oldPos.y] != null) {
                Figure fig = board[oldPos.x, oldPos.y].GetComponent<Figure>();
                Move newMove = new Move(board[oldPos.x, oldPos.y], board[newPos.x, newPos.y], oldPos, newPos,!fig.WasMoved);
                moves.Add(newMove);

                fig.WasMoved = true;
                if (board[newPos.x, newPos.y] != null) {
                   /* Figure figNew = board[newPos.x, newPos.y].GetComponent<Figure>();
                    if (figNew.Type == TypeFigure.King) {
                        isPlaying = false;
                        isFinished = true;
                        if (figNew.team == Team.BLACK) {
                            winner = "White";
                        } else {
                            winner = "Black";
                        }
                    }*/
                    board[newPos.x, newPos.y].SetActive(false);
                }
                board[newPos.x, newPos.y] = board[oldPos.x, oldPos.y];
                board[oldPos.x, oldPos.y] = null;
                board[newPos.x, newPos.y].transform.position = BoardHandler.toWorldPos(newPos);
                changeTurn();
            }
        }
        public void undoMove() {
            Move[] m = moves.ToArray();
            if (m.Length != 0) {
                Move last = m[m.Length - 1];
                if (last.Beaten != null) {
                    last.Beaten.SetActive(true);
                }
                Figure fig = last.Moved.GetComponent<Figure>();
                fig.WasMoved = !last.IsFirstTimeMoved;
                board[last.EndPoint.x, last.EndPoint.y] = last.Beaten;
                board[last.OldPoint.x, last.OldPoint.y] = last.Moved;

                last.Moved.transform.position = BoardHandler.toWorldPos(last.OldPoint);
                moves.Remove(last);
                changeTurn();
            }
        }
        public void checkWon() {
            Move[] m = moves.ToArray();
            if (m.Length > 0) {
                if (m[m.Length - 1].Beaten != null) {
                    Figure f = m[m.Length - 1].Beaten.GetComponent<Figure>();
                    if (f.Type == TypeFigure.King) {
                        if (f.team == Team.BLACK) {
                            winner = "White";
                        } else {
                            winner = "Black";
                        }
                        isFinished = true;
                        isPlaying = false;
                    }
                }
            }
        }

        public void placeCell(GameObject cell, Vector2Int pos) {
            cell.transform.position = BoardHandler.toWorldPos(pos);
            Vector3 wpos = cell.transform.position;
            wpos.y -= 1.15f;
            wpos.z -= 1.85f;
            wpos.x -= 0.45f;
            cell.transform.position = wpos;
        }
        
        public List<Vector2Int> determineMoves(Vector2Int movingPos) {
            List<Vector2Int> correctMoves = new List<Vector2Int>();
            GameObject moving = board[movingPos.x, movingPos.y];
            Figure figMoving = moving.GetComponent<Figure>();
            Vector2Int[] moves = figMoving.Moves;
            if (moves != null) {

                for (int i = 0; i < moves.Length; i++) {
                    if ((moves[i] + movingPos).x < 0 || (moves[i] + movingPos).x > 7 || (moves[i] + movingPos).y < 0 || (moves[i] + movingPos).y > 7) {
                        continue;
                    }
                    if (board[(moves[i] + movingPos).x, (moves[i] + movingPos).y] != null) {
                        Figure figtemp = board[(moves[i] + movingPos).x, (moves[i] + movingPos).y].GetComponent<Figure>();
                        if (figtemp.team == figMoving.team) {
                            continue;
                        }
                    }
                    correctMoves.Add(moves[i] + movingPos);
                }


            }



            if (figMoving.VectorMoves != null) {
                Vector2Int[] vMoves = figMoving.VectorMoves;
                for (int i = 0; i < vMoves.Length; i++) {
                    Vector2Int step = vMoves[i];
                    if (step.x != 0) {
                        step.x /= Math.Abs(step.x);
                    }
                    if (step.y != 0) {
                        step.y /= Math.Abs(step.y);
                    }
                    int num = 1;
                    while (step * num != vMoves[i]) {
                        if ((movingPos + step * num).x < 0 || (movingPos + step * num).x > 7 ||
                            (movingPos + step * num).y < 0 || (movingPos + step * num).y > 7) {
                            break;
                        }
                        if (board[(movingPos + step * num).x, (movingPos + step * num).y] != null) {
                            Figure figtemp = board[(movingPos + step * num).x, (movingPos + step * num).y].GetComponent<Figure>();
                            if (figtemp.team == figMoving.team || figMoving.Type == TypeFigure.Pawn) {
                                break;
                            }
                            correctMoves.Add((movingPos + step * num));
                            break;
                        }
                        correctMoves.Add((movingPos + step * num));
                        num++;
                    }
                }
            }
            if (!figMoving.WasMoved && figMoving.Type == TypeFigure.Pawn) {
                Vector2Int additional = new Vector2Int(0, 2);
                if (figMoving.team == Team.BLACK) {
                    additional *= -1;
                }
                additional += movingPos;
                if (board[additional.x, additional.y] == null) {
                    correctMoves.Add(additional);
                }
            }

            if (figMoving.AttackMoves != null) {
                Vector2Int[] attackMoves = figMoving.AttackMoves;

                for (int i = 0; i < attackMoves.Length; i++) {
                    if ((attackMoves[i] + movingPos).x < 0 || (attackMoves[i] + movingPos).x > 7 || (attackMoves[i] + movingPos).y < 0 || (attackMoves[i] + movingPos).y > 7) {
                        continue;
                    }
                    if (board[(attackMoves[i] + movingPos).x, (attackMoves[i] + movingPos).y] != null) {
                        Figure figtemp = board[(attackMoves[i] + movingPos).x, (attackMoves[i] + movingPos).y].GetComponent<Figure>();
                        if (figtemp.team != figMoving.team) {
                            correctMoves.Add(attackMoves[i] + movingPos);
                        }
                    }

                }
            }
            return correctMoves;
        }
        public void changeTurn() {
            if (makesMove == Team.WHITE) {
                makesMove = Team.BLACK;
                Camera.main.transform.position = new Vector3(0, 4.9f, 6.4f);
                Vector3 rotation = Camera.main.transform.rotation.eulerAngles;
                rotation.x = 135;
                rotation.y = 0;
                rotation.z = 180;
                Camera.main.transform.rotation = Quaternion.Euler(rotation);
            } else {
                Camera.main.transform.position = new Vector3(0, 4.9f, -6.4f);
                Vector3 rotation = Camera.main.transform.rotation.eulerAngles;
                rotation.x = 45;
                rotation.y = 0;
                rotation.z = 0;
                Camera.main.transform.rotation = Quaternion.Euler(rotation);
                makesMove = Team.WHITE;
            }
        }

        public int evaluateBoard() {
            int res = 0;
            foreach(GameObject cell in board) {
                if (cell == null) {
                    continue;
                }
                Figure f = cell.GetComponent<Figure>();               
                if(f.team == Team.BLACK) {
                    res -= Convert.ToInt32(f.Type);
                } else {
                    res += Convert.ToInt32(f.Type);
                }
                
            }
            return res;
        }
        public List<Move> allMoves() {
            List<Move> all = new List<Move>();
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (board[i,j] != null) {
                        Figure f = board[i, j].GetComponent<Figure>();
                        if (f.team == makesMove) {
                            Vector2Int gamePos = new Vector2Int(i,j);
                            List<Vector2Int> figMoves = determineMoves(gamePos);
                            foreach (Vector2Int move in figMoves) {
                                Figure fig = board[i, j].GetComponent<Figure>();
                                all.Add(new Move(board[i, j], null, gamePos, move,!fig.WasMoved));
                            }
                        }
                    }
                }

            }
            return all;
        }
        public int minimax(int depth,bool isMaximizing) {
            if (depth == 0) {
                return -evaluateBoard();
            }
            if (isMaximizing) {
                List<Move> all = allMoves();
                Move[] m = all.ToArray();
                int max = int.MinValue;
                for (int i = 0; i < m.Length; i++) {
                    moveFigure(m[i].OldPoint, m[i].EndPoint);
                    max = Math.Max(max, minimax(depth-1, !isMaximizing));
                    undoMove();
                }
                return max;
            } else {
                List<Move> all = allMoves();
                Move[] m = all.ToArray();
                int min = int.MaxValue;
                for (int i = 0; i < m.Length; i++) {
                    moveFigure(m[i].OldPoint, m[i].EndPoint);
                    min = Math.Max(min, minimax(depth - 1, !isMaximizing));
                    undoMove();
                }
                return min;
            }
        }
        public Move determineBestBotMove() {
            List<Move> all = allMoves();
            Move[] m = all.ToArray();
            //System.Random r = new System.Random();
            //return m[r.Next(m.Length)];         /** Random move**/
            int maxi = 0;
            int max = int.MinValue;
            
            for(int i = 0; i < m.Length; i++) {
                moveFigure(m[i].OldPoint, m[i].EndPoint);
                int eval = minimax(MINIMAX_DEPTH-1,true);
                if (eval > max) {
                    max = eval;
                    maxi = i;
                }
                undoMove();
            }
            return m[maxi];

        }

        public void OnGUI() {
            if (!isPlaying && !isFinished) {
                if (GUI.Button(new Rect(110, 110, 100, 40), "Play 1 vs 1")) {
                    startGame();
                }
                if (GUI.Button(new Rect(220, 110, 100, 40), "Play with Bot")) {
                    startBotGame();
                }
                if (GUI.Button(new Rect(330, 110, 100, 40), "Exit")) {
                    Application.Quit();
                }
            }

            if (isFinished) {
                GUI.Box(new Rect(10, 10, 300, 300), winner + " is the winner!");
                if (GUI.Button(new Rect(50, 50, 100, 40), "Ok")) {
                    isFinished = false;
                    isPlaying = false;
                    finishGame();
                }
            }
        }

        private void startGame() {
            moves = new List<Move>();
            isPlaying = true;
            isBotPlaying = false;
            makesMove = Team.WHITE;
            Camera.main.transform.position = new Vector3(0, 4.9f, -6.4f);
            Vector3 rotation = Camera.main.transform.rotation.eulerAngles;
            rotation.x = 45;
            rotation.y = 0;
            rotation.z = 0;
            Camera.main.transform.rotation = Quaternion.Euler(rotation);
            selectedCell = Instantiate(selectedCellPrefab) as GameObject;
            selectedCell.SetActive(false);

            addWhiteRook(new Vector2Int(0, 0));
            addWhiteRook(new Vector2Int(7, 0));
            addWhiteKnight(new Vector2Int(1, 0));
            addWhiteKnight(new Vector2Int(6, 0));
            addWhiteBishop(new Vector2Int(2, 0));
            addWhiteBishop(new Vector2Int(5, 0));
            addWhiteQueen(new Vector2Int(3, 0));
            addWhiteKing(new Vector2Int(4, 0));
            for (int i = 0; i < 8; i++) {
                addWhitePawn(new Vector2Int(i, 1));
            }

            addBlackRook(new Vector2Int(0, 7));
            addBlackRook(new Vector2Int(7, 7));
            addBlackKnight(new Vector2Int(1, 7));
            addBlackKnight(new Vector2Int(6, 7));
            addBlackBishop(new Vector2Int(2, 7));
            addBlackBishop(new Vector2Int(5, 7));
            addBlackQueen(new Vector2Int(3, 7));
            addBlackKing(new Vector2Int(4, 7));
            for (int i = 0; i < 8; i++) {
                addBlackPawn(new Vector2Int(i, 6));
            }
            isSelected = false;
        }
        private void startBotGame() {
            moves = new List<Move>();
            isPlaying = true;
            isBotPlaying = true;
            makesMove = Team.WHITE;
            Camera.main.transform.position = new Vector3(0, 4.9f, -6.4f);
            Vector3 rotation = Camera.main.transform.rotation.eulerAngles;
            rotation.x = 45;
            rotation.y = 0;
            rotation.z = 0;
            Camera.main.transform.rotation = Quaternion.Euler(rotation);
            selectedCell = Instantiate(selectedCellPrefab) as GameObject;
            selectedCell.SetActive(false);

            addWhiteRook(new Vector2Int(0, 0));
            addWhiteRook(new Vector2Int(7, 0));
            addWhiteKnight(new Vector2Int(1, 0));
            addWhiteKnight(new Vector2Int(6, 0));
            addWhiteBishop(new Vector2Int(2, 0));
            addWhiteBishop(new Vector2Int(5, 0));
            addWhiteQueen(new Vector2Int(3, 0));
            addWhiteKing(new Vector2Int(4, 0));
            for (int i = 0; i < 8; i++) {
                addWhitePawn(new Vector2Int(i, 1));
            }

            addBlackRook(new Vector2Int(0, 7));
            addBlackRook(new Vector2Int(7, 7));
            addBlackKnight(new Vector2Int(1, 7));
            addBlackKnight(new Vector2Int(6, 7));
            addBlackBishop(new Vector2Int(2, 7));
            addBlackBishop(new Vector2Int(5, 7));
            addBlackQueen(new Vector2Int(3, 7));
            addBlackKing(new Vector2Int(4, 7));
            for (int i = 0; i < 8; i++) {
                addBlackPawn(new Vector2Int(i, 6));
            }
            isSelected = false;
        }
        private void finishGame() {
            moves.Clear();
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (board[i, j] != null) {
                        Destroy(board[i, j]);
                        board[i, j] = null;
                    }
                }
            }
            Destroy(selectedCell);
            selectedCell = null;
            foreach (GameObject cell in moveCells) {
                Destroy(cell);
            }
            moveCells.Clear();
        }

        public void Start() {/*
            selectedCell = Instantiate(selectedCellPrefab) as GameObject;
            selectedCell.SetActive(false);

            addWhiteRook(new Vector2Int(0, 0));
            addWhiteRook(new Vector2Int(7, 0));
            addWhiteKnight(new Vector2Int(1, 0));
            addWhiteKnight(new Vector2Int(6, 0));
            addWhiteBishop(new Vector2Int(2, 0));
            addWhiteBishop(new Vector2Int(5, 0));
            addWhiteQueen(new Vector2Int(3, 0));
            addWhiteKing(new Vector2Int(4, 0));
            for(int i = 0; i < 8; i++) {
                addWhitePawn(new Vector2Int(i,1));
            }

            addBlackRook(new Vector2Int(0, 7));
            addBlackRook(new Vector2Int(7, 7));
            addBlackKnight(new Vector2Int(1, 7));
            addBlackKnight(new Vector2Int(6, 7));
            addBlackBishop(new Vector2Int(2, 7));
            addBlackBishop(new Vector2Int(5, 7));
            addBlackQueen(new Vector2Int(3, 7));
            addBlackKing(new Vector2Int(4, 7));
            for (int i = 0; i < 8; i++) {
                addBlackPawn(new Vector2Int(i, 6));
            }
            isSelected = false;*/
        }

        private void handleUserUpdate() {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Vector3 point = hit.point;
                Vector2Int cell = BoardHandler.toGamePos(point);
                selectedCell.SetActive(true);
                placeCell(selectedCell, cell);
                selectedCell.transform.position = selectedCell.transform.position + new Vector3(0, 0.1f, 0);
                if (Input.GetMouseButtonDown(0) && !isSelected) {
                    if (board[cell.x, cell.y] != null) {
                        Figure fig = board[cell.x, cell.y].GetComponent<Figure>();
                        if (fig.team == makesMove) {
                            isSelected = true;
                            selectedFigure = cell;
                            correctMoves = determineMoves(cell);
                            if (correctMoves.Count != 0) {
                                moveCells = new List<GameObject>();
                                foreach (Vector2Int move in correctMoves) {
                                    GameObject tempMoveCell = Instantiate<GameObject>(moveCellPrefab);
                                    placeCell(tempMoveCell, move);
                                    moveCells.Add(tempMoveCell);
                                }
                            } else {
                                isSelected = false;
                            }
                        }
                    }
                } else {
                    if (Input.GetMouseButtonDown(0) && isSelected) {
                        foreach (Vector2Int move in correctMoves) {
                            if (cell.Equals(move)) {
                                isSelected = false;
                                foreach (GameObject moveCell in moveCells) {
                                    Destroy(moveCell);
                                }
                                moveCells.Clear();
                                moveFigure(selectedFigure, cell);
                            }
                        }
                    }
                }

            } else {
                selectedCell.SetActive(false);
            }
            if (isSelected && Input.GetMouseButtonDown(1)) {
                foreach (GameObject moveCell in moveCells) {
                    Destroy(moveCell);
                }
                isSelected = false;
                moveCells.Clear();
            }
        }

        public void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                isPlaying = false;
                finishGame();
            }


            if (isPlaying && !isBotPlaying) {
                handleUserUpdate();
                checkWon();
                if (Input.GetKeyDown(KeyCode.Backspace) && !isSelected && !isBotPlaying) {
                    undoMove();
                }
            }
            if(isPlaying && isBotPlaying) {
                if(makesMove == Team.WHITE) {
                    handleUserUpdate();
                    Camera.main.transform.position = new Vector3(0, 4.9f, -6.4f);
                    Vector3 rotation = Camera.main.transform.rotation.eulerAngles;
                    rotation.x = 45;
                    rotation.y = 0;
                    rotation.z = 0;
                    Camera.main.transform.rotation = Quaternion.Euler(rotation);
                } else {
                    Move m = determineBestBotMove();
                    moveFigure(m.OldPoint,m.EndPoint);
                    //changeTurn();
                }
                checkWon();
            }
        }
    }
} 

