using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Абстрактний прототип
abstract class ChessThemePrototype
{
    public abstract ChessThemePrototype Clone();
}

// Конкретний прототип теми
class ChessTheme : ChessThemePrototype
{
    public string BoardColor { get; set; }
    public string PieceColor { get; set; }

    public ChessTheme(string boardColor, string pieceColor)
    {
        BoardColor = boardColor;
        PieceColor = pieceColor;
    }

    public override ChessThemePrototype Clone()
    {
        return (ChessThemePrototype)this.MemberwiseClone();
    }
}

// Використання
class Program
{
    static void Main(string[] args)
    {
        // Створення початкової теми
        ChessThemePrototype originalTheme = new ChessTheme("Dark", "Black");

        // Клонування початкової теми для створення нової теми
        ChessThemePrototype newTheme = originalTheme.Clone();
        ((ChessTheme)newTheme).BoardColor = "White";

        Console.WriteLine("Original Theme: Board Color - " + ((ChessTheme)originalTheme).BoardColor + ", Piece Color - " + ((ChessTheme)originalTheme).PieceColor);
        Console.WriteLine("New Theme: Board Color - " + ((ChessTheme)newTheme).BoardColor + ", Piece Color - " + ((ChessTheme)newTheme).PieceColor);
    }
}
