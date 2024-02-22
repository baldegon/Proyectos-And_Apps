#include <iostream>

using namespace std;

bool checkWinner(char board[3][3], char player){
    //chequea filas y columnas, y diagonales
    for (int i = 0; i < 3; i++){
        if(board[i][0] == player && board[i][1] == player
            && board[i][2] == player){
            return true;
        }
        if(board[0][i] == player && board[1][i] == player
            && board[2][i] == player){
            return true;
        }
    }
    if(board[0][0] == player && board[1][1] == player
        && board[2][2] == player)
        return true;
    if(board[0][2] == player && board[1][1] == player
        && board[2][0] == player)
        return true;
    return false;
}

void printBoard(char board[3][3]){
    for (int i = 0; i < 3; i++)
    {
        cout<<"\t\t";
        cout << " | ";
        for (int j = 0; j < 3; j++)
        {
            cout << board[i][j] << " | ";
        }
        cout << "\n\t\t--------------- \n";
    }
}

int main(){ 
    char board[3][3] = {{' ',' ',' '},
                        {' ',' ',' '},
                        {' ', ' ',' '}};

    char player = 'X';
    int row, col;
    int turns;

    cout << "\t------Bienvenido al TaTeTi!-----\t\n" << endl;

    cout << "\tpor cada x Y o que se escriba\n\tse reemplaza un lugar \n" << endl;
    cout << "\teste es el tablero vacio."<<endl;
    cout << "\t-----COMIENZA EL JUEGO-----\n" << endl;

    for (turns = 0; turns < 9; turns++){
        printBoard(board);
        while(true){
            cout << "\tEl jugador " << player
                << ", Ingrese una fila (0-2) y una columna(0-2) \n";
            cin >> row >> col;
            cout << "\tFila " << row << " \tColumna " << col << "\n" << endl;

            if(board[row][col] != ' ' || row < 0 || row > 2
                || col < 0 || col > 2){
                    cout << "\tMovimiendo invalido -.-'', ingrese nuevamente. \n\n";
            }else{
                break;
            }
        }

        board[row][col] = player;

        if(checkWinner(board, player)){
            printBoard(board);
            cout << "\tFelicitaciones! El jugador -> " << player << " <- Gano! \n\n";
            cout << "\tGracias por Jugar! \n" << " \tBy Baldegon Dev @baldegon en github " << endl;
            break;
        }

        player = (player == 'X' ? 'O' : 'X');
    }
    system("pause");   
    
    return 0;
}
