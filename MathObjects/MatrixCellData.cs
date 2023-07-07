namespace MathObjects
{
    public abstract class MatrixCellData
    {
        public abstract MatrixCellData GetInverseByAddition();
        public static MatrixCellData operator +(MatrixCellData data1, MatrixCellData data2) => null;
        public static MatrixCellData operator -(MatrixCellData data1, MatrixCellData data2) => null;
        public static MatrixCellData operator *(MatrixCellData data1, MatrixCellData data2) => null;
        public abstract MatrixCellData ReadCellData(string input);

    }
}