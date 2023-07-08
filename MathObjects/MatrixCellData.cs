namespace MathObjects
{
    public abstract class MatrixCellData
    {
        public abstract MatrixCellData GetInverseByAddition();
        public abstract MatrixCellData Add(MatrixCellData data1);
        public abstract MatrixCellData Minus(MatrixCellData data1);
        public abstract MatrixCellData Multiply(MatrixCellData data1);
        public abstract MatrixCellData ReadCellData(string input);
        
    }
}