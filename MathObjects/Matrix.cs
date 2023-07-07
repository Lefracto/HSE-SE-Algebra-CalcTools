using System.Text;

namespace MathObjects
{
    public class Matrix<T> where T: MatrixCellData
    {
        private T[][] _values;

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
            var lines = _values.Length;
            var columns = _values[0].Length;
            var newValues = new T[columns][];
            
            for (var i = 0; i < columns; i++)
            {
                newValues[i] = new T[lines];
                for (var j = 0; j < lines; j++)
                {
                    newValues[i][j] = _values[j][i];
                }
            }

            _values = newValues;
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