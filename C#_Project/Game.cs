class Game
{
    char[,] gameBoard; // 2D array to represent the game board
    char currentPlayer; // variable to keep track of the current player
    bool gameOver; // variable to indicate if the game is over

    public void startGame()
    {
        gameBoard = new char[6, 7]; // initialize the game board with empty spaces
        currentPlayer = '1'; // set the first player as player 1
        gameOver = false; // set the game over flag to false
        Boolean displayBoardFirst = true;
        while (!gameOver)
        {
            if (displayBoardFirst == true)
            {
                displayBoard();
                displayBoardFirst = false;
            }
            getUserMove();
            displayBoard();
            if (checkWin() || checkTie()) // Call CheckWin() and CheckTie() methods and update gameOver flag
            {
                gameOver = true;
            }
            else
            {
                switchPlayer(); // Switch player's turn only if no win or tie condition is met
            }
        }

        displayResult();
        Console.WriteLine("\nDo you want to restart the game? Press Y");
        String restartGame = Console.ReadLine();
        if (restartGame.ToUpper() == "Y")
        {
            startGame();
        }
        else
        {
            Console.WriteLine("\n Game is Finished :) ");
        }
    }

    void displayBoard()
    {
        Console.WriteLine("\n Connect Four Game");
        Console.WriteLine(" 1 2 3 4 5 6 7"); // display column numbers
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                if (gameBoard[row, col] == '\0')
                {
                    Console.Write(". ");
                }
                else
                {
                    Console.Write(gameBoard[row, col] + " ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    void getUserMove()
    {
        Boolean isUserMove = true;
        Console.Write($"Player {currentPlayer}, enter a column number (1-7): ");
        int col;
        while (isUserMove)
        {
            if (int.TryParse(Console.ReadLine(), out col) && col >= 1 && col <= 7)
            {
                col--; // subtract 1 to convert from 1-based index to 0-based index
                if (gameBoard[0, col] == '\0') // check if the selected column is not full
                {
                    for (int row = 5; row >= 0; row--)
                    {
                        if (gameBoard[row, col] == '\0')
                        {
                            gameBoard[row, col] = currentPlayer;
                            break;
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Selected column is full. Please select a different column.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid column number (1-7): ");
            }
        }
    }

    void switchPlayer()
    {
        if (currentPlayer == '1')
        {
            currentPlayer = '2';
        }
        else
        {
            currentPlayer = '1';
        }
    }

    bool checkWin()
    {
        // Check for four tokens in a row horizontally
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                if (gameBoard[row, col] == currentPlayer &&
                    gameBoard[row, col + 1] == currentPlayer &&
                    gameBoard[row, col + 2] == currentPlayer &&
                    gameBoard[row, col + 3] == currentPlayer)
                {
                    gameOver = true;
                    return true;
                }
            }
        }

        // Check for four tokens in a column vertically
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                if (gameBoard[row, col] == currentPlayer &&
                    gameBoard[row + 1, col] == currentPlayer &&
                    gameBoard[row + 2, col] == currentPlayer &&
                    gameBoard[row + 3, col] == currentPlayer)
                {
                    gameOver = true;
                    return true;
                }
            }
        }

        return false; // return false if no win condition is met
    }

    bool checkTie()
    {
        // Check if all the slots on the game board are filled (no empty spaces)
        bool tie = true;
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                if (gameBoard[row, col] == '\0')
                {
                    tie = false;
                    break;
                }
            }
            if (!tie)
            {
                break;
            }
        }

        if (tie)
        {
            gameOver = true;
            return true;
        }

        return false;
    }

    void displayResult()
    {
        if (gameOver)
        {
            Console.WriteLine("Game over!");
            if (checkWin()) // Remove this line
            {
                Console.WriteLine($"Player {currentPlayer} wins!");
            }
            else
            {
                Console.WriteLine("It's a tie! \n\n");
            }
        }
    }

}   