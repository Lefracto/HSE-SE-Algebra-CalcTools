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
            if (cellValues is null)
                throw new NullReferenceException("");

            for (var i = 0; i < cellValues.Length - 1; i++)
            {
                if (cellValues[i].Length != cellValues[i + 1].Length)
                    throw new ArgumentException("Matrix must have equal count of elements in each line.");
            }
            
            _values = cellValues;
        }

        private T this [int line, int column]
        {
            get
            { 
                if (line < 0 || column < 0)
                    throw new ArgumentException("Line or column indexes must be >0");

                if (line >= _values.Length || column >= _values[0].Length)
                    throw new ArgumentException("Line or column indexes was out of the matrix sizes");
                
                return _values[line][column];
            }

            set
            {
                if (line < 0 || column < 0)
                    throw new ArgumentException("Line or column indexes must be >0");

                if (line >= _values.Length || column >= _values[0].Length)
                    throw new ArgumentException("Line or column indexes was out of the matrix sizes");
                
                _values[line][column] = value;
            }
        }
        
        public static void ReadMatrix(Matrix<T> matrix, string input)
        {
            try
            {
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
            catch (Exception e)
            {
                Console.WriteLine("There is an unknown error occured during ReadMatrix");
                Console.WriteLine(e.Message);
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
            if (firstLineIndex < 0 || secondLineIndex < 0)
                throw new ArgumentException("Incorrect lines indexes, they must be >0");

            if (firstLineIndex >= LinesCount || secondLineIndex >= LinesCount)
                throw new ArgumentException("Incorrect lines indexes, they must be less or equal than lines count");

            if (k is null)
                throw new NullReferenceException("K must be non null");
            
            for (var i = 0; i < ColumnsCount; i++)
            {
                _values[firstLineIndex][i] = (T)_values[firstLineIndex][i].Add(_values[secondLineIndex][i].Multiply(k));
            }
        }
        
        public void AddColumn(int firstColumnIndex, int secondColumnIndex, MatrixCellData k)
        {
            if (firstColumnIndex < 0 || secondColumnIndex < 0)
                throw new ArgumentException("Incorrect columns indexes, they must be >0");

            if (firstColumnIndex >= LinesCount || secondColumnIndex >= LinesCount)
                throw new ArgumentException("Incorrect columns indexes, they must be less or equal than lines count");

            if (k is null)
                throw new NullReferenceException("K must be non null");
            
            foreach (var t in _values)
            {
                t[firstColumnIndex] = (T)t[firstColumnIndex].Add(t[secondColumnIndex].Multiply(k));
            }
        }

        public MatrixCellData Determinant
        {
            ////TODO: Determinant using Gauss
            get
            { 
                throw new NotImplementedException();
                if (LinesCount != ColumnsCount)
                {
                    //exception
                }
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
            if (matrix1.LinesCount != matrix2.LinesCount || matrix1.ColumnsCount != matrix2.ColumnsCount)
                throw new ArgumentException("Matrix must have equal size");
            
            var newCellValues = new T[matrix1.LinesCount][];
            for (var i = 0; i < matrix1.LinesCount; i++)
            {
                newCellValues[i] = new T[matrix2.ColumnsCount];
                for (var j = 0; j < matrix2.ColumnsCount; j++)
                {
                    newCellValues[i][j] = (T)(matrix1[i,j].Add(matrix2[i,j]));
                }
            }

            return new Matrix<T>(newCellValues);
        }
        
        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
            =>  matrix1 + (-matrix2);
        
        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.ColumnsCount != matrix2.LinesCount)
                throw new ArgumentException("Matrices of such sizes impossible to multiply");
            
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
            var productElement = (T)(matrix1[i,0].Multiply(matrix2[0, j]));
            for (var k = 1; k < matrix1.ColumnsCount; k++)
            { 
                productElement = (T)productElement.Add(matrix1[i,k].Multiply(matrix2[k, j])); 
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
                    sb.Append(' ');
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}