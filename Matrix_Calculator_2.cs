using System;
using static System.Console;
using System.Collections.Generic;
using static System.Math;

namespace Bme121
{
   
    static class Program
    {
        static void Main( )
        {
            double[,] matrix1 = Initialization(); 
            int width1 = matrix1.GetLength(1);
            int height1 = matrix1.GetLength(0);
            bool trueChoice = true;

            FillMatrix( matrix1 );
            WriteLine( "Does you calculation require a second array?" );
            WriteLine( "0 = yes" );
            WriteLine( "1 = no" );
            int choice = int.Parse(ReadLine( ) );
            while( trueChoice == true )
            {
                if( choice == 1 )
                {
                    Calculation1(matrix1 );
                    trueChoice = false;
                }
                else if( choice == 0 )
                {
                    double[,] matrix2 = Initialization();
                    int width2 = matrix2.GetLength(1);
                    int height2 = matrix2.GetLength(0);
                    FillMatrix( matrix2 );
                    Calculation2( matrix1, matrix2 );
                    trueChoice = false;
                }
                else
                {
                    Console.Clear();
                    WriteMatrix( matrix1 );
                    WriteLine( "Entered integer was not a possible option" );
                    WriteLine( "Does you calculation require a second array?" );
                    WriteLine( "0 = yes" );
                    WriteLine( "1 = no" );
                    choice = int.Parse(ReadLine( ) );
                }
            }
        }
        
        static double[,] Initialization( )
        {
            WriteLine("Please enter the width of your array: ");
            int width = int.Parse( ReadLine( ) );
            WriteLine("Please enter the height of your array: ");
            int height = int.Parse( ReadLine( ) );
            
            double[,] matrix = new double[height, width];
            
            for(int i = 0; i< matrix.GetLength(0); i ++)
            {
                for(int j = 0; j< matrix.GetLength(1); j ++)
                {
                    matrix[i,j] = int.MaxValue;
                }
            }
            
            return matrix;
        }
        
        static double[,] FillMatrix( double[,] matrix )
        {
            for(int i = 0; i< matrix.GetLength(0); i ++)
            {
                for(int j = 0; j< matrix.GetLength(1); j ++)
                {
                    WriteLine( "Enter the value of your matrix at[{0},{1}]", j+1, i+1 );
                    matrix[i,j] = double.Parse(ReadLine( ) );
                    Console.Clear();
                    WriteMatrix( matrix );
                }
            }
            
            return matrix;
        }
        
        static void WriteMatrix( double[,] matrix )
        {
            const string h  = "\u2500"; // horizontal line
            const string v  = "\u2502"; // vertical line
            const string tl = "\u250c"; // top left corner
            const string tr = "\u2510"; // top right corner
            const string bl = "\u2514"; // bottom left corner
            const string br = "\u2518"; // bottom right corner
            const string vr = "\u251c"; // vertical join from right
            const string vl = "\u2524"; // vertical join from left
            const string hb = "\u252c"; // horizontal join from below
            const string ha = "\u2534"; // horizontal join from above
            const string hv = "\u253c"; // horizontal vertical cross
            //const string sp = " ";      // space
            
            string[ ] letters = { "a","b","c","d","e","f","g","h","i","j","k","l",
                "m","n","o","p","q","r","s","t","u","v","w","x","y","z"}; // letters to numbers string
            
            int maxLength = 0;
            int boxLength = 0;
            int tempLength = 0;
            int spacing = 0;
            int spacesFromFront = 0;
            int spacesFromRear = 0;
            string tempNumber = null;
            
            for( int i = 0; i < matrix.GetLength(0); i ++ )
            {
                for( int j = 0; j < matrix.GetLength(1); j ++ )
                {
                    if( matrix[i,j] != int.MaxValue )
                    {
                        tempLength = 0;
                        double tempDouble = ( ( Math.Round ( matrix[i,j] * 100 ) ) / 100 );
                        string number =  tempDouble.ToString( );
                        foreach( char c in number )
                        {
                            tempLength ++;
                        }
                        if( tempLength > maxLength )
                        {
                            maxLength = tempLength;
                            boxLength = maxLength + 2;
                        }
                    }
                }
            }
            
            // Draw the top board boundary.
            for( int c = 0; c < matrix.GetLength(1); c ++ )
            {
                if( c == 0 ) Write( tl );
                for( int i = 0; i< boxLength; i ++ )
                {
                    Write( h );
                }
                if( c == matrix.GetLength(1) - 1 ) Write( "{0}", tr ); 
                else                                Write( "{0}", hb );
            }
            WriteLine( );
            
            // Draw the board rows.
            for( int r = 0; r < matrix.GetLength( 0 ); r ++ )
            {
                // Draw the row contents.
                for( int c = 0; c < matrix.GetLength(1); c ++ )
                {
                    tempLength = 0;
                    spacing = 0;
                    spacesFromFront = 0;
                    spacesFromRear = 0;
                    tempNumber = null;
                    
                    matrix[r,c] = ( ( Math.Round ( matrix[r,c] * 100 ) ) / 100 );
                    tempNumber = matrix[r,c].ToString( );
                    foreach( char p in tempNumber )
                    {
                        tempLength ++;
                    }
                    spacing = ( boxLength - tempLength );
                    
                    if( c == 0 ) Write( v );
                    if( matrix[r,c] == int.MaxValue )
                    {
                    for( int i = 0; i<boxLength; i ++ )
                        {
                            Write(" ");
                        }
                        Write( v );
                    }
                    else if( ( spacing % 2 ) == 0 )
                    {
                        spacesFromFront = (boxLength - tempLength) / 2;
                        for( int i = 0; i< spacesFromFront; i ++)
                        {
                            Write(" ");
                        }
                        Write( matrix[r, c] );
                        spacesFromRear = spacesFromFront;
                        for( int i = 0; i< spacesFromRear; i ++)
                        {
                            Write(" " );
                        }
                        Write( v );
                    }
                    else
                    {
                        spacesFromFront = (boxLength - tempLength - 1) / 2;
                        for( int i = 0; i< spacesFromFront; i ++)
                        {
                            Write(" ");
                        }
                        Write( matrix[r, c] );
                        spacesFromRear = (boxLength - tempLength + 1) / 2;
                        for( int i = 0; i < spacesFromRear; i ++ )
                        {
                            Write(" ");
                        }
                        Write( v );
                    }
                }
                
                WriteLine( );
                
                // Draw the boundary after the row.
                if( r != matrix.GetLength( 0 ) - 1 )
                { 
                    for( int c = 0; c < matrix.GetLength(1); c ++ )
                    {
                        if( c == 0 ) Write( vr );
                        for( int i = 0; i< boxLength; i ++ )
                        {
                            Write( h );
                        }
                        if( c == matrix.GetLength(1) -1 ) Write( "{0}", vl ); 
                        else                  Write( "{0}", hv );
                    }
                    WriteLine( );
                }
                else
                {
                    for( int c = 0; c < matrix.GetLength(1); c ++ )
                    {
                        if( c == 0 ) Write( bl );
                        for( int i = 0; i< boxLength; i ++ )
                        {
                            Write( h );
                        }
                        if( c == matrix.GetLength(1) - 1 ) Write( "{0}", br ); 
                        else                   Write( "{0}", ha );
                    }
                    WriteLine( );
                }
            }
        }
        
        static void Calculation1( double[,] firstMatrix )
        {
            WriteLine("Please enter desired calculation");
            WriteLine( "0 = Multiplication by Scalar" );
            WriteLine( "1 = Raise to Power of Scalar" );
            WriteLine( "2 = Transpose Matrix" );
            
            int selection = int.Parse(ReadLine( ) );
            
            if( selection == 0 )
            {
                ScalarMultiplication( firstMatrix );
            }
            
            else if( selection == 1 )
            {
                ScalarExponent( firstMatrix );
            }
            else if( selection == 2 )
            {
                TransposeMatrix( firstMatrix );
            }
            else WriteLine( "Entered value was not one of the possible options" );
        }
        
        static void Calculation2( double[,] firstMatrix, double[,] secondMatrix )
        {
            WriteLine("Please enter desired calculation");
            WriteLine( "0 = Addition of Second Matrix" );
            WriteLine( "1 = Subtraction of Second Matrix" );
            WriteLine( "2 = Multiplication by Second Matrix" );
            
            int selection = int.Parse(ReadLine( ) );
            
            if( selection == 0 )
            {
                AddArray( firstMatrix, secondMatrix );
            }
            
            else if( selection == 1 )
            {
                SubtractArray( firstMatrix, secondMatrix );
            }
            
            else if( selection == 2 )
            {
                MultiplyArray( firstMatrix, secondMatrix );
            }
        }
        
        static void ScalarMultiplication( double[,] matrix )
        {
            WriteLine( "Please enter a scalar factor for multiplication: ");
            double multiplier = int.Parse(ReadLine( ) );
            
            for(int i = 0; i< matrix.GetLength(0); i ++)
            {
                for(int j = 0; j< matrix.GetLength(1); j ++)
                {
                    matrix[i,j] = matrix[i,j] * multiplier;
                }
            }
            
            WriteLine( "Your array multiplied by {0} is", multiplier );
            
            WriteMatrix( matrix );
        }
        
        static void TransposeMatrix( double [,] matrix )
        {
            double[,] transposedMatrix = new double [ matrix.GetLength(1), matrix.GetLength(0) ];
            
            for( int i = 0; i <  matrix.GetLength(0); i ++ )
            {
                for( int j = 0; j <  matrix.GetLength(1); j ++ )
                {
                    transposedMatrix[j,i] = matrix[i,j];
                }
            }
            WriteMatrix(transposedMatrix );
        }
        
        static void ScalarExponent( double[,] matrix )
        {
            WriteLine( "Please enter an exponent: ");
            double exponent = int.Parse(ReadLine( ) );
            
            for(int i = 0; i< matrix.GetLength(0); i ++)
            {
                for(int j = 0; j< matrix.GetLength(1); j ++)
                {
                    matrix[i,j] = Math.Pow(matrix[i,j], exponent);
                }
            }
            
            WriteLine( "Your array to the exponent {0} is", exponent );
            
            WriteMatrix( matrix );
        }
        
        static void AddArray( double[,] firstMatrix, double[,] secondMatrix )
        {
            int firstHeight = firstMatrix.GetLength(0);
            int firstWidth = firstMatrix.GetLength(1);
            int secondHeight = secondMatrix.GetLength(0);
            int secondWidth = secondMatrix.GetLength(1);
            
            if( firstWidth != secondWidth)
            {
                throw new System.ArgumentException("Arrays can not be added");
            }
            if( firstHeight != secondHeight)
            {
                throw new System.ArgumentException("Arrays can not be added");
            }
            
            for(int i = 0; i< firstMatrix.GetLength(0); i ++)
            {
                for(int j = 0; j< secondMatrix.GetLength(1); j ++)
                {
                    firstMatrix[i,j] = firstMatrix[i,j] + secondMatrix[i,j];
                }
            }
            
            WriteLine( "The array formed is" );
            
            WriteMatrix( firstMatrix );
        }
        
        static void SubtractArray( double[,] firstMatrix, double[,] secondMatrix )
        {
            int firstHeight = firstMatrix.GetLength(0);
            int firstWidth = firstMatrix.GetLength(1);
            int secondHeight = secondMatrix.GetLength(0);
            int secondWidth = secondMatrix.GetLength(1);
            
            if( firstWidth != secondWidth)
            {
                throw new System.ArgumentException("Arrays can not be subtracted");
            }
            if( firstHeight != secondHeight)
            {
                throw new System.ArgumentException("Arrays can not be subtracted");
            }
            
            for(int i = 0; i< firstMatrix.GetLength(0); i ++)
            {
                for(int j = 0; j< firstMatrix.GetLength(1); j ++)
                {
                    firstMatrix[i,j] = firstMatrix[i,j] - secondMatrix[i,j];
                }
            }
            
            WriteLine( "The array formed is" );
            
            WriteMatrix( firstMatrix );
        }
        
        static void MultiplyArray( double[,] firstMatrix, double[,] secondMatrix )
        {
            int firstHeight = firstMatrix.GetLength(0);
            int firstWidth = firstMatrix.GetLength(1);
            int secondHeight = secondMatrix.GetLength(0);
            int secondWidth = secondMatrix.GetLength(1);
            
            if( firstWidth != secondHeight)
            {
                throw new System.ArgumentException("Arrays can not be multiplied");
            }
            
            double[,] finalMatrix = new double[firstHeight,secondWidth];
            
            for( int h1 = 0; h1< firstHeight; h1++)//length of total array and array 1
            {
                for( int w2 = 0; w2< secondWidth; w2++)//width of total array and array2
                {
                    for( int h2w1 = 0; h2w1<firstWidth; h2w1++)//width of array 1/lengthof array2
                    {
                            finalMatrix[h1,w2] = finalMatrix[h1,w2] + (firstMatrix[h1,h2w1] * secondMatrix[h2w1,w2]);
                    }
                    Write( "{0,2}  ", finalMatrix[h1,w2]);
                }
                WriteLine(" ");
            }
            WriteLine(" ");
            
            WriteMatrix( finalMatrix );
        }
    }
}
