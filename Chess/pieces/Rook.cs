﻿using System.Collections.Generic;
using System.Windows;

namespace Chess
{
    public class Rook : Piece
    {
        public Rook(ChessBoard setChessBoard, Game setGame, PieceColor setColor) : base(setChessBoard, setGame, setColor)
        {
            chessBoard = setChessBoard;
            game = setGame;
            color = setColor;
            type = PieceType.ROOK;
            symbol = (color == PieceColor.WHITE) ? 'W' : 'w';
            firstMove = true;
        }
        public override void GeneratePossibleMoves(int pieceRow, int pieceColumn, List<Point> possibleMoves, bool checkForChecks)
        {
            int newPieceRow = pieceRow;
            int newPieceColumn = pieceColumn;
            for (int i = pieceColumn + 1; i < chessBoard.size; i++)
            {
                newPieceColumn += 1;
                if (chessBoard.CanPieceMoveHere(pieceRow, newPieceColumn, color, checkForChecks, pieceRow, pieceColumn))
                    possibleMoves.Add(new Point(pieceRow, newPieceColumn));
                if (!chessBoard.IsFieldEmpty(pieceRow, newPieceColumn))
                    break;
            }
            newPieceColumn = pieceColumn;
            for (int i = pieceColumn - 1; i >= chessBoard.minimumIndex; i--)
            {
                newPieceColumn -= 1;
                if (chessBoard.CanPieceMoveHere(pieceRow, newPieceColumn, color, checkForChecks, pieceRow, pieceColumn))
                    possibleMoves.Add(new Point(pieceRow, newPieceColumn));
                if (!chessBoard.IsFieldEmpty(pieceRow, newPieceColumn))
                    break;
            }
            for (int i = pieceRow + 1; i < chessBoard.size; i++)
            {
                newPieceRow += 1;
                if (chessBoard.CanPieceMoveHere(newPieceRow, pieceColumn, color, checkForChecks, pieceRow, pieceColumn))
                    possibleMoves.Add(new Point(newPieceRow, pieceColumn));
                if (!chessBoard.IsFieldEmpty(newPieceRow, pieceColumn))
                    break;
            }
            newPieceRow = pieceRow;
            for (int i = pieceRow - 1; i >= chessBoard.minimumIndex; i--)
            {
                newPieceRow -= 1;
                if (chessBoard.CanPieceMoveHere(newPieceRow, pieceColumn, color, checkForChecks, pieceRow, pieceColumn))
                    possibleMoves.Add(new Point(newPieceRow, pieceColumn));
                if (!chessBoard.IsFieldEmpty(newPieceRow, pieceColumn))
                    break;
            }
        }
    }
}