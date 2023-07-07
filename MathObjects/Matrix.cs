using System;
using System.Text;

namespace MathObjects
{
    public class Matrix<T> where T: MatrixCellData
    {
        private T[][] _values;

        private int LinesCount => _values.Length;
        private int ColumnsCount => _values[0].Length;
        
        public Matrix(T[][] cellValues)
        {
            //TODO: Check for an exception and additional criteria
            _values = cellValues;
        }

        private T this [int line, int column]
        {
            //TODO: Check for an exception
            
            get =>  _values[line][column];
            set => _values[line][column] = value;
        }
        
        public static void ReadMatrix(Matrix<T> matrix, string input)
        {
            //TODO: Check for an exception
            
            var lines = input.Split('\n');
            for (var i = 0; i < lines.Length; i++)
            {
                var elements = lines[i].Split(' ');
                for (var j = 0; j < lines[i].Length; j++)
                {
                    matrix._values[i][j] =  (T)matrix._values[i][j].ReadCellData(elements[j]);
                }
            }
        }
        
        public void Transpose()
        {
            var newValues = new T[ColumnsCount][];
            
            for (var i = 0; i < ColumnsCount; i++)
            {
                newValues[i] = new T[LinesCount];
                for (var j = 0; j < LinesCount; j++)
                {
                    newValues[i][j] = _values[j][i];
                }
            }

            _values = newValues;
        }

        public void AddLine(int firstLineIndex, int secondLineIndex, MatrixCellData k)
        {
            for (var i = 0; i < ColumnsCount; i++)
            {
                _values[firstLineIndex][i] = (T)(_values[firstLineIndex][i] + k * _values[secondLineIndex][i]);
            }
        }
        
        public void AddColumn(int firstColumnIndex, int secondColumnIndex, MatrixCellData k)
        {
            foreach (var t in _values)
            {
                t[firstColumnIndex] = (T)(t[firstColumnIndex] + k * t[secondColumnIndex]);
            }
        }

        public MatrixCellData Determinant
        {
            ////TODO: Determinant using Gauss
            get
            {
                return _values[0][0];
            }
        }
        
        public static Matrix<T> operator -(Matrix<T> matrix)
        {
            for (var i = 0; i < matrix.LinesCount; i++)
            {
                for (var j = 0; j < matrix.ColumnsCount; j++)
                {
                    matrix[i, j] = (T)(matrix[i, j].GetInverseByAddition());
                }
            }
            return matrix;
        } 
        
        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            var newCellValues = new T[matrix1.LinesCount][];
            for (var i = 0; i < matrix1.LinesCount; i++)
            {
                newCellValues[i] = new T[matrix2.ColumnsCount];
                for (var j = 0; j < matrix2.ColumnsCount; j++)
                {
                    newCellValues[i][j] = (T)(matrix1[i,j] + matrix2[i,j]);
                }
            }

            return new Matrix<T>(newCellValues);
        }
        
        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
            =>  matrix1 + (-matrix2);
        
        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.ColumnsCount != matrix2.LinesCount)
            {
                //exception
            }
            
            var newCellValues = new T[matrix1.LinesCount][];

            for (var i = 0; i < matrix1.LinesCount; i++)
            {
                newCellValues[i] = new T[matrix2.ColumnsCount];
                for (var j = 0; j < matrix2.ColumnsCount; j++)
                {
                    newCellValues[i][j] = GetProductElement(i, j, matrix1, matrix2);
                }
            }
            
            return new Matrix<T>(newCellValues);
        }

        private static T GetProductElement(int i, int j, Matrix<T> matrix1, Matrix<T> matrix2)
        {
            ///TODO
            T productElement = (T)(matrix1[i,0] * matrix2[0, j]);
            for (var k = 1; i < matrix1.ColumnsCount; i++)
            { 
                //productElement += (T)(matrix1[i,0] * matrix2[0, j]); It does not work =(
            }
            
            return productElement;
        }
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var line in _values)
            {
                foreach (var element in line)
                {
                    sb.Append(element);
                    sb.Append(" ");
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}