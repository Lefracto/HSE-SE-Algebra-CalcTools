using System.Text;

namespace MathObjects
{
    public class Matrix<T> where T: MatrixCellData
    {
        private T[][] _values;

        public Matrix(T[][] cellValues)
        {
            _values = cellValues;
        }

        private T this [int line, int column]
        {
            get =>  _values[line][column];
            set => _values[line][column] = value;
        }
        
        public static void ReadMatrixFromConsole(Matrix<T> matrix)
        {
            
        }

        public static void ReadMatrixFromFile(Matrix<T> matrix)
        {
           
        }

        public void Transpose()
        {
            
        }

        public void AddLine(int firstLineIndex, int secondLineIndex, MatrixCellData k)
        {
            for (var i = 0; i < _values[0].Length; i++)
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
        
        public static Matrix<T> operator -(Matrix<T> matrix)
        {
            for (var i = 0; i < matrix._values.Length; i++)
            {
                for (var j = 0; j < matrix._values[0].Length; j++)
                {
                    matrix[i, j] = (T)(matrix[i, j].GetInverseByAddition());
                }
            }
            return matrix;
        } 
        
        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            var lines = matrix1._values.Length;
            var columns = matrix2._values[0].Length;
            
            var newCellValues = new T[lines][];

            for (var i = 0; i < lines; i++)
            {
                newCellValues[i] = new T[columns];
                for (var j = 0; j < columns; j++)
                {
                    newCellValues[i][j] = (T)(matrix1[i,j] + matrix2[i,j]);
                }
            }

            return new Matrix<T>(newCellValues);
        }
        
        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
            =>  matrix1 + (-matrix2);
        
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